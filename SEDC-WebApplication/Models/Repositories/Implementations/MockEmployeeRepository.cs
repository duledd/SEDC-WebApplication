using SEDC_WebApplication.Models.Enum;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Pera",
                    Email="pera@fgdfgfd.net",
                    Role = RoleEnum.Manager,
                    Pol = "M",
                    Picture = "~/img/avatar.png"
                },
                new Employee
                {
                    Id=2,
                    Name="Mika",
                    Email="mika@fdf.com",
                    Role = RoleEnum.Operater,
                    Pol = "M",
                    Picture = "~/img/avatar.png"
                },
                new Employee
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


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }
        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(p => p.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }
    }
}
