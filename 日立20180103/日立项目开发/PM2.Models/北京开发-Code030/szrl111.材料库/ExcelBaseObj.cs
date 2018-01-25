using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl111Model
{
    public class ExcelColAttribute : System.Attribute
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public PropertyInfo PI { get; set; }
    }
}
