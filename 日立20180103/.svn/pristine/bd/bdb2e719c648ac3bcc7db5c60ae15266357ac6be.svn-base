using Gmail.DDD.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM2.Code
{
    /// <summary>
    /// HTML-控件生成器
    /// </summary>
    public interface IHtmlBuilder : IScopeDependency
    {
        /// <summary>
        /// 字段元数据
        /// </summary>
        ModelMetadata ModelMetadata { get; }

        /// <summary>
        /// 属性名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 属性数值
        /// </summary>
        object Model { get; }

        /// <summary>
        /// 附加属性值 new { }
        /// </summary>
        IDictionary<string, object> HtmlAttributes { get; }

        #region 生成控件
        MvcHtmlString HtmlBuilder<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null);

        MvcHtmlString HtmlBuilder(
            HtmlHelper htmlHelper,
            ViewDataDictionary viewData,
            object htmlAttributes = null);
        #endregion
        
    }
}
