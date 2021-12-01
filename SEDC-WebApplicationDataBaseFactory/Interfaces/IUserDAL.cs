using SEDC_WebApplicationDataBaseFactory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Interfaces
{
    public interface IUserDAL
    {
        User GetUserByUserNameAndPassword(string username, string password);
        User GetUserById(int id);
    }
}
