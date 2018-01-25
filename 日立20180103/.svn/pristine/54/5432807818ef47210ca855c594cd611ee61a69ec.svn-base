using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class EasyComboboxAttribute : ControlsAttribute
    {
        protected override string TemplateHint
        {
            get { return "Easy_Combobox"; }
        }

        /// <summary>
        /// 远程地址
        /// </summary>
        private string _url;
        public EasyComboboxAttribute()
        {

        }
        public EasyComboboxAttribute(string url)
        {
            this._url = url;
        }

        public override void OnMetadataCreated(System.Web.Mvc.ModelMetadata metadata)
        {
            if (!string.IsNullOrEmpty(this._url))
                metadata.AdditionalValues.Add("EasyComboboxRemote_LoadUrl", this._url);
            base.OnMetadataCreated(metadata);
        }

    }
}
