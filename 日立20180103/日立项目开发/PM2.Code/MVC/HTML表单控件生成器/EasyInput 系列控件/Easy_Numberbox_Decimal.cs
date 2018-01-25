using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class Easy_Numberbox_Decimal : Easy_Numberbox
    {
        protected override void SetDataOptions(EasyInputBuilder _this, Dictionary<string, string> dataoptions)
        {
            if(!dataoptions.ContainsKey("precision"))
                dataoptions.Add("precision", "2");
            dataoptions.Add("groupSeparator", "','");
            dataoptions.Add("decimalSeparator", "'.'");
        }
    }
}
