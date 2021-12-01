using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Helpers;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC_WebAPI.Controllers
{
    [Authorize(Roles = AuthorizationRoles.Client)]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Customer> customers;

        public CustomerController(IDataService dataService, IWebHostEnvironment hostingEnvironment)
        {
            _dataService = dataService;
            _hostingEnvironment = hostingEnvironment;
            //MockCustomerRepository mockCustomerRepository = new MockCustomerRepository();
            //customers = mockCustomerRepository.GetAllCustomers().ToList();
            //customers = _customerRepository.GetAllCustomers().ToList();
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _dataService.GetAllCustomers().ToList();
        }

        // GET api/<CustomerController>/5
        //[Authorize(Roles = AuthorizationRoles.Client)]
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _dataService.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDTO customer)
        {
            _dataService.Add(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerDTO customer)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            _dataService.UpdateCustomer(id, customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
