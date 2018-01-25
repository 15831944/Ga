using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using PM2.Service.Code019;
using Gmail.DDD.PagedList;
using Gmail.DDD.Service;

namespace PM2.WebApp.Areas.Code019.Controllers
{
    public class sdpk007Controller : Controller
    {
        private Isdpk007Server _sdpk007Server;
        public sdpk007Controller(Isdpk007Server sdpk007Server)
        {
            this._sdpk007Server = sdpk007Server;
        }

        /// <summary>
        /// 获取附件信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModels(PageCollection context)
        {
            return this._sdpk007Server.GetModels(context, context.GetValue<string>("pk"))
                       .ToActionResult(this.ControllerContext);
        }

        /// <summary>
        /// 附件删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Remove([JsonModelBinder]string[] pks)
        {
            return this._sdpk007Server.Remove(pks)
                       .ToActionResult(this.ControllerContext);
        }

    }
}