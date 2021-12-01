using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Interfaces
{
    public interface IEmployeeDAL
    {
        void Save(Employee item);
        Employee GetById(int id);
        List<Employee> GetAll(int skip, int take);
        void Update(Employee item);
    }
}
