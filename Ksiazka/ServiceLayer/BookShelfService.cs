using Ksiazka.DataAccessLayer;
using Ksiazka.Models;
using Ksiazka.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ksiazka.ServiceLayer
{
    public class BookShelfService : IBookShelfService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private void CheckConnectionOpen()
        {
            var connectionState = _db.Database.Connection.State;
            if (connectionState != ConnectionState.Open) _db.Database.Connection.Open();
        }

        public async Task<bool> Delete(int Id)
        {
            CheckConnectionOpen();
            bool ret = false;
            BookShelf entity = await _db.BookShelf.FindAsync(Id);
            if (entity != null)
            {
                _db.BookShelf.Remove(entity);
                await _db.SaveChangesAsync();
                ret = true;
            }
            return ret;
        }

        public async Task<BookShelf> GetById(int Id)
        {
            CheckConnectionOpen();
            return await _db.BookShelf.FindAsync(Id);
        }

        public async Task<List<BookShelf>> GetList()
        {
            CheckConnectionOpen();
            return await _db.BookShelf.ToListAsync();
        }

        public async Task<bool> SaveInDb(BookShelf data)
        {
            bool ret = false;

            try
            {
                this.CheckConnectionOpen();
                _db.BookShelf.Add(data);
                await _db.SaveChangesAsync();
                ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public async Task<bool> SaveListInDb(List<BookShelf> dataList)
        {
            foreach (var data in dataList)
            {
                CheckConnectionOpen();
                SaveInDb(data);
            }

            return true;
        }
    }
}