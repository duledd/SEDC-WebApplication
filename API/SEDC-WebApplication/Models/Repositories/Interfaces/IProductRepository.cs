using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO Add(ProductDTO product);
    }
}
