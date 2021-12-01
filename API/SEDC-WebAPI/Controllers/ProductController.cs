using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Helpers;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC_WebAPI.Controllers
{
    //[Authorize(Roles = AuthorizationRoles.Admin)]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Product> products;

        public ProductController(IDataService dataService, IWebHostEnvironment hostingEnvironment)
        {
            _dataService = dataService;
            _hostingEnvironment = hostingEnvironment;
            //products = _productRepository.GetAllProducts().ToList();
        }
        // GET: api/<ProductController>
        [Authorize(Roles = AuthorizationRoles.Client)]
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _dataService.GetAllProducts().ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return _dataService.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
            _dataService.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDTO product)
        {
            _dataService.UpdateProduct(id, product);
        }

        //DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //var product = _productRepository.GetProductById(id);
            //_productRepository.Delete(product);
            //var productDeleted = _productRepository.GetProductById(id);
            //return productDeleted.Deleted;
        }
    }
}
