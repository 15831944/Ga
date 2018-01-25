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
using Gmail.DDD.JsonConvert;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl130Controller : Controller
    {
        private Iszrl130Server _szrl130Server;
        private IEasyTree _serverTree;
        public szrl130Controller(Iszrl130Server szrl130Server, Autofac.Features.Indexed.IIndex<Auto_TreeType, IEasyTree> serverTrees)
        {
            this._szrl130Server = szrl130Server;
            this._serverTree = serverTrees[Auto_TreeType.szrl105Tree];
        }

        // GET: AreasCode030/szrl130
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult QueryGridDataFor130(HttpCollection vParams)
        {
            return this._szrl130Server.QueryGridDataFor130(vParams)
                 .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult QueryTopGridDataFor130(HttpCollection vParams)
        { 
            return this._szrl130Server.QueryTopGridDataFor130(vParams)
                 .ToActionResult(this.ControllerContext);
        }

        [HttpPost]
        public ActionResult DelBBH(HttpCollection vParams)
        {
            return this._szrl130Server.DelBBH(vParams)
                 .ToActionResult(this.ControllerContext);
        }
        [HttpPost]
        public ActionResult Insert131(HttpCollection vParams)
        {
            return this._szrl130Server.Insert131(vParams)
                 .ToActionResult(this.ControllerContext);
        }
        [HttpPost]
        public ActionResult AdmitByYSCL(HttpCollection vParams)
        {
            return this._szrl130Server.AdmitByYSCL(vParams)
                 .ToActionResult(this.ControllerContext);
        }
        [HttpPost]
        public ActionResult AdmitByPayPlan(HttpCollection vParams)
        {
            return this._szrl130Server.AdmitByPayPlan(vParams)
                 .ToActionResult(this.ControllerContext);
        }
        [HttpPost]
        public ActionResult IsCanChanges(HttpCollection vParams)
        {
            return this._szrl130Server.IsCanChanges(vParams)
                 .ToActionResult(this.ControllerContext);
        }
    }
}