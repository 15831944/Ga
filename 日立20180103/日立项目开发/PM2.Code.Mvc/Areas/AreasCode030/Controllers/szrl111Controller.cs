using Gmail.DDD.Service;
using Newtonsoft.Json;
using PM2.Models.Code030.szrl033Model;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code030;
using PM2.Service.Code030.Szrl105Service;
using PM2.Service.Code030.szrl111Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class szrl111Controller : BaseController
    {
        private Iszrl111Server _szrl111Server;
        private Iszrl112Server _szrl112Server;
        private IExcelService _excelService;
        public szrl111Controller(Iszrl111Server szrl111Server, Iszrl112Server szrl112Server, IExcelService excelService)
        {
            _szrl111Server = szrl111Server;
            _szrl112Server = szrl112Server;
            _excelService = excelService;
        }

        // GET: AreasCode030/szrl111
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 材料库主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialIndex()
        {
            return View();
        }

        /// <summary>
        /// 材料信息编辑页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MaterialEdit(string id)
        {
            ViewBag.model_szrl111 = "";
            ViewBag.attachFileId = "";
            if (!string.IsNullOrWhiteSpace(id))
            {
                var item = _szrl111Server.Get_szrl111(id);
                ViewBag.model_szrl111 = GlobalService.SerializeDateObject(item);
            }
            else
            {
                ViewBag.attachFileId = GlobalService.NewGuid();
            }

            return View();
        }


        /// <summary>
        /// 材料库-EXCEL导入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialImport()
        {
            return View();
        }


        /// <summary>
        /// 添加材料
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMaterial(szrl111 newItem, string attachFileId)
        {
            return _szrl111Server.SaveMaterial(newItem, attachFileId).ConvertJsonResult();
        }

        /// <summary>
        /// 删除材料
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveMaterial(szrl111 item)
        {
            return _szrl111Server.RemoveMaterial(item).ConvertJsonResult();
        }

        /// <summary>
        /// 取材料库列表信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMaterialList(PagerInfo info, string key, string dirId)
        {
            var list = _szrl111Server.SearchForPager_szrl111(info, key, dirId);
            return Json(list);
        }


        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dirId"></param>
        /// <returns></returns>
        public ActionResult ExportMaterialExcel_szrl111(string key, string dirId, int pageNum, int pageSize)
        {
            //var list = _szrl111Server.Search_szrl111(key, dirId);
            //return Json(list);

            var ms = _szrl111Server.ExportExcel_szrl111(key, dirId, pageNum, pageSize);
            return ExcelFileResult("材料信息", ms);

            //return Content("");
        }



        /// <summary>
        /// 取计量单位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMeasureUnits()
        {
            var list = _szrl111Server.GetMeasureUnits();
            return Json(list);
        }


        /// <summary>
        /// 取EXCEL的工作表名
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetExcelSheets(string fileName)
        {
            string filePath = Server.MapPath(fileName);
            ExcelService excelService = new ExcelService();
            List<TreeNodeInfo> list = excelService.GetSheetNames(filePath);
            return Json(list);
        }

        /// <summary>
        /// 取新的材料编码
        /// </summary>
        /// <param name="dirId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewMaterialCode(string dirId)
        {
            var code = _szrl111Server.CreateMaterialCode(dirId);
            return Json(code);
        }


        /// <summary>
        /// 导入EXCEL数据
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImportDataByExcel(MaterialExcel excel)
        {
            if (excel != null && !string.IsNullOrWhiteSpace(excel.ExcelFilePath))
            {
                var name = excel.ExcelWookSheet.Substring(excel.ExcelWookSheet.IndexOf('_') + 1);
                excel.ExcelWookSheet = name;
                string filePath = Server.MapPath(excel.ExcelFilePath);
                excel.ExcelFilePath = filePath;
                return _szrl111Server.ImportDataByExcel(excel).ConvertJsonResult();
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "未找到EXCEL文件信息").ConvertJsonResult();
        }


        /// <summary>
        /// 上传临时EXCEL
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadExcel()
        {
            var files = HttpContext.Request.Files;
            if (files.Count > 0)
            {
                //HttpPostedFileBase file = files[0];
                //string fileName = file.FileName;
                //var index = fileName.LastIndexOf('\\');
                //if (index > 0)
                //{
                //    fileName = fileName.Substring(index + 1);
                //}
                //string rFilePath = "/Temp/" + string.Format("{0}_{1}", GlobalService.NewGuid(), fileName);
                //string filePath = Server.MapPath(rFilePath);
                //file.SaveAs(filePath);

                string rFilePath = _excelService.SaveExcel(files[0]);
                return Content(rFilePath);
            }
            return Content("");
        }


        /// <summary>
        /// 修改材料的材料目录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dirId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeMaterialDir(string id, string dirId)
        {
            return _szrl111Server.ChangeMaterialDir(id, dirId).ConvertJsonResult();
        }



        #region ============================= 材料目录 =============================

        /// <summary>
        /// 材料目录维护主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialDirIndex()
        {
            return View();
        }

        public ActionResult MaterialDirTree()
        {
            return View();
        }


        /// <summary>
        /// 添加材料目录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveMaterialDir(szrl112 newItem)
        {
            return _szrl112Server.SaveMaterialDir(newItem).ConvertJsonResult();
        }

        /// <summary>
        /// 删除材料目录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RemoveMaterialDir(string id)
        {
            return _szrl112Server.RemoveMaterialDir(id).ConvertJsonResult();
        }


        /// <summary>
        /// 获取材料目录信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetMaterialDirs(string id, string key, string all)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                bool allFlag = all == "1";
                var dirs = _szrl112Server.GetMaterialDirs(key, allFlag);
                return Json(dirs);
            }
            var data = _szrl112Server.Find(x => x.rl11201.Equals(id)).FirstOrDefault();
            return Json2(data);
        }

        
        

        #endregion


    }
}