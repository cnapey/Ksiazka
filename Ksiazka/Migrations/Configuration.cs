namespace Ksiazka.Migrations
{
    using Ksiazka.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ksiazka.DataAccessLayer.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ksiazka.DataAccessLayer.ApplicationDbContext context)
        {
            if (!context.BookShelf.Any(r => r.Name == "Pó³ka na ksi¹¿ki"))
            {
                var bs = new BookShelf();
                bs.Name = "Pó³ka na ksi¹¿ki";
                bs.Books = new List<AddressBook>();

                var ab = new AddressBook() { Title = "Adresy: Poznañ", CreateTime=DateTime.Now };
                ab.PersonalDatas = new List<PersonalData>();
                ab.PersonalDatas.Add(new PersonalData() { Name="Marian", Surname="PaŸdzioch", Email="marian.p@zdzioch.pl" });

                bs.Books.Add(ab);

                context.BookShelf.Add(bs);
                context.SaveChanges();
            }
        }
    }
}
