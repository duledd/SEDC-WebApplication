using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public string PageTitle { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string RoleEmployee { get; set; }
        public string EmployeePol { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmployeeImage { get; set; }
    }
}
