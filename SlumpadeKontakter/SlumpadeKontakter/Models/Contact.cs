using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SlumpadeKontakter.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        [Display(Name="Namn")]
        [Required(ErrorMessage="Du måste ange {0}")]
        [StringLength(50, ErrorMessage="Max 50 tecken")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange {0}")]
        [StringLength(50, ErrorMessage = "Max 50 tecken")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Du måste ange {0}")]
        [StringLength(50, ErrorMessage = "Max 50 tecken")]
        [EmailAddress(ErrorMessage="Inte en godkänd mailadress")]
        public string Email { get; set; }

        [Display(Name = "Skapad")]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}