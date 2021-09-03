using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Entities
{
    public class Employee : User
    {
        public Employee(int? id)
               : base(id)
        {
        }
        public string Name { get; set; }

        public string Gender { get; set; }

        public int RoleId { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PicturePath { get; set; }
    }
}
