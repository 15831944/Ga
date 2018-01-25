using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gmail.DDD.Extensions;
using Gmail.DDD.Helper;

namespace PM2.Code
{
    public static class HtmlBuildeExtensions
    {
        #region Easy_Input
        #region HtmlHelper<TModel>
        public static MvcHtmlString EasyInputFor<TModel, TProperty>(
           this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TProperty>> expression
        )
        {
            IHtmlBuilder builder = DependencyConfig.Instance.Container.ResolveNamed<IHtmlBuilder>(Auto_ControlType.EasyInputBuilder);
            return builder.HtmlBuilder<TModel, TProperty>(htmlHelper, expression, null);
        }
        #endregion
        #region HtmlHelper
        #region Easy_Textbox
        public static MvcHtmlString Easy_Textbox(
            this HtmlHelper htmlHelper,
            string name,
            Object htmlAttributes = null)
        {
            return Easy_Textbox(htmlHelper, null, name, htmlAttributes);
        }
        public static MvcHtmlString Easy_Textbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            Object htmlAttributes = null)
        {
            return Easy_Textbox(htmlHelper, lable, name, "", htmlAttributes);
        }
        public static MvcHtmlString Easy_Textbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            string value,
            Object htmlAttributes = null)
        {
            return htmlHelper.EasyInput(Auto_EasyInputState.Easy_Textbox, lable, name, value, htmlAttributes, null);
        }
        #endregion
        #region Easy_Numberbox
        public static MvcHtmlString Easy_Numberbox(
            this HtmlHelper htmlHelper,
            string name,
            Object htmlAttributes = null
        )
        {
            return Easy_Numberbox(htmlHelper, null, name, htmlAttributes);
        }
        public static MvcHtmlString Easy_Numberbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            Object htmlAttributes = null
        )
        {
            return Easy_Numberbox(htmlHelper, lable, name, 0, htmlAttributes);
        }
        public static MvcHtmlString Easy_Numberbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            int value,
            Object htmlAttributes = null
        )
        {
            return htmlHelper.EasyInput(Auto_EasyInputState.Easy_Numberbox_Int32, lable, name, value, htmlAttributes, null);
        }


        public static MvcHtmlString Easy_MNumberbox(
            this HtmlHelper htmlHelper,
            string name,
            Object htmlAttributes = null
        )
        {
            return Easy_MNumberbox(htmlHelper, null, name, htmlAttributes);
        }
        public static MvcHtmlString Easy_MNumberbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            Object htmlAttributes = null
        )
        {
            return Easy_MNumberbox(htmlHelper, lable, name, 0M, htmlAttributes);
        }
        public static MvcHtmlString Easy_MNumberbox(
            this HtmlHelper htmlHelper,
            string lable,
            string name,
            decimal value,
            Object htmlAttributes = null
        )
        {
            return htmlHelper.EasyInput(Auto_EasyInputState.Easy_Numberbox_Decimal, lable, name, value, htmlAttributes, null);
        }
        #endregion
        #region Easy_Combobox
        public static MvcHtmlString Easy_Combobox(
           this HtmlHelper htmlHelper,
           string name,
           string url,
           Object htmlAttributes = null
        )
        {
            return Easy_Combobox(htmlHelper, null, name, url, htmlAttributes);
        }
        public static MvcHtmlString Easy_Combobox(
           this HtmlHelper htmlHelper,
           string lable,
           string name,
           string url,
           Object htmlAttributes = null
        )
        {
            return htmlHelper.EasyInput(Auto_EasyInputState.Easy_Numberbox_Decimal, lable, name, url, htmlAttributes, (x) => { x.Add("EasyComboboxRemote_LoadUrl", url); });
        }


        public static MvcHtmlString Easy_Combobox<TEnum>(
           this HtmlHelper htmlHelper,
           string name,
           Object htmlAttributes = null
        )
        {
            return Easy_Combobox<TEnum>(htmlHelper, null, name, htmlAttributes);
        }
        public static MvcHtmlString Easy_Combobox<TEnum>(
           this HtmlHelper htmlHelper,
           string lable,
           string name,
           Object htmlAttributes = null
        )
        {
            return htmlHelper.EasyInput(Auto_EasyInputState.Easy_Numberbox_Decimal, lable, name, default(TEnum), htmlAttributes, null);
        }
        #endregion

        private static MvcHtmlString EasyInput(this HtmlHelper htmlHelper, Auto_EasyInputState vType, string lable, string name, object value, Object htmlAttributes, Action<ViewDataDictionary> Action)
        {
            IHtmlBuilder builder = DependencyConfig.Instance.Container.ResolveNamed<IHtmlBuilder>(Auto_ControlType.EasyInputBuilder);
            ViewDataDictionary o = new ViewDataDictionary(value);
            o.ModelMetadata.TemplateHint = vType.ToString();
            if (!string.IsNullOrEmpty(lable))
                o.ModelMetadata.DisplayName = lable;

            o.ModelMetadata.AdditionalValues.Add("Name", name);
            if (Action != null)
                Action.Invoke(o);
            return builder.HtmlBuilder(htmlHelper, o, htmlAttributes);
        }
        #endregion
        #endregion
        #region Enum_DropDownList
        public static MvcHtmlString New_EnumDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression
        )
        {
            IHtmlBuilder builder = DependencyConfig.Instance.Container.ResolveNamed<IHtmlBuilder>(Auto_ControlType.EnumHtmlBuilde);
            return builder.HtmlBuilder<TModel, TProperty>(htmlHelper, expression, null);

        }
        #endregion
    }
}
