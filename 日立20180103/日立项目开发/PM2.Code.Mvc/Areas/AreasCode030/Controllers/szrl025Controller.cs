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
    public class szrl025Controller : Controller
    {
        private Iszrl025Server _szrl025Server;
        private Autofac.Features.Indexed.IIndex<Auto_ExcelType, IExcelExportServer> _exports;
        public szrl025Controller(Iszrl025Server szrl025Server, Autofac.Features.Indexed.IIndex<Auto_ExcelType, IExcelExportServer> exports)
        {
            this._szrl025Server = szrl025Server;
            this._exports = exports;
        }
        public ActionResult Index(HttpCollection context)
        {
            ViewBag.zuofanid= context.GetValue<string>("zuofanid");
            ViewBag.versionNumber = context.GetValue<string>("versionNumber");
            ViewBag.szrl018 = new szrl018();
            return View(new szrl025());
        }
        //[ActionName("ActionIndex")]
        //public ActionResult Index(HttpCollection context)
        //{
        //    return this._szrl025Server.GetForsomeInfo(context).ToActionResult(this.ControllerContext);
        //}
        public ActionResult GetIndexInfo(HttpCollection context)
        {
            return this._szrl025Server.GetForsomeInfo(context).ToActionResult(this.ControllerContext);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public ActionResult Add(szrl025 szrl025)
        {
            return this._szrl025Server.Add(szrl025)
                        .ToActionResult(this.ControllerContext);
        }
        public ActionResult Update([JsonModelBinder]szrl025 szrl025)
        {
            return null;
        }
        public ActionResult DInjectionVouche()
        {
            return View();
        }
        /// <summary>
        /// 承认
        /// </summary>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public ActionResult Recognize(szrl025 szrl025)
        {
            return this._szrl025Server.Recognize(szrl025)
                       .ToActionResult(this.ControllerContext);
        }
        public ActionResult SelectIsRecognize(szrl025 szrl025)
        {
            return this._szrl025Server.SelectIsRecognize(szrl025)
                       .ToActionResult(this.ControllerContext);
        }
        public ActionResult OpenContract(string rl02501)
        {
            ViewBag.rl02501 = rl02501;
            return View();
        }
        /// <summary>
        /// 查询作番下的合同
        /// </summary>
        /// <param name="rl02501"></param>
        /// <returns></returns>
        public ActionResult SelectContract(PageCollection context)
        {
            return this._szrl025Server.GetSzrl019Info(context)
                       .ToActionResult(this.ControllerContext);
        }
        /// <summary>
        /// 查询明细表格
        /// </summary>
        /// <param name="rl02501"></param>
        /// <returns></returns>
        public ActionResult Selectdg(PageCollection context)
        {
            return this._szrl025Server.Selectdg(context)
                .ToActionResult(this.ControllerContext);
        }
        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="VoucherId"></param>
        /// <returns></returns>
        public ActionResult DeleteVoucher(string VoucherId,string CirculationNumber)
        {
            return this._szrl025Server.DeleteVoucher(VoucherId, CirculationNumber)
                .ToActionResult(this.ControllerContext);
        }
        public ActionResult ExportExcel(HttpCollection vParams)
        {
            return this._exports[Auto_ExcelType.Szrl025ExcelExport].Export(vParams)
                 .ToActionResult(this.ControllerContext);
          
        }
        public ActionResult ExportExcel2(HttpCollection vParams)
        {
            return this._exports[Auto_ExcelType.Szrl026ExcelExport].Export(vParams)
                 .ToActionResult(this.ControllerContext);

        }
        /// <summary>
        /// 保存添加的合同
        /// </summary>
        /// <param name="formid">合同id</param>
        /// <param name="Circulation">更新回数</param>
        /// <returns></returns>
        public ActionResult SaveVoucher(HttpCollection vParams)
        {
            return this._szrl025Server.SaveVoucher(vParams)
                 .ToActionResult(this.ControllerContext);
        }
        /// <summary>
        /// 删除传票
        /// </summary>
        /// <param name="Forsomenum">作番id</param>
        /// <returns></returns>
        public ActionResult Remove(HttpCollection vParams)
        {
            return this._szrl025Server.Remove(vParams)
                .ToActionResult(this.ControllerContext);
        }
    }
}