﻿using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Mvc;
using PM2.Code.NPOI;
using Gmail.DDD.Helper;
using PM2.Models.Code030;
namespace PM2.Service.Code030
{
    public class szrl026ExcelExport : IExcelExportServer
    {
        private IExcelUnitWork _unit;
        private Iszrl025Server _szrl025Server;
        public szrl026ExcelExport(IExcelUnitWorkFactory unitFactory, Iszrl025Server szrl025Server)
        {
            this._szrl025Server = szrl025Server;
            string path = HttpHelper.Request.MapPath("~/Content/Areas/AreasCode030/szrl025/Excel/384AD70B-6BF6-4B40-9A6C-72C55575A6AF.xlsx");
            this._unit = unitFactory.Create(path, 0);
        }
        /// <summary>
        /// 受注传票明细导出Excel
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        public IOperateResult Export(IRequestGetter vParams)
        {
            #region 获取数据
            var rl02501 = vParams.GetValue<string>("rl02501");
            var cbn = this._szrl025Server.SelectgExcel(rl02501).ToList();
            this._unit.SetCellValue(2, 4, vParams.GetValue<string>("ct1"));
            this._unit.SetCellValue(2, 20, vParams.GetValue<string>("ct2"));
            this._unit.SetCellValue(2, 22, vParams.GetValue<string>("ct3"));
            this._unit.SetCellValue(2, 25, vParams.GetValue<string>("ct4"));
            #endregion
            #region 使用模版导出Excel
            int num = 1;
            foreach (var item in cbn)
            {
                int i = cbn.IndexOf(item);//获取索引
                this._unit.SetCellValue(i + 7, 1, item.IsChange);
                this._unit.SetCellValue(i + 7, 2, item.ContractSerialNum);
                this._unit.SetCellValue(i + 7, 5, item.ContractAmount);
                this._unit.SetCellValue(i + 7, 8, item.AllocationAmount);
                this._unit.SetCellValue(i + 7, 11, item.TaxFreeMoney);
                this._unit.SetCellValue(i + 7, 14, item.Tax);
                this._unit.SetCellValue(i + 7, 17, item.ContractNumber);
                this._unit.SetCellValue(i + 7, 20, item.ContractName);
                this._unit.SetCellValue(i + 7, 22, item.ContractDate);
                this._unit.SetCellValue(i + 7, 23, item.DateDelivery);
                this._unit.SetCellValue(i + 7, 24, item.CirculationNumber);
                this._unit.SetCellValue(i + 7, 25, item.DateIssue);
                this._unit.SetCellValue(i + 7, 26, item.BudgetState);
                if (!string.IsNullOrWhiteSpace(item.ContractNumber))
                {
                    this._unit.SetCellValue(i + 7, 0, num.ToString());
                    num++;
                }
                i++;
            }
            return new Excel_OperateResult(this._unit, "受注传票明细");
            #endregion
        }
        /// <summary>
        /// 输出文件到浏览器
        /// </summary>
        /// <param name="ms">Excel文档流</param>
        /// <param name="context">HTTP上下文</param>
        /// <param name="fileName">文件名</param>
        private static void RenderToBrowser(System.IO.MemoryStream ms, string fileName)
        {
            if (System.Web.HttpContext.Current.Request.Browser.Browser == "IE")
                fileName = System.Web.HttpUtility.UrlEncode(fileName);
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        }
        private NPOI.SS.UserModel.ISheet createSheet(NPOI.HSSF.UserModel.HSSFWorkbook workBook, string sheetName)
        {
            NPOI.SS.UserModel.ISheet sheet = workBook.CreateSheet(sheetName);
            NPOI.SS.UserModel.IRow RowHead = sheet.CreateRow(0);

            for (int iColumnIndex = 0; iColumnIndex < 10; iColumnIndex++)
            {
                RowHead.CreateCell(iColumnIndex).SetCellValue(Guid.NewGuid().ToString());
            }

            for (int iRowIndex = 0; iRowIndex < 20; iRowIndex++)
            {
                NPOI.SS.UserModel.IRow RowBody = sheet.CreateRow(iRowIndex + 1);
                for (int iColumnIndex = 0; iColumnIndex < 10; iColumnIndex++)
                {
                    RowBody.CreateCell(iColumnIndex).SetCellValue(DateTime.Now.Millisecond);
                    sheet.AutoSizeColumn(iColumnIndex);
                }
            }
            return sheet;
        }
    }
}
