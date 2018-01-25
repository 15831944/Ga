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
using PM2.Models.Code100;

namespace PM2.WebApp.Areas.Code031.Controllers
{
    public class szrl105TreeController : Controller
    {
        private IEasyTree _szrl001Tree;
        private IEasyTreeExtensions _serverTreeExtension;
        public szrl105TreeController(
            Autofac.Features.Indexed.IIndex<Auto_TreeType, IEasyTree> serverTrees,
            Autofac.Features.Indexed.IIndex<Auto_TreeType, IEasyTreeExtensions> serverTreeExtensions
            )
        {
            this._szrl001Tree = serverTrees[Auto_TreeType.szrl001Tree];
            this._serverTreeExtension = serverTreeExtensions[Auto_TreeType.szrl105Tree];
            this._szrl001Tree.SetTreeExtensions(this._serverTreeExtension);
        }
        public ActionResult TreeLoad(HttpCollection vParams)
        {
            return this._szrl001Tree.TreeLoad(vParams).ToActionResult(this.ControllerContext);
        }
    }
}