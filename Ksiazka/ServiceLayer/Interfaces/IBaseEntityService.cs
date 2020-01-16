using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiazka.ServiceLayer.Interfaces
{
    interface IBaseEntityService<T>
    {
        Task<List<T>> GetList();
        Task<T> GetById(int Id);
        Task<bool> SaveInDb(T data);
        Task<bool> SaveListInDb(List<T> dataList);
        Task<bool> Delete(int Id);
    }
}
