using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class EasySwitchbuttonAttribute : ControlsAttribute
    {
        private string _onText;
        private string _offText;
        private string _value;
        public EasySwitchbuttonAttribute()
            : this("True")
        {

        }
        public EasySwitchbuttonAttribute(string value)
            : this("Yes", "No", value)
        {

        }
        public EasySwitchbuttonAttribute(string onText, string offText, string value)
        {
            this._onText = onText;
            this._offText = offText;
            this._value = value;
        }

        public override void OnMetadataCreated(System.Web.Mvc.ModelMetadata metadata)
        {
            metadata.AdditionalValues.Add("EasySwitchbutton_OnText", this._onText);
            metadata.AdditionalValues.Add("EasySwitchbutton_OffText", this._offText);
            metadata.AdditionalValues.Add("EasySwitchbutton_Value", this._value);
            base.OnMetadataCreated(metadata);
        }
        protected override string TemplateHint
        {
            get { return "Easy_Switchbutton"; }
        }
    }
}
