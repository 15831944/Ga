using Newtonsoft.Json;
using PM2.Models.Code030.szrl033Model;
using PM2.Repository.Code019;
using PM2.Service.Code030;
using PM2.Service.Code030.szrl033Service;
using PM2.Service.Code030.szrl041Service;
using PM2.WebApp.Areas.Code030.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl041Controller : BaseController
    {
        #region ========================= 属性等 =========================
        private Iszrl041Server _szrl041Server;
        public szrl041Controller(Iszrl041Server szrl041Server)
        {
            _szrl041Server = szrl041Server;
        }

        #endregion

        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult szrl041Index()
        {
            return View();
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult szrl041Edit(string id)
        {
            
            return View();
        }


        /// <summary>
        /// 验收计划选择页面
        /// </summary>
        /// <returns></returns>
        public ActionResult szrl041Select()
        {
            return View();
        }


        /// <summary>
        /// 取批量验收登记详细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get_szrl042(PagerInfo info)
        {
            var result = _szrl041Server.Get_szrl042(info);
            return Json(result);
        }


        /// <summary>
        /// 取批量验收信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="zno"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get_szrl041(string id, string zid)
        {
            var item = _szrl041Server.Get_szrl041(id, zid);
            return Json(item);
        }
    }
}