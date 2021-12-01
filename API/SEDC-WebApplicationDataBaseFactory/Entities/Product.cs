using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Size { get; set; }
        public string PicturePath { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
