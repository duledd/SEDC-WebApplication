using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class CustomerEditViewModel
    {
        public int CustomerId { get; set; }
        public string PageTitle { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public IFormFile CustomerImage { get; set; }
    }
}
