using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    public class Easy_Numberbox_Int32 : Easy_Numberbox
    {
        protected override void SetDataOptions(EasyInputBuilder _this, Dictionary<string, string> dataoptions)
        {
            dataoptions.Add("precision", "0");
        }
    }
}
