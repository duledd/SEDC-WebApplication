using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class Customer : User
    {
        public string CustomerName { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public Role Role { get; set; }

        //[ForeignKey("ContactId")]
        public Contact Contact { get; set; }
        public List<Order> Orders { get; set; }
    }
}
