using SEDC_WebApplicationEntityFactory.Entities;
using SEDC_WebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Implementations
{
    public class ProductRepository : IProductDAL
    {
        public List<Product> GetAll(int skip, int take)
        {
            using (var db = new PizzaShop4Context())
            {
                List<Product> result = db.Products.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Product GetById(int id)
        {
            using (var db = new PizzaShop4Context())
            {
                Product result = db.Products.First(e => e.ProductId == id);
                return result;
            }
        }

        public void Save(Product item)
        {
            using (var db = new PizzaShop4Context())
            {
                db.Products.Add(item);
                db.SaveChanges();
            }
        }
    }
}
