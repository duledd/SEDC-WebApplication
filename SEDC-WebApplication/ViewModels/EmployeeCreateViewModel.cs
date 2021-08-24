using Microsoft.AspNetCore.Http;
using SEDC_WebApplication.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }
        public string Pol { get; set; }

        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public DateTime DateOfBirth { get; set; }

        public IFormFile Photo { get; set; }
    }
}
