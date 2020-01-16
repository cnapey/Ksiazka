using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ksiazka.Models
{
    public class PersonalData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string FullAddress { get; set; }

        [ForeignKey("AddressBook")]
        public int AddressBookId { get; set; }
        public virtual AddressBook AddressBook {get;set;}
    }

}