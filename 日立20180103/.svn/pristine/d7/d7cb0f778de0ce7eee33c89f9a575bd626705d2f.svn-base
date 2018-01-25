using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    public class Easy_Textbox : IEasyInputState
    {
        /// <summary>
        /// 生成控件
        /// </summary>
        /// <param name="_this"></param>
        public void ToTagBuilder(EasyInputBuilder _this)
        {
            _this.TagBuilder.AddCssClass("easyui-textbox");
            #region 设置 dataoptions
            List<string> dataoptions = new List<string>();
            if (_this.HtmlAttributes.ContainsKey("dataoptions"))
                dataoptions.AddRange(_this.HtmlAttributes["dataoptions"].ToString().Split(','));

            //设置数据值 
            if (_this.Model != null)
                dataoptions.Add(string.Format("value : '{0}'", _this.Model.ToString()));

            if (dataoptions.Any())
            {
                _this.TagBuilder.MergeAttribute("data-options", dataoptions.JoinToString(), true);
            }
            #endregion
            
        }
    }
}
