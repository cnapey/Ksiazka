using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Ksiazka.DataAccessLayer;
using Ksiazka.Models;
using Ksiazka.ViewModels;

namespace Ksiazka.Controllers
{
    public class BookShelvesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: api/BookShelves
        [ResponseType(typeof(BookShelfViewModel))]
        public async Task<IHttpActionResult> GetBookShelf()
        {

            var shelves = new List<BookShelfViewModel>();
            var dbShelves = db.BookShelf.Include("Books").Include("Books.PersonalDatas").ToList();

            foreach (var bs in dbShelves)
            {
                shelves.Add(new BookShelfViewModel(bs));
            }
            return Ok(shelves);
        }

        // GET: api/BookShelves/5
        [ResponseType(typeof(BookShelf))]
        public async Task<IHttpActionResult> GetBookShelf(int id)
        {
            BookShelf bookShelf = await db.BookShelf.FindAsync(id);
            if (bookShelf == null)
            {
                return NotFound();
            }

            return Ok(bookShelf);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookShelfExists(int id)
        {
            return db.BookShelf.Count(e => e.Id == id) > 0;
        }
    }
}