using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.BLL.Logic.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeDTO> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
                    Email="pera@fgdfgfd.net",
                    Role = RoleEnum.Manager,
                    Pol = "M",
                    Picture = "~/img/avatar.png"
                },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                    Email="mika@fdf.com",
                    Role = RoleEnum.Operater,
                    Pol = "M",
                    Picture = "~/img/avatar.png"
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
                    Email="laza@fgfg.com",
                    Role = RoleEnum.Sales,
                    Pol = "M",
                    Picture = "~/img/avatar.png"
                }
            };
        }


        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeList;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }
        public EmployeeDTO Add(EmployeeDTO employee)
        {
            employee.Id = _employeeList.Max(p => p.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }
    }
}
