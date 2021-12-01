using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Models
{
    public class OrderItemDTO
    {
        //public int Id { get; set; }
        //public string OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
