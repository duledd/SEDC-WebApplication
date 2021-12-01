using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Interfaces
{
    public interface IProductDAL
    {
        void Save(Product item);
        Product GetById(int id);
        List<Product> GetAll(int skip, int take);

        void Update(Product item);
    }
}
