using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //private List<Customer> customers;

        public CustomerController(ICustomerRepository customerRepository, IWebHostEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
            //MockCustomerRepository mockCustomerRepository = new MockCustomerRepository();
            //customers = mockCustomerRepository.GetAllCustomers().ToList();
            //customers = _customerRepository.GetAllCustomers().ToList();
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerRepository.GetAllCustomers().ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDTO customer)
        {
            _customerRepository.Add(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
