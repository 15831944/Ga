using Gmail.DDD.Extensions;
using PM2.Code;
using PM2.Models.Code100;
using PM2.Service.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM2.Models.Code030;
using Gmail.DDD.Service;
using Gmail.DDD.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl030Controller : Controller
    {
        private Iszrl030Server _szrl030Server;
        public szrl030Controller(Iszrl030Server szrl030Server)
        {
            this._szrl030Server = szrl030Server;
        }


        // GET: AreasCode030/szrl030
        public ActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult QueryBasicData(HttpCollection vParams)
        { 
            return this._szrl030Server.QueryBasicData(vParams)
              .ToActionResult(this.ControllerContext); 
        }
         
        [HttpPost]
        public ActionResult QueryGridData(HttpCollection vParams)
        {
            return this._szrl030Server.QueryGridData(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult QueryKXXZ(HttpCollection vParams)
        {
            return this._szrl030Server.QueryKXXZ(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult Insert3032(HttpCollection vParams)
        {
            return this._szrl030Server.Insert3032(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult Insert2224(HttpCollection vParams)
        {
            return this._szrl030Server.Insert2224(vParams)
            .ToActionResult(this.ControllerContext);
        }
    }
}