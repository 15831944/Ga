using Gmail.DDD.Helper;
using Gmail.DDD.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code
{
    public class Easy_Combobox : IEasyInputState
    {
        public void ToTagBuilder(EasyInputBuilder _this)
        {
            _this.TagBuilder.AddCssClass("easyui-combobox");
            #region 设置 dataoptions
            List<string> dataoptions = new List<string>();
            if (_this.HtmlAttributes.ContainsKey("dataoptions"))
                dataoptions.AddRange(_this.HtmlAttributes["dataoptions"].ToString().Split(','));

            dataoptions.Add(string.Format("editable : {0}", "false"));
            dataoptions.Add(string.Format("valueField : '{0}'", "id"));
            dataoptions.Add(string.Format("textField : '{0}'", "text"));

            #region 远程加载数据
            if (_this.ModelMetadata.AdditionalValues.ContainsKey("EasyComboboxRemote_LoadUrl"))
            {
                dataoptions.Add(string.Format("mode : '{0}'", "remote"));
                dataoptions.Add(string.Format("url : '{0}'", _this.ModelMetadata.AdditionalValues["EasyComboboxRemote_LoadUrl"].ToString()));
            }
            #endregion
            #region 本地加载数据
            else
            {
                dataoptions.Add(string.Format("mode : '{0}'", "local"));
                var query = from x in GmailHelper.EnumContext(_this.ModelMetadata.ModelType)
                            select new
                            {
                                id = x.Key.ToString(),
                                text = x.Description,
                                selected = (_this.Model != null) ? (x.Value.Equals(_this.Model.ToString())) : false
                            };
                List<object> items = new List<object>(query);
                dataoptions.Add(string.Format("data : {0}", SerializeMemoryHelper.SerializeToJson(items)));

            }
            #endregion
            
            if (dataoptions.Any())
            {
                _this.TagBuilder.MergeAttribute("data-options", dataoptions.JoinToString(), true);
            }
            #endregion

        }
    }
}
