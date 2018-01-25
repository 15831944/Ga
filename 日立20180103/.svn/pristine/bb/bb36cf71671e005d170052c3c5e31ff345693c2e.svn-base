using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.JsonConvert;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Web;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using Gmail.DDD.Mvc;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace PM2.Service.Code030.Szrl105Service
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class Szrl105Server : CmDataService<Szrl105>, ISzrl105Server
    {
        #region ================= 属性等 ==================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<Szrl105> _szrl105Repository;
        private IEFRepository<szrl005> _szrl005Repository;
        private IEFRepository<szrl132> _szrl132Repository;//验收处理变更

        public Szrl105Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<Szrl105> szrl105Repository,
             IEFRepository<szrl132> szrl132Repository,
             IEFRepository<szrl005> szrl005Repository
        ) : base(scopeFactory, szrl105Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl105Repository = szrl105Repository;
            this._szrl132Repository = szrl132Repository;
            this._szrl005Repository = szrl005Repository;

        }

        #endregion




        #region ========================= 采购申请 ========================= 



        #endregion





        public void ExportExcelForDtByNPOI(HttpCollection vParams)
        { 
            string excelid = vParams.GetValue<string>("excelid"); //模板id
            excelid = "51F6CCAB-8470-47DA-A209-7D2C1C8ADED3";     //到时候注释
            var _132model = new szrl132();
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                _132model = this._szrl132Repository.GetModels(a => a.rl13201 == excelid).ToList().FirstOrDefault();
            }
            string _url = HttpContext.Current.Server.MapPath("/") + "\\Content\\Areas\\AreasCode030\\szrl105\\Excel\\" + excelid + "\\" + _132model.rl13204 + ".xlsx";

            DataTable dtSource = new DataTable(); 
            string strFileName = "abc.xlsx";
            string strTemplateFileName = _url;
            int flg = 1; 
            // 利用模板，DataTable导出到Excel（单个类别）
            using (MemoryStream ms = ExportExcelForDtByNPOI(dtSource, strTemplateFileName, flg))
            {
                byte[] data = ms.ToArray();
                #region 客户端保存
                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear(); 
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd-excel";//"application/vnd.ms-excel";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + strFileName));
                System.Web.HttpContext.Current.Response.BinaryWrite(data);
                #endregion
            }
        }

        private static MemoryStream ExportExcelForDtByNPOI(DataTable dtSource, string strTemplateFileName, int flg)
        {
            bool isExcel2003 = strTemplateFileName.ToLower().EndsWith("xls") ? true : false;
            FileStream file = new FileStream(strTemplateFileName, FileMode.Open, FileAccess.Read);//读入excel模板
            IWorkbook workbook = null;
            if (isExcel2003)
            {
                workbook = new HSSFWorkbook(file);
            }
            else
            {
                workbook = new XSSFWorkbook(file);
            }
            string sheetName = "";
            switch (flg)
            {
                case 1:
                    sheetName = "Sheet1";
                    break; 
            }
            //var sheet = workbook.GetSheet(sheetName);
            var sheet = workbook.GetSheetAt(0);
            var dataRow = sheet.GetRow(2);
            var newCell2 = dataRow.GetCell(0);
            newCell2.SetCellValue("123123");

            dataRow = sheet.GetRow(0);
            newCell2 = dataRow.GetCell(3);
            newCell2.SetCellValue("(登陆号：1001)");

            dataRow = sheet.GetRow(14);
            newCell2 = dataRow.GetCell(0);
            newCell2.SetCellValue("测试中文");

            foreach (DataRow row in dtSource.Rows)
            {
                #region 填充内容
                //var dataRow = sheet.GetRow(rowIndex);  
                //int columnIndex = 1;        // 开始列（0为标题列，从1开始）
                //foreach (DataColumn column in dtSource.Columns)
                //{
                //    // 列序号赋值
                //    if (columnIndex >= dtSource.Columns.Count)
                //        break;

                //    var newCell = dataRow.GetCell(columnIndex);
                //    if (newCell == null)
                //        newCell = dataRow.CreateCell(columnIndex);

                //    string drValue = row[column].ToString();

                //    switch (column.DataType.ToString())
                //    {
                //        case "System.String"://字符串类型
                //            newCell.SetCellValue(drValue);
                //            break;
                //        case "System.DateTime"://日期类型
                //            DateTime dateV;
                //            DateTime.TryParse(drValue, out dateV);
                //            newCell.SetCellValue(dateV);

                //            break;
                //        case "System.Boolean"://布尔型
                //            bool boolV = false;
                //            bool.TryParse(drValue, out boolV);
                //            newCell.SetCellValue(boolV);
                //            break;
                //        case "System.Int16"://整型
                //        case "System.Int32":
                //        case "System.Int64":
                //        case "System.Byte":
                //            int intV = 0;
                //            int.TryParse(drValue, out intV);
                //            newCell.SetCellValue(intV);
                //            break;
                //        case "System.Decimal"://浮点型
                //        case "System.Double":
                //            double doubV = 0;
                //            double.TryParse(drValue, out doubV);
                //            newCell.SetCellValue(doubV);
                //            break;
                //        case "System.DBNull"://空值处理
                //            newCell.SetCellValue("");
                //            break;
                //        default:
                //            newCell.SetCellValue("");
                //            break;
                //    }
                //    columnIndex++;
                //}
                #endregion 
            }
            // 格式化当前sheet，用于数据total计算
            sheet.ForceFormulaRecalculation = true; 
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet = null;
                workbook = null;
                return ms;
            }
        }




        /// <summary>
        /// 取新的GUID
        /// </summary>
        /// <returns></returns>
        private string NewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }


        /// <summary>
        /// 取当前登录用户
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUserId()
        {
            string name = "当前用户1";
            if (HttpContext.Current != null && HttpContext.Current.User != null)
            {
                name = HttpContext.Current.User.Identity.Name;
            }

            return name;
        }
    }
}
