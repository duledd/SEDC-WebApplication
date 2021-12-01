using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class DataBaseProductRepository : IProductRepository
    {
        private readonly IProductManager _productManager;
        public DataBaseProductRepository(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _productManager.GetAllProducts();
        }

        public ProductDTO GetProductById(int id)
        {
            return _productManager.GetProductById(id);
        }

        public ProductDTO Add(ProductDTO product)
        {
            return _productManager.Add(product);
        }
    }
}
