using Newtonsoft.Json;
using PM2.Models.Code030.szrl033Model;
using PM2.Repository.Code019;
using PM2.Service.Code030;
using PM2.Service.Code030.szrl033Service;
using PM2.WebApp.Areas.Code030.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl033Controller : BaseController
    {
        #region ========================= 属性等 =========================
        private Iszrl033Server _szrl033Server;
        public szrl033Controller(Iszrl033Server szrl033Server)
        {
            _szrl033Server = szrl033Server;
        }

        #endregion

        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult szrl033Index()
        {
            return View();
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult szrl033Edit(string id)
        {
            ViewBag.model_eidt_szrl033 = string.Empty;
            ViewBag.contractid_edit_szrl033 = id;
            if (!string.IsNullOrWhiteSpace(id))
            {
                ViewBag.model_eidt_szrl033 = JsonConvert.SerializeObject(_szrl033Server.Get_szrl033(id));
            }
            ViewBag.contractinfo_edit_szrl033 = _szrl033Server.GetContractInfo_szrl033(id);

            return View();
        }

        public ActionResult szrl033DirTree()
        {
            return View();
        }


        public ActionResult AttachFiles(string id, string v)
        {
            ViewBag.id = id;
            ViewBag.ViewFlag = v;
            return View();
        }


        /// <summary>
        /// 批量验收
        /// </summary>
        /// <returns></returns>
        //public ActionResult szrl033MultiIndex()
        //{
        //    return View();
        //}


        /// <summary>
        /// 保存验收登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save_szrl033(List<VAcceptancePlanObj> items, szrl033 szrl033Item)
        {
            return _szrl033Server.Save_szrl033(items, szrl033Item).ConvertJsonResult();
        }


        /// <summary>
        /// 承认
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Admit_szrl034(List<VAcceptancePlanObj> items)
        {
            return _szrl033Server.Admit_szrl034(items).ConvertJsonResult();
        }


        /// <summary>
        /// 查询验收登记
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search_szrl033(PagerInfo pager, string key)
        {
            if (pager == null)
            {
                var list = _szrl033Server.Search_szrl033(key);
                return Json(list);
            }
            else
            {
                var result = _szrl033Server.SearchPager_szrl033(key, pager);
                return Json(result);
            }
        }


        /// <summary>
        /// 取附件数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get_AttachFileCount(string key)
        {
            int count = _szrl033Server.GetAttachFileCount_szrl033(key);
            var model = new { FileCount = count };
            return Json(model);
        }


        /// <summary>
        /// 根据验收计划ID取合同信息
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetContractInfo_szrl033(string planId)
        {
            var item = _szrl033Server.GetContractInfo_szrl033(planId);
            return Json(item);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Remove_szrl033(szrl033 item)
        {
            return _szrl033Server.Delete_szrl033(item).ConvertJsonResult();
        }


        /// <summary>
        /// 取验收计划明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAcceptancePlanDetails(string id)
        {
            var list = _szrl033Server.Get_szrl024(id);
            var acceptFlag = list.Count > 0 && list.Where(x => x.rl03412 != 1).Count() == 0;
            //ViewBag.AcceptFlag = acceptFlag ? "1" : "0";
            var footer = new ArrayList() { new { rl02404 = list.Sum(x => x.rl02404), rl02405 = list.Sum(x => x.rl02405), rl03409 = list.Sum(x => x.rl03409) } };
            var obj = new { AcceptFlag = acceptFlag ? "1" : "0", Rows = new { rows = list, footer = footer } };

            return Json(obj);
        }

        /// <summary>
        /// 取验收计划明细的合同分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetContractType_szrl033(string id)
        {
            var list = _szrl033Server.GetContractType_index_szrl024(id);
            return Json(list);
        }

        /// <summary>
        /// 取验收计划明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetIndexAcceptancePlanDetails(PagerInfo info, string key, string id)
        {
            var result = _szrl033Server.Get_index_szrl024(info, key, id);
            return Json(result);
        }


        /// <summary>
        /// 获取营业合同目录信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetContractDirs(string id, string key, string multi)
        {
            //var dirs = _szrl033Server.GetContractDirs2(id, key, multi);
            var dirs = _szrl033Server.GetContractDirs(key, multi);
            return Json(dirs);
        }


        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult ExportExcel_szrl033(string key, string id, int pageNum, int pageSize)
        {
            var ms = _szrl033Server.ExportExcel_szrl033(key, id, pageNum, pageSize);
            return ExcelFileResult("验收登记", ms);
        }
    }
}