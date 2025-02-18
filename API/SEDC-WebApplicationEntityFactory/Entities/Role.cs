﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SEDC_WebApplicationEntityFactory.Entities
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
