using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Interfaces
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<EmployeeDTO> Add(EmployeeDTO employee);
        Task<EmployeeDTO> Update(int id, EmployeeDTO employee);
    }
}
