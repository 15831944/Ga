using Gmail.DDD.AOP;
using Gmail.DDD.Config;
using Gmail.DDD.Helper;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using Gmail.DDD.Extensions;
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
using Gmail.DDD.From;

namespace PM2.Code
{
    /// <summary>
    /// SSO单点登录[分站验证机制]
    /// </summary>
    public class SSOActionFilterAttribute : SSOClientFilterAttribute
    {
        protected override IOperateResult Login(string fromUserData)
        {
            //解析用户凭证
            FromUserData userData = SerializeMemoryHelper.DeserializeFromJson<Gmail.DDD.From.FromUserData>(fromUserData);
            #region 用户登录
            PM2.Models.Code001.LoginModel model = new Models.Code001.LoginModel { LoginCode = userData.LoginCore, Account = userData.Account };
            ILogin _login = DependencyConfig.Instance.Container.ResolveNamed<ILogin>(Auto_ILogin.LoginTempDbCon);
            IOperateResult loginResult = _login.LoginAsync(model).Result;
            if (loginResult.GetResultType<LoginOperateResultType>() == LoginOperateResultType.Success)
            {
                return new RedirectOperateResult(System.Web.Security.FormsAuthentication.DefaultUrl);
            }
            return loginResult;
            #endregion
            
        }
    }
}
