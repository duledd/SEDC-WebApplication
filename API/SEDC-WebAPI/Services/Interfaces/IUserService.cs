using SEDC_WebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC_WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO Authenticate(string username, string password);
        UserDTO GetById(int id);
    }
}
