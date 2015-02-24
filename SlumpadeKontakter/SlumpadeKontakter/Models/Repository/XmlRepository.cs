using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SlumpadeKontakter.Models.Repository
{
    public class XmlRepository : IRepository
    {
        private static readonly string PhysicalPath;
        private XDocument _document;
        private XDocument Document
        {
            get
            {
                return _document ?? (_document = XDocument.Load(PhysicalPath));
            }
        }
        static XmlRepository()
        {
            PhysicalPath = Path.Combine(
                AppDomain.CurrentDomain.GetData("DataDirectory").ToString(),
                "Contacts.xml");
        }



        public void Add(Contact contact)
        {
            var element = new XElement("Contact",
                          new XElement("Id", contact.Id.ToString()),
                          new XElement("FirstName", contact.FirstName),
                          new XElement("LastName", contact.LastName),
                          new XElement("Email", contact.Email),
                          new XElement("Created", contact.Created.ToString("yyyy-MM-dd")),
                          new XElement("Updated", contact.Created.ToString("yyyy-MM-dd"))
                          );

            Document.Root.Add(element);
        }
        public void Delete(Contact contact)
        {
            Document.Descendants("Contact")
                .Where(a => a.Element("Id").Value.ToUpper() == contact.Id.ToString().ToUpper())
                .FirstOrDefault().Remove();
        }
        public IList<Contact> GetAllContacts()
        {
            return Document.Descendants("Contact")
                    .Select(x => new Contact
                    {
                        Id = Guid.Parse(x.Element("Id").Value),
                        FirstName = x.Element("FirstName").Value,
                        LastName = x.Element("LastName").Value,
                        Email = x.Element("Email").Value,
                        Created = DateTime.Parse(x.Element("Created").Value),
                        Updated = DateTime.Parse(x.Element("Updated").Value)
                    })
                    .ToList();
        }
        public Contact GetContactById(Guid id)
        {
            return Document.Descendants("Contact")
                .Where(a => a.Element("Id").Value.ToUpper() == id.ToString().ToUpper())
                .Select(x => new Contact
                {
                    Id = Guid.Parse(x.Element("Id").Value),
                    FirstName = x.Element("FirstName").Value,
                    LastName = x.Element("LastName").Value,
                    Email = x.Element("Email").Value,
                    Created = DateTime.Parse(x.Element("Created").Value),
                    Updated = DateTime.Parse(x.Element("Updated").Value)
                }).FirstOrDefault();
        }
        public List<Contact> GetLastContacts(int count = 20)
        {
            return GetAllContacts().OrderByDescending(x => x.Created).Take(count).ToList();
        }
        public void Update(Contact contact)
        {
            Document.Descendants("Contact")
               .Where(a => a.Element("Id").Value.ToUpper() == contact.Id.ToString().ToUpper())
               .Select(x =>
               {
                   x.Element("FirstName").Value = contact.FirstName;
                   x.Element("LastName").Value = contact.LastName;
                   x.Element("Email").Value = contact.Email;
                   x.Element("Updated").Value = DateTime.Now.ToString("yyyy-MM-dd");
                   return x;
               }).FirstOrDefault();
        }
        public void Save()
        {
            Document.Save(PhysicalPath);
        }
    }
}