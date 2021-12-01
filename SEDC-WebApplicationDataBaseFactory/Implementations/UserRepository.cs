using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SEDC_WebApplicationDataBaseFactory.Entities;
using SEDC_WebApplicationDataBaseFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Implementations
{
    public class UserRepository : IUserDAL
    {
        private IConfiguration Configuration { get; set; }
        public UserRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public User GetUserByUserNameAndPassword(string username, string password)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                User result = db.Users.First(u => u.UserName == username && u.Password == password);
                return result;
            }
        }

        public User GetUserById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                User result = db.Users.First(u => u.Id == id);
                return result;
            }
        }
    }
}
