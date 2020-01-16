using Ksiazka.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ksiazka.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BookAppConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<BookShelf> BookShelf { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<AddressBook> AddressBook { get; set; }
        public DbSet<AppConfigData> AppConfigData { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}