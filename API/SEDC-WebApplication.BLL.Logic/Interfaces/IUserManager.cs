using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Interfaces
{
    public interface IUserManager
    {
        UserDTO GetUserByUserNameAndPassword(string username, string password);
        UserDTO GetById(int id);
    }
}
