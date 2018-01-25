using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    public abstract class Easy_Numberbox : IEasyInputState
    {
        public void ToTagBuilder(EasyInputBuilder _this)
        {
            _this.TagBuilder.AddCssClass("easyui-numberspinner");
            #region 设置 dataoptions
            Dictionary<string, string> dataoptions = new Dictionary<string, string>();
            if (_this.HtmlAttributes.ContainsKey("dataoptions"))
            {
                var query = from x in _this.HtmlAttributes["dataoptions"].ToString().Split(',')
                            let p1 = x.Substring(0, x.IndexOf(":"))
                            let p2 = x.Substring(x.IndexOf(":") + 1)
                            select new KeyValuePair<string, string>(p1, p2);
                foreach (var item in query)
                {
                    dataoptions.Add(item);
                }
            }
            //设置数据值 
            if (_this.Model != null)
                dataoptions.Add("value", _this.Model.ToString());

            this.SetDataOptions(_this, dataoptions);
            if (dataoptions.Any())
            {
                var query = from x in dataoptions.ForEach()
                            let v = string.Format("{0}:{1}", x.Item1.Key, x.Item1.Value)
                            select v;
                _this.TagBuilder.MergeAttribute("data-options", query.JoinToString(), true);
            }
            #endregion
        }
        protected abstract void SetDataOptions(EasyInputBuilder _this, Dictionary<string, string> dataoptions);

    }
}
