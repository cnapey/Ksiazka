using Ksiazka.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ksiazka.Models
{
    public class AddressBook
    {
        public AddressBook()
        {
            this.CreateTime = DateTime.Now;
            this.PersonalDatas = new List<PersonalData>();
        }
        public AddressBook(AddressBookViewModel vm)
        {
            this.CreateTime = DateTime.Now;
            this.PersonalDatas = new List<PersonalData>();
            this.Title = vm.Title;
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }

        [ForeignKey("BookShelf")]
        public int BookShelfId { get; set; }
        public virtual BookShelf BookShelf { get; set; }
        public List<PersonalData> PersonalDatas { get; set; }
    }

}