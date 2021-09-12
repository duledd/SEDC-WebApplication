using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Implementations
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
            try
            {
                return _productManager.GetProductById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Add(ProductDTO product)
        {
            return _productManager.Add(product);
        }


        //public ProductDTO Delete(ProductDTO product)
        //{
        //    return _productManager.Delete(product);
        //}
    }
}
