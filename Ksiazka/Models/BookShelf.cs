using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ksiazka.Models
{
    public class BookShelf
    {
        public BookShelf()
        {
            this.Books = new List<AddressBook>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<AddressBook> Books { get; set; }
    }
}