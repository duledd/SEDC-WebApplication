using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplication.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebApplication.Models.Repositories.Implementations
{
    public class DataBaseEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeManager _employeeManager;
        public DataBaseEmployeeRepository(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            throw new NotImplementedException();
            //return _employeeManager.GetAllEmployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            throw new NotImplementedException();
            //return _employeeManager.GetEmployeeById(id);
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            throw new NotImplementedException();
            //return _employeeManager.Add(employee);
        }
    }
}
