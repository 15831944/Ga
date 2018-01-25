using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    public class Easy_Passwordbox : IEasyInputState
    {
        public void ToTagBuilder(EasyInputBuilder _this)
        {
            _this.TagBuilder.AddCssClass("easyui-passwordbox");
            #region 设置 dataoptions
            List<string> dataoptions = new List<string>();
            if (_this.HtmlAttributes.ContainsKey("dataoptions"))
                dataoptions.AddRange(_this.HtmlAttributes["dataoptions"].ToString().Split(','));

            dataoptions.Add(string.Format("required : '{0}'", true));
            dataoptions.Add(string.Format("showEye : '{0}'", true));
            dataoptions.Add(string.Format("prompt : '{0}'", "********"));
            dataoptions.Add(string.Format("iconWidth : '{0}'", 26));

            if (dataoptions.Any())
            {
                _this.TagBuilder.MergeAttribute("data-options", dataoptions.JoinToString(), true);
            }
            #endregion

        }

    }
}
