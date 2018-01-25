using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class EasyDateboxAttribute : ControlsAttribute
    {
        protected override string TemplateHint
        {
            get { return "Easy_Datebox"; }
        }
    }
}
