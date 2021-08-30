using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplication.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC_WebApplication.BLL.Logic.Implementations
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;
        public ProductManager(IProductDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }

        public ProductDTO Add(ProductDTO product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Save(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);
            return product;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(0, 50));
        }

        public ProductDTO GetProductById(int id)
        {
            return _mapper.Map<ProductDTO>(_productDAL.GetById(id));
        }
    }
}
