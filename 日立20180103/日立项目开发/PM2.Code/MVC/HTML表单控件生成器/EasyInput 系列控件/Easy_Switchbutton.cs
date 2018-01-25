using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    public class Easy_Switchbutton : IEasyInputState
    {
        public void ToTagBuilder(EasyInputBuilder _this)
        {
            _this.TagBuilder.AddCssClass("easyui-switchbutton");
            #region 设置 dataoptions
            List<string> dataoptions = new List<string>();
            if (_this.HtmlAttributes.ContainsKey("dataoptions"))
                dataoptions.AddRange(_this.HtmlAttributes["dataoptions"].ToString().Split(','));

            dataoptions.Add(string.Format("{0} : '{1}'", "onText", _this.ModelMetadata.AdditionalValues["EasySwitchbutton_OnText"].ToString()));
            dataoptions.Add(string.Format("{0} : '{1}'", "offText", _this.ModelMetadata.AdditionalValues["EasySwitchbutton_OffText"].ToString()));
            dataoptions.Add(string.Format("{0} : '{1}'", "value", _this.ModelMetadata.AdditionalValues["EasySwitchbutton_Value"].ToString()));

            //设置选中状态
            if (_this.Model != null) {
                bool _checked = true;
                if (_this.Model.ToString().IsConvert<bool>(x => x == false))
                    _checked = false;
                dataoptions.Add(string.Format("{0} : '{1}'", "checked", _checked.AsString()));
            }
            if (dataoptions.Any())
            {
                _this.TagBuilder.MergeAttribute("data-options", dataoptions.JoinToString(), true);
            }
            #endregion
        }
    }
}
