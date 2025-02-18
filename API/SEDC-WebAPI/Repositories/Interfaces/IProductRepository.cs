﻿using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO Add(ProductDTO product);
        ProductDTO UpdateProduct(int id, ProductDTO product);
        ProductDTO Delete(ProductDTO product);
    }
}
