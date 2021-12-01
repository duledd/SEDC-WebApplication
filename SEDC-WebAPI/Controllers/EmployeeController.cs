using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebAPI.Helpers;
using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebAPI.Services.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC_WebAPI.Controllers
{
    [Authorize(Roles = AuthorizationRoles.Admin)]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        //private List<Employee> employees;

        public EmployeeController(IDataService dataService, ILogger logger, IWebHostEnvironment hostingEnvironment)
        {
            _dataService = dataService;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //employees = mockEmployeeRepository.GetAllEmployees().ToList();

        }
        // GET: api/<EmployeeController>
        //[Authorize(Roles = AuthorizationRoles.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            List<EmployeeDTO> employees = (await _dataService.GetAllEmployees()).ToList();
            return Ok((employees));
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> Get(int id)
        {
            //UserDTO user = (UserDTO)HttpContext.Items["User"];
            //_logger.Information($"GetById {id} called.");
            //return _employeeRepository.GetEmployeeById(id);
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            LogEntryProperties log = new LogEntryProperties
            {
                User = user.UserName,
                Date = DateTime.Now,
                Message = $"User with id {user.Id}, name {user.UserName} call GetByEmployeeId {id}"
            };
            //_log.Repository.CreateLog(log);
            _logger.Information(log.ToString());
            return await _dataService.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] EmployeeDTO employee)
        {
            await _dataService.Add(employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EmployeeDTO employee)
        {
            await _dataService.UpdateEmployee(id, employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
