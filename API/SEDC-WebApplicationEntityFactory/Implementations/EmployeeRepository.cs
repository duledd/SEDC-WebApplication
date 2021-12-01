using SEDC_WebApplicationEntityFactory.Entities;
using SEDC_WebApplicationEntityFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationEntityFactory.Implementations
{
    public class EmployeeRepository : IEmployeeDAL
    {
        public List<Employee> GetAll(int skip, int take)
        {
            using(var db = new PizzaShop4Context())
            {
                List<Employee> result = db.Employees.Skip(skip).Take(take).ToList();
                return result;
            }
        }

        public Employee GetById(int id) 
        {
            using (var db = new PizzaShop4Context())
            {
                Employee result = db.Employees.First(e => e.EmployeeId == id);
                return result;
            }
        }

        public void Save(Employee item)
        {
            using (var db = new PizzaShop4Context())
            {
                User user = new User();
                user.Employee = item;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
