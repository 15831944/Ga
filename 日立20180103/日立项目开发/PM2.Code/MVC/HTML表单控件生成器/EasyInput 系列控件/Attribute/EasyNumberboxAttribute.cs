using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class EasyNumberboxAttribute : ControlsAttribute
    {
        private bool _isInt;
        public EasyNumberboxAttribute(bool isInt = true)
        {
            this._isInt = isInt;
        }
        protected override string TemplateHint
        {
            get {
                if (this._isInt)
                    return "Easy_Numberbox_Int32";
                else
                    return "Easy_Numberbox_Decimal";
            }
        }
    }
}
