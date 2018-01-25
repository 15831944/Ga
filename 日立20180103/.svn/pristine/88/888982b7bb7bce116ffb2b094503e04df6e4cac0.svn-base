using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using PM2.Service.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class sdbo004Controller : Controller
    {
        // GET: AreasCode030/sdbo004
        private Isdbo004Server _sdbo004Server;
        public sdbo004Controller(Isdbo004Server _sdbo004Server)
        {
            this._sdbo004Server = _sdbo004Server;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ActionResult GetIndexInfo(HttpCollection context)
        {
            return this._sdbo004Server.GetIndexInfo(context)
                 .ToActionResult(this.ControllerContext);
        }

    }
}