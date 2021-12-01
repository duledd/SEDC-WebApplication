using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.BLL.Logic.Helpers
{
    public class EnumHelper
    {
        public static string GetString<T>(object value)
        {
            return Enum.GetName(typeof(T), value);
        }
    }
}
