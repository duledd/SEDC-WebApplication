//using SEDC_WebApplicationEntityFactory.Entities;
using SEDC_WebApplication.BLL.Logic.Models.Enum;
using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models
{
    public class CustomerDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CustomerContactId { get; set; }
        //public RoleEnum Role { get; set; }
        public List<Order> Orders { get; set; }
        public string PicturePath { get; set; }
    }
}
