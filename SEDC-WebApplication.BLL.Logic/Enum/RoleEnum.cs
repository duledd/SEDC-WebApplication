using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Models.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "Menadzer")]
        Manager = 1,
        Operater = 5,
        Sales = 6,
        Customer = 7
    }
}
