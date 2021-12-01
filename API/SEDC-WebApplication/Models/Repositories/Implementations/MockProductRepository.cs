using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class MockProductRepository : IProductRepository
    {
        private List<ProductDTO> _productList;
        public MockProductRepository()
        {
            _productList = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Capricosa",
                    Price = 200,
                    Discounted = true,
                    Active = true,
                    Deleted = false,
                    ImagePath = "~/img/pizza1.jpg"
                    //ProductDescription = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },

                new ProductDTO
                {
                    Id = 2,
                    Name = "Vegeteriana",
                    Price = 180,
                    Discounted = false,
                    Active = true,
                    Deleted = false,
                    ImagePath = "~/img/pizza3.jpg"
                    //ProductDescription = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },

                new ProductDTO
                {
                    Id = 3,
                    Name = "Special",
                    Price = 220,
                    Discounted = true,
                    Active = true,
                    Deleted = false,
                    ImagePath = "~/img/pizza2.jpg"
                    //ProductDescription = "Some quick example text to build on the card title and make up the bulk of the card's content."
                },
            };
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _productList;
        }

        public ProductDTO GetProductById(int id)
        {
            return _productList.Where(x => x.Id == id).FirstOrDefault();
        }
        public ProductDTO Add(ProductDTO product)
        {
            product.Id = _productList.Max(p => p.Id) + 1;
            _productList.Add(product);
            return _productList.Where(x => x.Id ==product.Id).FirstOrDefault();
        }

        //public Product Update(Product product)
        //{
        //    _productList.Where(x => x.Id == product.Id).FirstOrDefault();
        //    _productList.Remove(product);
        //    _productList.Add(product);
        //    return _productList.Where(x => x.Id == product.Id).FirstOrDefault();
        //}
    }
}
