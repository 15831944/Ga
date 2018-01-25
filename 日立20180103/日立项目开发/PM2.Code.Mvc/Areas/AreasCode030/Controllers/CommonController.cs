using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 目录树
        /// </summary>
        /// <returns></returns>
        public ActionResult NavTree()
        {
            return View();
        }


    }
}