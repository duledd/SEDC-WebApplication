using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using SEDC_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private List<Employee> employees;

        public EmployeeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //employees = mockEmployeeRepository.GetAllEmployees().ToList();

        }


        [Route("List")]
        public IActionResult List()
        {

            List<EmployeeDTO> employees = _employeeRepository.GetAllEmployees().ToList();
            ViewBag.Title = "Employees";

            return View(employees);
        }

        [Route("DetailsView/{id}")]
        public IActionResult Details(int id)
        {
            //MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
            //Employee employee =  mockEmployeeRepository.GetEmployeeById(id);
            //Employee employee = employees.Where(x => x.Id == id).FirstOrDefault();

            EmployeeDTO employee = _employeeRepository.GetEmployeeById(id);

            //EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel
            //{
            //    Employee = employee,
            //    PageTitle = "Employee's details"
            //};

            EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
            employeeVM.EmployeeName = employee.Name;
            employeeVM.EmployeeEmail = employee.Email;
            employeeVM.PageTitle = "Employee's details";
            employeeVM.RoleEmployee = employee.Role.ToString();
            employeeVM.EmployeePol = employee.Pol;
            employeeVM.DateOfBirth = employee.DateOfBirth;
            employeeVM.EmployeeImage = employee.Picture;

            return View(employeeVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "avatar.png";
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                EmployeeDTO employee = new EmployeeDTO
                {
                    Id = null,
                    Name = model.Name,
                    Pol = model.Pol,
                    Email = model.Email,
                    Role = model.Role,
                    DateOfBirth = model.DateOfBirth,
                    Picture = "~/img/" + uniqueFileName
                };
                EmployeeDTO newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("List", new { id = newEmployee.Id});
            }
            else
            {
                return View();
            }
        }
    }
}
