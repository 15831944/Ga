using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;

namespace PM2.WebApp.Areas.Code001.Controllers
{
    public class sdey001Controller : Controller
    {
        private Isdey001Server _sdey001Server;
        public sdey001Controller(Isdey001Server sdey001Server)
        {
            this._sdey001Server = sdey001Server;
        }

        /// <summary>
        /// 获取所有账套信息
        /// </summary>
        /// <returns></returns>
        [IgnoreAuthorizationLogin]
        public ActionResult GetList()
        {
            return this._sdey001Server.GetList()
                       .ToActionResult(this.ControllerContext);
        }

    }
}