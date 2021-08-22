using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
