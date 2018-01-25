using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using Gmail.DDD.Service;
using PM2.Code;
using PM2.Models.Code100;
using PM2.Service.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl001Controller : Controller
    {
        // GET: AreasCode030/szrl001
        private IEasyTree _serverTree;
        public szrl001Controller(Autofac.Features.Indexed.IIndex<Auto_TreeType, IEasyTree> serverTrees)
        {
            this._serverTree = serverTrees[Auto_TreeType.szrl001Tree];
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 生成作番树
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeLoad(HttpCollection vParams)
        {
            return this._serverTree.TreeLoad(vParams).ToActionResult(this.ControllerContext);
        }
    }
}