using SEDC_WebApplication.BLL.Logic.Models.Enum;
using SEDC_WebApplication.DAL.Data.Entities;
using SEDC_WebApplicationDataBaseFactory.Entities;
//using SEDC_WebApplicationEntityFactory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Models
{
    public class EmployeeDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public string Pol { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Picture { get; set; }
    }
}
