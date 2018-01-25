using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Gmail.DDD.Extensions;
using Gmail.DDD.Helper;
using System.Linq.Expressions;

namespace PM2.Code
{
    public abstract class HTMLBuilderBase : IHtmlBuilder
    {
        /// <summary>
        /// 字段元数据
        /// </summary>
        public ModelMetadata ModelMetadata { get; private set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 属性数值
        /// </summary>
        public object Model { get; private set; }

        /// <summary>
        /// 附加属性值 new { }
        /// </summary>
        public IDictionary<string, object> HtmlAttributes { get; private set; }

        #region IHtmlBuilder
        public MvcHtmlString HtmlBuilder<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null)
        {
            #region 初始化基本信息
            this.ModelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            this.Name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            this.Model = this.ModelMetadata.Model;
            this.HtmlAttributes = htmlHelper.ViewData;
            if (htmlAttributes != null)
            {
                var query = from x in HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)
                            where !this.HtmlAttributes.ContainsKey(x.Key)
                            select new KeyValuePair<string, object>(x.Key, x.Value);
                foreach (var item in query)
                {
                    this.HtmlAttributes.Add(item);
                }
            }
            #endregion
            return this.Create(htmlHelper, expression, htmlAttributes);

        }
        public MvcHtmlString HtmlBuilder(HtmlHelper htmlHelper, ViewDataDictionary viewData, object htmlAttributes = null)
        {
            #region 初始化基本信息
            this.ModelMetadata = viewData.ModelMetadata;
            this.Name = this.ModelMetadata.AdditionalValues["Name"].ToString();
            this.Model = this.ModelMetadata.Model;
            if (htmlAttributes != null)
            {
                this.HtmlAttributes = htmlAttributes.AnonymousConvertTo<VP>((x, y) =>
                {
                    return new VP
                    {
                        Name = x,
                        Value = y
                    };
                }).ToDictionary(k => k.Name, v => v.Value);
            }
            else
                this.HtmlAttributes = viewData;
            #endregion
            return this.Create(htmlHelper, htmlAttributes);
        }
        #endregion

        
        /// <summary>
        /// 创建 MvcHtmlString
        /// </summary>
        protected abstract MvcHtmlString Create<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null);

        /// <summary>
        /// 创建 MvcHtmlString
        /// </summary>
        protected abstract MvcHtmlString Create(
            HtmlHelper htmlHelper,
            object htmlAttributes = null);

        private class VP
        {
            public string Name { get; set; }
            public Object Value { get; set; }
        }

        
    }

}
