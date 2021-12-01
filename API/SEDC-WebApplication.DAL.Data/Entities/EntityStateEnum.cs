using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Entities
{
    public enum EntityStateEnum
    {
        Loaded = 0,

        New = 1,

        Updated = 2,

        Deleted = 3,

        Shallow = 4
    }
}
