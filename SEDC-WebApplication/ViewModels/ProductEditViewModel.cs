using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class ProductEditViewModel
    {
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Discounted { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string ProductSize { get; set; }
        public string ProductDescription { get; set; }
        public IFormFile Picture { get; set; }
    }
}
