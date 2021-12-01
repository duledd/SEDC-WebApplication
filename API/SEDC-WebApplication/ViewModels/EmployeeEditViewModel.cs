using SEDC_WebApplication.BLL.Logic.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.ViewModels
{
    public class EmployeeEditViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public RoleEnum EmployeeRole { get; set; }
        public string EmployeePol { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeePicture { get; set; }
    }
}
