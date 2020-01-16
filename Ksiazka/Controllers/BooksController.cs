using Ksiazka.DataAccessLayer;
using Ksiazka.Models;
using Ksiazka.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Ksiazka.Controllers
{
    public class BooksController : BaseController
    {


        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: api/Books
        public async Task<IHttpActionResult> GetBooks(string code)
        {
            var books = new List<AddressBookViewModel>();
            List<AddressBook> dbBooks = new List<AddressBook>();
            if (db.AppConfigData.Any(a=>a.AccessKey == code))
            {
                dbBooks = await db.AddressBook.ToListAsync();
                foreach (var b in dbBooks)
                {
                    books.Add(new AddressBookViewModel(b));
                }
                return Ok(books);
            }
            return Content(HttpStatusCode.Unauthorized, _unauthorizedMsg);
        }

    }
}
