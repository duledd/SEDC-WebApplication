using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Helpers;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
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
    public class OrderController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        

        public OrderController(IDataService dataService, IWebHostEnvironment hostingEnvironment)
        {
            _dataService = dataService;
            _hostingEnvironment = hostingEnvironment;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _dataService.GetAllOrders().ToList();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _dataService.GetOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDTO order)
        {
            _dataService.AddOrder(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderDTO order)
        {
            _dataService.UpdateOrder(id, order);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Authorize(Roles = AuthorizationRoles.Client)]
        [Route("myOrders")]
        [HttpGet]
        public IEnumerable<Order> GetAllMyOrders(/*int id*/)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return (IEnumerable<Order>)_dataService.GetOrdersByCustomerId(user.Id).ToList();
        }
    }
}
