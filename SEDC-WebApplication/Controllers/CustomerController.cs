using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.Models;
using SEDC_WebApplication.Models.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using SEDC_WebApplication.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SEDC_WebApplication.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private List<Customer> customers;

        public CustomerController(ICustomerRepository customerRepository, IHostingEnvironment hostingEnvironment)
        {
            _customerRepository = customerRepository;
            _hostingEnvironment = hostingEnvironment;
            //MockCustomerRepository mockCustomerRepository = new MockCustomerRepository();
            //customers = mockCustomerRepository.GetAllCustomers().ToList();
            //customers = _customerRepository.GetAllCustomers().ToList();
        }


        [Route("List")]
        public IActionResult List()
        {
            List<Customer> customer = _customerRepository.GetAllCustomers().ToList();
            ViewBag.Title = "Customers";

            return View(customer);
        }


        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);

            CustomerDetailsViewModel customerVM = new CustomerDetailsViewModel();
            customerVM.CustomerName = customer.Name;
            customerVM.PageTitle = "Customer details";
            customerVM.CustomerEmail = customer.Email;
            customerVM.CustomerImage = customer.PicturePath;

            return View(customerVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = "photo2.jpg";
                if (model.Picture != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                Customer customer = new Customer
                {
                    Name = model.Name,
                    Email = model.Email,
                    //DateOfBirth = model.DateOfBirth,
                    PicturePath = "~/img/" + uniqueFileName
                };
                Customer newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            CustomerEditViewModel customerEditViewModel = new CustomerEditViewModel
            {
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CustomerEmail = customer.Email
            };
            return View(customerEditViewModel);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customerRepository.GetCustomerById(id);
                customer.Name = model.CustomerName;
                customer.Email = model.CustomerEmail;

                string uniqueFileName = "photo2.jpg";
                if (model.CustomerImage != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CustomerImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.CustomerImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                customer.PicturePath = "~/img/" + uniqueFileName;

                Customer newProduct = _customerRepository.Update(customer);
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
    }
}
