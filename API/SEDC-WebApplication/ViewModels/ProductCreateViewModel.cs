﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Size { get; set; }
        //public string Description { get; set; }
        public IFormFile PicturePath { get; set; }
    }
}
