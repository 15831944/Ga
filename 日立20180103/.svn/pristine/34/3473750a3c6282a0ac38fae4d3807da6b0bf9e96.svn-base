using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Gmail.DDD.Extensions;
using Gmail.DDD.Helper;

namespace PM2.Code
{
    /// <summary>
    /// Input 类型控件
    /// </summary>
    public class EasyInputBuilder : HTMLBuilderBase
    {
        /// <summary>
        /// 控件生成器
        /// </summary>
        public TagBuilder TagBuilder
        {
            private set;
            get;
        }
        #region 生成HTML
        protected override MvcHtmlString Create<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return this.InitTagBuilder();
        }
        protected override MvcHtmlString Create(HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            return this.InitTagBuilder();
        }
        #endregion

        #region private
        private MvcHtmlString InitTagBuilder()
        {
            this.TagBuilder = new TagBuilder("input");
            this.TagBuilder.MergeAttribute("id", this.Name, true);
            this.TagBuilder.MergeAttribute("name", this.Name, true);
            #region 标签设置
            if (!string.IsNullOrEmpty(this.ModelMetadata.DisplayName))
            {
                string lable = "{0}label:'{1}'";
                if (this.HtmlAttributes.ContainsKey("dataoptions"))
                    this.HtmlAttributes["dataoptions"] = this.HtmlAttributes["dataoptions"].ToString() + string.Format(lable, ",", this.ModelMetadata.DisplayName);
                else
                    this.HtmlAttributes.Add("dataoptions", string.Format(lable, "", this.ModelMetadata.DisplayName));
            }
            #endregion
            if (this.HtmlAttributes.ContainsKey("style"))
                this.TagBuilder.MergeAttribute("style", this.HtmlAttributes["style"].ToString(), true);

            //状态转化
            IEasyInputState easyState = null;
            Auto_EasyInputState inputState = Auto_EasyInputState.None;
            if (!this.ModelMetadata.TemplateHint.IsConvert<Auto_EasyInputState>(x =>
            {
                inputState = this.ModelMetadata.TemplateHint.ConvertTo<Auto_EasyInputState>();
                easyState = DependencyConfig.Instance.Container.ResolveNamed<IEasyInputState>(inputState);
                return true;
            }))
                throw new NotImplementedException();

            easyState.ToTagBuilder(this);
            //生成控件
            string input = this.TagBuilder.ToString(TagRenderMode.SelfClosing);
            return MvcHtmlString.Create(input);
        }
        #endregion
        
    }
}
