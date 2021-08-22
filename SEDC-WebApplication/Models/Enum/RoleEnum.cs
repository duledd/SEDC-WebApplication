using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "Menadzer")]
        Manager,
        Sales,
        Operater
    }
}
