using Gmail.DDD.SSO;
using Gmail.DDD.Extensions;
using PM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Service;
using PM2.Service.Code001;
using PM2.Models.Code001;
using PM2.Code;
using Gmail.DDD.Helper;
using Gmail.DDD.Mvc;
using Gmail.DDD.From;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.IO;
using Newtonsoft.Json.Linq;

namespace PM2.WebApp.Controllers
{
    [IgnoreAuthorizationLogin]
    public class LoginController : Controller
    {
        private ILogin _login;
        public LoginController(Autofac.Features.Indexed.IIndex<Auto_ILogin, ILogin> logins)
        {
            this._login = logins[Auto_ILogin.SSOUserLogin];
        }

        #region 主站点(服务端登陆)
        /// <summary>
        /// 全站统一登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string BackUrl)
        {
            if (string.IsNullOrEmpty(BackUrl))
            {
                if (HttpHelper.Request.IsAuthenticated)
                {
                    //自动登录: 默认设置[SSO 临时主站令牌Cookie]
                    SSOProviderConfig.Instance.Login(FormsAuthenticationHelper.FromUserData, null);
                    return new RedirectResult(System.Web.Security.FormsAuthentication.DefaultUrl);

                }
            }
            return View(new LoginModel { RememBerMe = true });
        }

        /// <summary>
        /// 登陆提交
        /// </summary>
        /// <returns></returns>
        //[HttpAjax]
        [HttpPost]
        public async Task<ActionResult> UserLoginAsync(LoginModel loginMode) //[JsonModelBinder("data")]LoginModel loginMode | AjaxCollection data 流只能读取一次
        {
            IOperateResult oResult = await this._login.LoginAsync(loginMode);
            return oResult.ToActionResult(this.ControllerContext);
        }
        #endregion
        #region 分站 - SSO登录入口
        [SSOActionFilter]
        public ActionResult SSOIndex()
        {
            return null;
        }
        #endregion
        #region PM2 - 临时对接
        [PM2ClientFilterAttribute]
        public ActionResult Pm2Index(string loginCore, string account, string backUrl)
        {
            return null;
        }
        #endregion
    }
}