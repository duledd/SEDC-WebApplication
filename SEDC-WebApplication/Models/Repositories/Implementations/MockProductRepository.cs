using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public MockProductRepository()
        {
            _productList = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Capricosa",
                    UnitPrice = 200,
                    IsDiscounted = true,
                    IsActive = true,
                    IsDeleted = false,
                    PicturePath = "~/img/pizza1.jpg",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },

                new Product
                {
                    Id = 2,
                    ProductName = "Vegeteriana",
                    UnitPrice = 180,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    PicturePath = "~/img/pizza3.jpg",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },

                new Product
                {
                    Id = 3,
                    ProductName = "Special",
                    UnitPrice = 220,
                    IsDiscounted = true,
                    IsActive = true,
                    IsDeleted = false,
                    PicturePath = "~/img/pizza2.jpg",
                    Description = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },
            };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProductById(int id)
        {
            return _productList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Product Add(Product product)
        {
            product.Id = _productList.Max(p => p.Id) + 1;
            _productList.Add(product);
            return _productList.Where(x => x.Id ==product.Id).FirstOrDefault();
        }

        public Product Edit(Product product)
        {
            _productList.Where(x => x.Id == product.Id).FirstOrDefault();
            _productList.Remove(product);
            _productList.Add(product);
            return _productList.Where(x => x.Id == product.Id).FirstOrDefault();
        }
    }
}
