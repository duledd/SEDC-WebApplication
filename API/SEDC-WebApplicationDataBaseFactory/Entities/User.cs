﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string PicturePath { get; set; }
    }
}
