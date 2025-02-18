﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SEDC_WebApplicationEntityFactory.Entities
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
