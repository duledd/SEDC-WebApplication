﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplicationDataBaseFactory.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; }
    }
}
