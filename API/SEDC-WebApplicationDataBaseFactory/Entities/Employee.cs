using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class Employee : User
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        //[ForeignKey("RoleId")]
        public Role Role { get; set; }
        public List<Order> Orders { get; set; }
        //public string PicturePath { get; set; }
    }
}
