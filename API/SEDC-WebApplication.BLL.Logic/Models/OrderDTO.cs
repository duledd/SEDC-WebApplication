using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Models
{
    public class OrderDTO
    {
        //public int? Id { get; set; }
        //public string Number { get; set; }
        //public DateTime Date { get; set; }
        //public decimal TotalAmount { get; set; }
        //public int Status { get; set; }
        //public Employee Employee { get; set; }
        //public Customer Customer { get; set; }
        //public int EmployeeId { get; set; }
        //public int CustomerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
