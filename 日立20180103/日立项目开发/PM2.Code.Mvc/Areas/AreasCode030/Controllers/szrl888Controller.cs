using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Service.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl888Controller : Controller
    {
        private Iszrl888Server _szrl888Server;
        public szrl888Controller(Iszrl888Server _szrl888Server)
        {
            this._szrl888Server = _szrl888Server;
        }
        // GET: AreasCode030/szrl888
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public async Task<ActionResult> Edit(string vid)
        {
            IOperateResult result = await this._szrl888Server.editinfo(vid);
            return result.ToActionResult(this.ControllerContext);
        }
        #region 方法
        public async Task<ActionResult> info(PageCollection context)
        {
            IOperateResult result = await this._szrl888Server.info(context);
            return result.ToActionResult(this.ControllerContext);
        }
        public async Task<ActionResult> fn_add(szrl888 _szrl888)
        {
            IOperateResult result = await this._szrl888Server.add(_szrl888);
            return result.ToActionResult(this.ControllerContext);
        }
        public async Task<ActionResult> fn_edit(szrl888 _szrl888)
        {
            IOperateResult result = await this._szrl888Server.edit(_szrl888);
            return result.ToActionResult(this.ControllerContext);
        }
        public async Task<ActionResult> Remove(string vid)
        {
            IOperateResult result = await this._szrl888Server.remove(vid);
            return result.ToActionResult(this.ControllerContext);
        }

        public async Task<ActionResult> GetModuleWeb()
        {
            IOperateResult result = await this._szrl888Server.GetModuleWeb();
            return result.ToActionResult(this.ControllerContext);
        }
        #endregion

    }
}