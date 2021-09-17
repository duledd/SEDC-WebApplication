using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
//using SEDC_WebApplicationEntityFactory.Entities;
//using SEDC_WebApplicationEntityFactory.Interfaces;
//using SEDC_WebApplication.DAL.Data.Entities;
//using SEDC_WebApplication.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC_WebApplication.BLL.Logic.Implementations
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDAL _productDAL;
        private readonly IOrderItemDAL _orderItemDAL;
        private readonly IMapper _mapper;
        public ProductManager(IProductDAL productDAL, IOrderItemDAL orderItemDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _orderItemDAL = orderItemDAL;
            _mapper = mapper;
        }

        public ProductDTO Add(ProductDTO product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Save(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);
            return product;
        }

        public ProductDTO Delete(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(0, 50));
        }

        public ProductDTO GetProductById(int id)
        {
            //return _mapper.Map<ProductDTO>(_productDAL.GetById(id));
            try
            {
                Product product = _productDAL.GetById(id);
                if (product == null)
                {
                    throw new Exception($"Product with id {id} not found.");
                }
                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                //productDTO.ProductOrderItems = _orderItemDAL.GetByProductId((int)product.ProductId);
                return productDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public ProductDTO Delete(ProductDTO product)
        //{
        //    Product productEntity = _mapper.Map<Product>(product);
        //    if (productEntity.IsDeleted == true)
        //    {
        //        return product;
        //    }
        //    else
        //    {
        //        productEntity.EntityState = (EntityStateEnum.Deleted);
        //        _productDAL.Save(productEntity);
        //        return _mapper.Map<ProductDTO>(productEntity);
        //    }
        //}
    }
}
