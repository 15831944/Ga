using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using Gmail.DDD.AOP;
using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using PM2.Service.Code001;
using Autofac.Features.Indexed;
using System.Threading.Tasks;

namespace PM2.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IIndex<Auto_ILoginOut, ILoginOut> _loginOuts;
        public HomeController(IIndex<Auto_ILoginOut, ILoginOut> loginOuts)
        {
            this._loginOuts = loginOuts;
        }

        #region 用户登出-主站
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            ILoginOut loginOut = this._loginOuts[Auto_ILoginOut.LoginOut];
            return loginOut.LoginOut().ToActionResult(this.ControllerContext);
        }
        #endregion
        #region 用户登出-分站
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [IgnoreAuthorizationLogin]
        public ActionResult SSOLoginOut()
        {
            ILoginOut loginOut = this._loginOuts[Auto_ILoginOut.SSOLoginOut];

            // 测试先屏蔽，先转到主页，不用单点
            ///return loginOut.LoginOut().ToActionResult(this.ControllerContext);
            ///

            loginOut.LoginOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

    }
}