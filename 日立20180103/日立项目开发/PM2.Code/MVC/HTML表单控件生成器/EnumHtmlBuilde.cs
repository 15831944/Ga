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
    /// <summary>
    /// 枚举模板
    /// </summary>
    public class EnumHtmlBuilde : HTMLBuilderBase
    {
        protected override MvcHtmlString Create<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            return htmlHelper.DropDownListFor(expression, this.GetListItem(), htmlAttributes);
        }
        protected override MvcHtmlString Create(HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            return htmlHelper.DropDownList(this.Name, this.GetListItem(), htmlAttributes);
        }

        private IEnumerable<System.Web.Mvc.SelectListItem> GetListItem()
        {
            var query = from x in GmailHelper.EnumContext(this.ModelMetadata.ModelType)
                        select new System.Web.Mvc.SelectListItem
                        {
                            Selected = (this.Model != null) ? (x.Value.Equals(this.Model.ToString())) : false,
                            Value = x.Key.ToString(),
                            Text = x.Description
                        };

            return new List<System.Web.Mvc.SelectListItem>(query);
        }

    }
}
