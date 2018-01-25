using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using PM2.Code;
using PM2.Models.Code100;
using System.Threading.Tasks;
using Gmail.DDD.Service;

namespace PM2.WebApp.Areas.Code001.Controllers
{
    public class sdpj025Controller : Controller
    {
        private IEasyTreeAsync _sdpj025Tree;
        public sdpj025Controller(Autofac.Features.Indexed.IIndex<Auto_TreeType, IEasyTreeAsync> serverTrees)
        {
            this._sdpj025Tree = serverTrees[Auto_TreeType.sdpj025Tree];
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成部门树
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> TreeLoad()
        {
            IOperateResult oResult = await this._sdpj025Tree.TreeLoadAsync();
            return oResult.ToActionResult(this.ControllerContext);
        }

    }
}