using Microsoft.AspNetCore.Mvc;
using SEDC_WebApplication.Models;
using SEDC_WebApplication.Models.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using SEDC_WebApplication.ViewModels;

namespace SEDC_WebApplication.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        //private List<Customer> customers;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
            customerVM.CustomerImage = customer.Picture;

            return View(customerVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            Customer newCustomer = _customerRepository.Add(customer);
            return RedirectToAction("List");
        }
    }
}
