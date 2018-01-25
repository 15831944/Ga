using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;
using System.Data;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace PM2.Service.Code030.szrl111Service
{
    public interface IExcelService : IService
    {
        /// <summary>
        /// 取EXCEL的工作表名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<TreeNodeInfo> GetSheetNames(string filePath);

        /// <summary>
        /// 导入EXCEL数据
        /// </summary>
        /// <param name="excelInfo"></param>
        DataTable ImportData(ImportExcelInfo excelInfo);


        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        /// <returns></returns>
        MemoryStream ExportToExcel(DataTable dt);


        /// <summary>
        /// 保存EXEL文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns>EXCEL的相对路径</returns>
        string SaveExcel(HttpPostedFileBase file);


        /// <summary>
        /// 删除上传的EXCEL文件
        /// </summary>
        /// <param name="excelFilePath"></param>
        void DeleteExcelFile(string excelFilePath);

    }
}
