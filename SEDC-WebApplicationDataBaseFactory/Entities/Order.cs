using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        //public int EmployeeId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        ////[ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
