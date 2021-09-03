using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC_WebApplication.Models;

namespace SEDC_WebApplication.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string PageTitle { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Discounted { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public string ProductSize { get; set; }
        //public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
    }
}
