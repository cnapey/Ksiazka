using Ksiazka.Models;
using Ksiazka.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ksiazka.ServiceLayer
{
    public class PersonalDataService : IPersonalDataService
    {
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonalData> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonalData>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveInDb(PersonalData data)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveListInDb(List<PersonalData> dataList)
        {
            throw new NotImplementedException();
        }
    }
}