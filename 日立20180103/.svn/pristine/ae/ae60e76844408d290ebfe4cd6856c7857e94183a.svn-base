using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM2.Models.Code030;
using PM2.Service.Code030;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Service.Code001;
using Gmail.DDD.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class sdbo001Controller : Controller
    {
        private Isdbo001Server _sdbo001Server;
        //private Iszrl001Server _szrl001Server;
        public sdbo001Controller(Isdbo001Server sdbo001Server)
        {
            
            this._sdbo001Server = sdbo001Server;
           // this._szrl001Server = szrl001Server;
        }
        
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult GetIndexInfo(HttpCollection content)
        {
            return this._sdbo001Server.GetIndexInfo(content)
                .ToActionResult(this.ControllerContext);
        }
        public ActionResult Add(Staffing_sdbo001 sf,HttpCollection context)
        {
            return this._sdbo001Server.Add(sf, context)
                .ToActionResult(this.ControllerContext);
        }
        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public ActionResult List_sdpj004(PageCollection context)
        {
            var list = this._sdbo001Server.List_sdpj004(context);
            return Json(list);
        }
        public ActionResult List_sdpj004_2()
        {
            var list = this._sdbo001Server.List_sdpj004_2();
            return Json(list);
        }
        public ActionResult List_sdpj004_3(PageCollection context)
        {
            return this._sdbo001Server.List_sdpj004_3(context)
              .ToActionResult(this.ControllerContext);
        }


    }
}