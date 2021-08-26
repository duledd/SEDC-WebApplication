using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Entities
{
    public class Customer : User
    {
        public Customer(int? id)
            : base (id)
        {
        }
        public string Name { get; set; }

        public string Email { get; set; }
        public string PicturePath { get; set; }
    }
}
