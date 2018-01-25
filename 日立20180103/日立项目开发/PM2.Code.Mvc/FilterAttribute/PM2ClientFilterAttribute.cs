using Gmail.DDD.AOP;
using Gmail.DDD.Config;
using Gmail.DDD.Helper;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Extensions;

namespace PM2.Code
{
    /// <summary>
    /// SSO单点登录[业务网站]
    /// </summary>
    public sealed class PM2ClientFilterAttribute : BeforeExecuteAttribute
    {
        public PM2ClientFilterAttribute()
            :base(true)
        {

        }
        protected override void ActionExecute(MethodContext context)
        {
            object loginCore = context.InArgs.SingleOrDefault(x => x.ParameterName.Equals("loginCore")).Value;
            object account = context.InArgs.SingleOrDefault(x => x.ParameterName.Equals("account")).Value;
            object backUrl = context.InArgs.SingleOrDefault(x => x.ParameterName.Equals("backUrl")).Value;
            if (loginCore != null && account != null && backUrl != null)
            {
                context.ReturnValue = this.Login(loginCore.ToString(), account.ToString(), backUrl.ToString());
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private IOperateResult Login(string loginCore, string account, string backUrl)
        {
            #region 用户登录
            PM2.Models.Code001.LoginModel model = new PM2.Models.Code001.LoginModel { LoginCode = HttpUtility.HtmlDecode(loginCore), Account = account, BackUrl = HttpUtility.HtmlDecode(backUrl).Replace("PM2SSOURI", "") };
            ILogin _login = DependencyConfig.Instance.Container.ResolveNamed<ILogin>(Auto_ILogin.LoginTempDbCon);
            IOperateResult loginResult = _login.LoginAsync(model).Result;
            if (loginResult.GetResultType<LoginOperateResultType>() == LoginOperateResultType.Success)
            {
                return new RedirectOperateResult(model.BackUrl);
            }
            return loginResult;
            #endregion
        }

    }
}
