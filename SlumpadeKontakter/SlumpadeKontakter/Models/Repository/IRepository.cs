using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlumpadeKontakter.Models.Repository
{
    public interface IRepository
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        IList<Contact> GetAllContacts();
        Contact GetContactById(Guid id);
        List<Contact> GetLastContacts(int count = 20);
        void Update(Contact contact);
        void Save();
    }
}
