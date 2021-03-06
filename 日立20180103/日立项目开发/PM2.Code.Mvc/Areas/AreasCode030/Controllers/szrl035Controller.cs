﻿using Gmail.DDD.Extensions;
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
    public class szrl035Controller : Controller
    {
        private Iszrl035Server _szrl035Server;
        public szrl035Controller(Iszrl035Server szrl035Server)
        {
            this._szrl035Server = szrl035Server;
        }

        // GET: AreasCode030/szrl035
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditLst(HttpCollection vParams)
        {
            List<szrl035BasicData> query = this._szrl035Server.QueryBasicData(vParams).ToList();
            if (query.Count() > 0)
            {
                ViewData["rl03503"] = query[0].rl03503;
                ViewData["rl01806"] = query[0].rl01806;
                ViewData["rl01802"] = query[0].rl01802;
                ViewData["rl01807"] = query[0].rl01807;
                ViewData["rl03508"] = query[0].rl03508;
            }
            ViewData["zuofanid"] = vParams.GetValue<string>("zuofanid");
            ViewData["plysid"] = vParams.GetValue<string>("plysid");
            return View();
        }

        [HttpPost]
        public ActionResult QueryGridData(HttpCollection vParams)
        {
            return this._szrl035Server.QueryGridData(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult QueryYSJHGridData(HttpCollection vParams)
        {
            return this._szrl035Server.QueryYSJHGridData(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult QueryPLYSDJGridData(HttpCollection vParams)
        {
            return this._szrl035Server.QueryPLYSDJGridData(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult Insert3536(HttpCollection vParams)
        {
            return this._szrl035Server.Insert3536(vParams)
              .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult Query036GridData(HttpCollection vParams)
        {
            return this._szrl035Server.Query036GridData(vParams)
             .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult DelGridData(HttpCollection vParams)
        {
            return this._szrl035Server.DelGridData(vParams)
           .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult AdmitPLYSDJData(HttpCollection vParams)
        {
            return this._szrl035Server.AdmitPLYSDJData(vParams)
          .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult SCKPTZ_035(HttpCollection vParams)
        {
            return this._szrl035Server.SCKPTZ_035(vParams)
          .ToActionResult(this.ControllerContext);
        }
    }
}