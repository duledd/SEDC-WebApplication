using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Entities
{
    public class User : BaseEntity
    {
        public User(int? id)
            : base(id)
        {
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
