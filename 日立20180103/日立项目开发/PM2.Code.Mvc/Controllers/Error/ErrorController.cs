using Gmail.DDD.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Controllers.Error
{
    [IgnoreAuthorizationLogin]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error_404()
        {
            return View();
        }
        public ActionResult Error_500()
        {
            return View();
        }
    }
}