using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class EasyPasswordboxAttribute : ControlsAttribute
    {
        protected override string TemplateHint
        {
            get { return "Easy_Passwordbox"; }
        }
    }
}
