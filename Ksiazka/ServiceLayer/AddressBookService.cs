using Ksiazka.DataAccessLayer;
using Ksiazka.Models;
using Ksiazka.ServiceLayer.Interfaces;
using Ksiazka.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ksiazka.ServiceLayer
{
    public class AddressBookService : IAddressBookService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private void CheckConnectionOpen()
        {
            var connectionState = _db.Database.Connection.State;
            if (connectionState != ConnectionState.Open) _db.Database.Connection.Open();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressBookViewModel> GetById(int Id)
        {
            var model = await _db.AddressBook.FindAsync(Id);
            if (model != null)
            {
                var vm = new AddressBookViewModel(model);
                var data = _db.PersonalData.Where(pd => pd.AddressBookId == vm.Id).ToList();

                var lista = new List<PersonalDataViewModel>();

                foreach (var item in data)
                {
                    lista.Add(new PersonalDataViewModel(item));
                }

                vm.PersonalDatas = lista;
                return vm;
            }
            return null;
        }

        public async Task<List<AddressBookViewModel>> GetList()
        {
            CheckConnectionOpen();
            var model = await _db.AddressBook.ToListAsync();
            var vm = new List<AddressBookViewModel>();

            foreach (var item in model)
            {
                vm.Add(new AddressBookViewModel(item));
            }
            return vm;
        }

        public async Task<bool> SaveInDb(AddressBookViewModel data)
        {
            bool ret = false;

            var model = new AddressBook(data);
            try
            {
                this.CheckConnectionOpen();
                _db.AddressBook.Add(model);
                await _db.SaveChangesAsync();
                ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public Task<bool> SaveListInDb(List<AddressBookViewModel> dataList)
        {
            throw new NotImplementedException();
        }
    }
}