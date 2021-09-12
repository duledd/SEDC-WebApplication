using SEDC_WebAPI.Repositories.Interfaces;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Repositories.Implementations
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
            return _employeeManager.GetAllEmployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            try
            {
                return _employeeManager.GetEmployeeById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            return _employeeManager.Add(employee);
        }
    }
}
