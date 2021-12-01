using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Interfaces
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO Add(ProductDTO product);
        ProductDTO Update(int id, ProductDTO product);
        ProductDTO Delete(ProductDTO product);
    }
}
