using AutoMapper;
using SEDC_WebApplication.BLL.Logic.Interfaces;
using SEDC_WebApplication.BLL.Logic.Models;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.GenericRepository;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
//using SEDC_WebApplicationEntityFactory.Entities;
//using SEDC_WebApplicationEntityFactory.Interfaces;
//using SEDC_WebApplication.DAL.Data.Entities;
//using SEDC_WebApplication.DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        //private readonly IEmployeeDAL _employeeDAL;
        private readonly IGenericRepository<Employee> _employeeDAL;
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public EmployeeManager(IGenericRepository<Employee> employeeDAL, IOrderDAL orderDAL, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _orderDAL = orderDAL;
            _mapper = mapper;
        }
        public async Task<EmployeeDTO> Add(EmployeeDTO employee)
        {
            //Employee employeeEntity = new Employee(null)
            //{
            //    Name = employee.Name,
            //    UserName = employee.Email
            //};
            Employee employeeEntity = _mapper.Map<Employee>(employee);
            await _employeeDAL.Save(employeeEntity);
            employee = _mapper.Map<EmployeeDTO>(employeeEntity);
            return employee;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            List<EmployeeDTO> employeeDTOs = _mapper.Map<List<EmployeeDTO>>(await _employeeDAL.GetAll(0, 50));
            //foreach(EmployeeDTO employeeDTO in employeeDTOs)
            //{
            //    employeeDTO.Orders = _orderDAL.GetByEmployeeId((int)employeeDTO.Id);
            //}
            return employeeDTOs;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            try
            {
                Employee employee = await _employeeDAL.GetById(id);
                if (employee == null)
                {
                    throw new Exception($"Employee with id {id} not found.");
                }
                EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);
                //employeeDTO.Orders = _orderDAL.GetByEmployeeId((int)employee.EmployeeId);
                return employeeDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmployeeDTO> Update(int id, EmployeeDTO employee)
        {
            //Employee employeeEntity = new Employee(null)
            //{
            //    Name = employee.Name,
            //    UserName = employee.Email
            //};
            Employee employeeEntity = _mapper.Map<Employee>(employee);
            await _employeeDAL.Update(employeeEntity);
            employee = _mapper.Map<EmployeeDTO>(employeeEntity);
            return employee;
        }
        //private readonly IEmployeeDAL _employeeDAL;
        //private readonly IMapper _mapper;
        //public EmployeeManager(IEmployeeDAL employeeDAL, IMapper mapper)
        //{
        //    _employeeDAL = employeeDAL;
        //    _mapper = mapper;
        //}
        //public EmployeeDTO Add(EmployeeDTO employee)
        //{
        //    //Employee employeeEntity = new Employee(null)
        //    //{
        //    //    Name = employee.Name,
        //    //    Gender = employee.Pol,
        //    //    UserName = employee.Email
        //    //};
        //    Employee employeeEntity = _mapper.Map<Employee>(employee);
        //    _employeeDAL.Save(employeeEntity);
        //    return employee;
        //}

        //public IEnumerable<EmployeeDTO> GetAllEmployees()
        //{
        //    //return _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0,50));
        //    List<EmployeeDTO> employeeDTOs = _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0, 50));
        //    return employeeDTOs;
        //}

        //public EmployeeDTO GetEmployeeById(int id)
        //{
        //    return _mapper.Map<EmployeeDTO>(_employeeDAL.GetById(id));
        //}
    }
}
