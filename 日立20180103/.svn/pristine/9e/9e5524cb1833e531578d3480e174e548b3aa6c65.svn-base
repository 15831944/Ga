using PM2.Service.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gmail.DDD.Extensions;
using PM2.Models.Code030.szrl100Model;
using Gmail.DDD.JsonConvert;
using System.Collections;
using PM2.Service.Code030.Szrl105Service;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl033Model;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    /// <summary>
    /// 供应商信息管理模块
    /// </summary>
    public class szrl100Controller : BaseController
    {
        private Iszrl100Server _szrl100Server;
        public szrl100Controller(Iszrl100Server szrl100Server)
        {
            _szrl100Server = szrl100Server;
        }

        #region =========== 供应商 =========== 

        // GET: AreasCode030/szrl100
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 供应商信息编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            ViewBag.SupplierId = "";
            ViewBag.LoadSupplierFlag = 0;
            ViewBag.SupplierCode = "";

            string loginUser = GlobalService.GetLoginUserId();

            string supplierId = id;
            var model = _szrl100Server.GetSupplierById(supplierId);
            Szrl100FormStateService formState = new Szrl100FormStateService();
            formState.CurrentState = Szrl100FormStateService.STATE_NEW;


            if (!string.IsNullOrWhiteSpace(supplierId) && model == null)
            {
                return Redirect("/Error/Error_404");
            }
            if (model != null)
            {
                ViewBag.SupplierId = supplierId;
                ViewBag.SupplierInfo = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                ViewBag.LoadSupplierFlag = 1;
                ViewBag.SupplierCode = model.rl10002;

                var versions = this._szrl100Server.GetSupplierVersions(model.rl10002);
                ArrayList versionList = new ArrayList();
                foreach (var version in versions)
                {
                    if (model.rl10001.Equals(version.Id))
                    {
                        version.IsSelectedVersion = true;
                    }
                    versionList.Add(new { id = version.Id.ToString(), text = version.VersionDesc, selected = version.IsSelectedVersion });
                }
                var versionModel = new { total = versionList.Count, rows = versionList };
                ViewBag.SupplierVersions = Newtonsoft.Json.JsonConvert.SerializeObject(versionModel);

                // 当前表单状态
                formState.CurrentState = model.rl10043 ? model.rl10045 ? Szrl100FormStateService.STATE_ADMITED : Szrl100FormStateService.STATE_ADMITED_OLD : Szrl100FormStateService.STATE_SAVED;
            }

            ViewBag.StateActions = formState.GetForbidInfo();
            ViewBag.LenLimit = new MyLimit().LenLimit;

            // 不是审核用户或表单状态不是已保存
            ViewBag.ForbidUpdate26 = 1;
            if (Szrl100FormStateService.IsAdmitUser && formState.CurrentState != Szrl100FormStateService.STATE_NEW)
            {
                ViewBag.ForbidUpdate26 = 0; // 可否采用不可编辑
            }

            // 添加子项，如建筑企业资质清单等
            ViewBag.OperateFlag = formState.IsDiabledForm ? "false" : "true";
            ViewBag.IsFinanceFlag = Szrl100FormStateService.IsFinanceFlag ? "true" : "false";

            return View();
        }



        /// <summary>
        /// 添加（修改）供应商信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(szrl100 item, string buildingIncCert, string signedName, string remarkList)
        {
            return this._szrl100Server.SaveSupplier(item, buildingIncCert, signedName, remarkList).ConvertJsonResult();
        }

        /// <summary>
        /// 添加新版本供应商信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewVersion(szrl100 item)
        {

            return this._szrl100Server.SaveTempNewVersionSupplier(item).ConvertJsonResult();
        }
        


        /// <summary>
        /// 审核（承认）供应商的新版本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AdmitVersion(string id, string code, bool rl10026)
        {
            

            return this._szrl100Server.AdmitSupplierVersion(id, code, rl10026).ConvertJsonResult();
        }


        /// <summary>
        /// 取供应商代码对应的供应商的所有版本
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetVersions(string code)
        {
            var versions = this._szrl100Server.GetSupplierVersions(code);
            return Json(versions);
        }


        /// <summary>
        /// 删除供应商编码对应的供应商，即删除该供应商所有的版本
        /// </summary>
        /// <param name="code">供应商编码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveSupplier(string code)
        {
            return this._szrl100Server.RemoveSupplier(code).ConvertJsonResult();
        }

        /// <summary>
        /// 删除供应商ID对应的供应商版本
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveSupplierVersion(string id)
        {
            return this._szrl100Server.RemoveSupplierVersionById(id).ConvertJsonResult();
        }


        /// <summary>
        /// 取供应商信息列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetGysList(string key, string black, PagerInfo info)
        {

            var result = this._szrl100Server.SearchSupplierList(key, black, info);
            return Json(result);
        }


        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="black"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public ActionResult Export_szrl100(string key, string black, PagerInfo info)
        {
            var ms = _szrl100Server.ExportExcel_szrl100(key, black, info);
            return ExcelFileResult("供应商信息", ms);
        }


        /// <summary>
        /// 更新财务数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateFinanceData(szrl100 item)
        {
            return _szrl100Server.SaveFinanceData(item).ConvertJsonResult();
        }

        #endregion


        #region ========== 合同签订授权代表姓名 ==========

        /// <summary>
        /// 合同签订授权代表姓名编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SignedNameEdit(string id)
        {
            string supplierId = id;
            //ViewBag.OperateFlag = "true";
            ViewBag.SupplierId = id;
            //if (!string.IsNullOrWhiteSpace(supplierId))
            //{
            //    ViewBag.OperateFlag = "false";
            //}
            return View();
        }


        /// <summary>
        /// 取合同签订授权代表姓名列表
        /// </summary>
        /// <param name="code">供应商编码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSignedNameList(string id)
        {
            var list = this._szrl100Server.GetSignedNameList(id);
            return Json(list);
        }

        /// <summary>
        /// 新增合同签订授权代表姓名
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewSignedName(szrl101 item)
        {
            return this._szrl100Server.AddSignedName(item).ConvertJsonResult();
        }


        /// <summary>
        /// 删除合同签订授权代表姓名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RemoveSignedName(string id)
        {
            return _szrl100Server.DeleteSignedName(id).ConvertJsonResult();
        }

        #endregion


        #region ============= 建筑企业资质清单 =================


        /// <summary>
        /// 建筑企业资质清单列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BuildingIncCertList(string id)
        {
            ViewBag.SupplierId = id;
            //ViewBag.OperateFlag = string.IsNullOrWhiteSpace(id) ? "true" : "false";
            return View();
        }


        /// <summary>
        /// 取建筑企业资质清单列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetBuildingIncCerts(string id)
        {
            var list = _szrl100Server.SearchBuildingIncCertList(id);
            return Json(list);
        }

        /// <summary>
        /// 添加建筑企业资质
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBuildingIncCert(szrl103 item)
        {
            return _szrl100Server.AddBuildingIncCert(item).ConvertJsonResult();
        }


        /// <summary>
        /// 删除建筑企业资质
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveBuildingIncCert(string id)
        {
            return _szrl100Server.DeleteBuildingIncCert(id).ConvertJsonResult();
        }


        [HttpPost]
        public ActionResult UpdateBuildingInfo(szrl104 item)
        {
            return _szrl100Server.SaveBuilding(item).ConvertJsonResult();
        }


        #endregion


        #region ======================== 备注 ========================

        /// <summary>
        /// 备注页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RemarkList(string id)
        {
            ViewBag.SupplierId = id;
            //ViewBag.OperateFlag = string.IsNullOrWhiteSpace(id) ? "true" : "false";
            return View();
        }


        /// <summary>
        /// 取对应供应商的备注列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult GetRemarkList(string id)
        {
            var list = _szrl100Server.SearchRemarkList(id);
            return Json(list);
        }

        /// <summary>
        /// 添加备注
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRemark(szrl102 item)
        {
            return _szrl100Server.AddRemark(item).ConvertJsonResult();
        }


        /// <summary>
        /// 删除备注
        /// </summary>
        /// <param name="id">备注ID</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveRemark(string id)
        {
            return _szrl100Server.DeleteRemark(id).ConvertJsonResult();
        }



        #endregion


    }
}