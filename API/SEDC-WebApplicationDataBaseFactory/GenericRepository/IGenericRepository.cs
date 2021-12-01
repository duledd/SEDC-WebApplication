using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Save(T item);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(int skip, int take);
        Task Update(T item);
    }
}
