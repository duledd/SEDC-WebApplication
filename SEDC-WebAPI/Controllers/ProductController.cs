using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Product> products;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            _hostingEnvironment = hostingEnvironment;
            //products = _productRepository.GetAllProducts().ToList();
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _productRepository.GetAllProducts().ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return _productRepository.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            _productRepository.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public bool Delete(int id)
        //{
        //    var product = _productRepository.GetProductById(id);
        //    _productRepository.Delete(product);
        //    var productDeleted = _productRepository.GetProductById(id);
        //    return productDeleted.Deleted;
        //}
    }
}
