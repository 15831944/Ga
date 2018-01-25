﻿using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Mvc;
using PM2.Code.NPOI;
using Gmail.DDD.Helper;
using PM2.Models.Code030;
using Gmail.DDD.JsonConvert;
using Newtonsoft.Json.Linq;
namespace PM2.Service.Code030
{
    public class szrl025ExcelExport : IExcelExportServer
    {
        private IExcelUnitWork _unit;
        private Iszrl025Server _szrl025Server;
        public szrl025ExcelExport(IExcelUnitWorkFactory unitFactory, Iszrl025Server szrl025Server)
        {
            this._szrl025Server = szrl025Server;
            string path = HttpHelper.Request.MapPath("~/Content/Areas/AreasCode030/szrl025/Excel/26047214-F004-4355-A650-58B88E2748E3.xlsx");
            this._unit = unitFactory.Create(path, 0);
        }
        /// <summary>
        /// 受注传票导出Excel
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        public IOperateResult Export(IRequestGetter vParams)
        {
            #region 获取传票数据
            string rl02501 = vParams.GetValue<string>("id");
            IOperateResult cbn = this._szrl025Server.GetForsomeInfo(vParams);
            IJsonConvert context = cbn.GetResult<IJsonConvert>();
            string jsonStr = context.ToJsonString();
            JToken ken = JToken.Parse(jsonStr);
            szrl025 szrl025 = SerializeMemoryHelper.DeserializeFromJson<szrl025>(ken);
            szrl018 szrl018 = ken.SelectToken("Pamrms.szrl018").ToObject<szrl018>();
            #endregion
            #region 获取传票明细数据
            List<szrl026CBN> szrl026cbn = this._szrl025Server.SelectgExcel(rl02501).ToList();
          
            #endregion
            #region 使用模版导出传票Excel
            this._unit.SetCellValue(1, 5, szrl025.rl02503 == "0" ? "初回" : szrl025.rl02503);
            this._unit.SetCellValue(2, 5, szrl025.rl02504);
            if (szrl025.rl02505 == 0)
            {
                this._unit.SetCellValue(5, 6, "●");
                this._unit.SetCellValue(7, 6, "");
            }
            else if (szrl025.rl02505 == 1)
            {
                this._unit.SetCellValue(5, 6, "");
                this._unit.SetCellValue(7, 6, "●");
            }
            if (szrl025.rl02506 == 0)
            {
                this._unit.SetCellValue(5, 15, "●");
                this._unit.SetCellValue(7, 15, "");
            }
            else if (szrl025.rl02506 == 1)
            {
                this._unit.SetCellValue(7, 15, "");
                this._unit.SetCellValue(7, 15, "●");
            }
            this._unit.SetCellValue(5, 34, szrl018.rl01835.ToString() + "%");
            this._unit.SetCellValue(7, 18, szrl018.rl01806);
            this._unit.SetCellValue(5, 47, szrl025.rl02508);
            this._unit.SetCellValue(7, 47, szrl018.rl01813.ToString());
            this._unit.SetCellValue(9, 47, szrl018.rl01811);
            this._unit.SetCellValue(12, 7, szrl018.rl01802);
            this._unit.SetCellValue(14, 7, szrl025.rl02509);
            this._unit.SetCellValue(16, 7, szrl018.rl01807);
            this._unit.SetCellValue(12, 33, szrl025.rl02507);
            this._unit.SetCellValue(14, 33, szrl025.rl02510);
            this._unit.SetCellValue(16, 33, szrl025.rl02511);
            this._unit.SetCellValue(20, 7, szrl025.rl02512);
            this._unit.SetCellValue(23, 7, szrl025.rl02513);
            this._unit.SetCellValue(26, 7, szrl025.rl02514);
            this._unit.SetCellValue(20, 22, szrl025.rl02515.ToString() + "件");
            this._unit.SetCellValue(23, 22, szrl025.rl02516.ToString() + "件");
            this._unit.SetCellValue(26, 22, szrl025.rl02517.ToString() + "件");
            this._unit.SetCellValue(20, 27, szrl025.rl02518.ToRound().ToString());
            this._unit.SetCellValue(23, 27, szrl025.rl02519.ToRound().ToString());
            this._unit.SetCellValue(26, 27, szrl025.rl02520.ToRound().ToString());
            this._unit.SetCellValue(20, 33, szrl025.rl02521.ToRound().ToString());
            this._unit.SetCellValue(23, 33, szrl025.rl02522.ToRound().ToString());
            this._unit.SetCellValue(26, 33, szrl025.rl02523.ToRound().ToString());
            this._unit.SetCellValue(20, 39, (szrl025.rl02521 * szrl018.rl01835 / 100).ToRound().ToString());
            this._unit.SetCellValue(23, 39, (szrl025.rl02522 * szrl018.rl01835 / 100).ToRound().ToString());
            this._unit.SetCellValue(26, 39, (szrl025.rl02523 * szrl018.rl01835 / 100).ToRound().ToString());
            this._unit.SetCellValue(20, 46, (szrl025.rl02518 * szrl018.rl01813).ToRound().ToString());
            this._unit.SetCellValue(23, 46, (szrl025.rl02519 * szrl018.rl01813).ToRound().ToString());
            this._unit.SetCellValue(26, 46, (szrl025.rl02520 * szrl018.rl01813).ToRound().ToString());
            this._unit.SetCellValue(30, 27, szrl025.rl02527);
            this._unit.SetCellValue(32, 1, szrl025.rl02528);
            this._unit.SetCellValue(32, 6, szrl025.rl02530);
            this._unit.SetCellValue(32, 11, szrl025.rl02531);
            this._unit.SetCellValue(32, 16, szrl025.rl02532 == 0 ? "已审核" : "未审核");
            this._unit.SetCellValue(32, 21, szrl025.rl02533);
            #endregion
            #region 使用模版导出明细Excel
            this._unit.ChangeSheet(1);
            this._unit.SetCellValue(2, 4, vParams.GetValue<string>("ct1"));
            this._unit.SetCellValue(2, 20, vParams.GetValue<string>("ct2"));
            this._unit.SetCellValue(2, 22, vParams.GetValue<string>("ct3"));
            this._unit.SetCellValue(2, 25, vParams.GetValue<string>("ct4"));
            int num = 1;
            foreach (var item in szrl026cbn)
            {
                int i = szrl026cbn.IndexOf(item);//获取索引
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
            #endregion


            //ImportDataCommand Import = null;
            //Import.ConvertEvent += Import_ConvertEvent;
            //Import.ValidationEvent += Import_ValidationEvent;

            //IEnumerable<szrl026> szrl026s = Import.Execute<szrl026>(this._unit, null);
            //Updates(szrl026s);



            


            return new Excel_OperateResult(this._unit, "受注传票");
        }

        //#region NPOI-下载数据
        ///// <summary>
        ///// 将指定的HSSFWorkbook输出到流
        ///// </summary>
        ///// <param name="workbook"></param>
        ///// <param name="strFileName">文件名</param>
        //public static void ExportHSSFWorkbookByWeb(HSSFWorkbook hssWorkbook = null, XSSFWorkbook xssWorkbook = null, string strFileName = null)
        //{
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        if (hssWorkbook == null)
        //            xssWorkbook.Write(ms);
        //        else
        //            hssWorkbook.Write(ms);
        //        ms.Flush();
        //        ms.Position = 0;

        //        HttpContext curContext = HttpContext.Current;

        //        // 设置编码和附件格式
        //        curContext.Response.ContentType = "application/vnd.ms-excel";
        //        curContext.Response.ContentEncoding = Encoding.Default;
        //        curContext.Response.Charset = "";
        //        curContext.Response.AppendHeader("Content-Disposition", "attachment;filename=" + strFileName);
        //        curContext.Response.BinaryWrite(ms.GetBuffer());
        //        curContext.Response.End();
        //    }


        //}

        //#endregion




        #region 验证|转换数据
        //private void Import_ValidationEvent(object sender, Code.NPOI.ValidationContext e)
        //{
        //    szrl026 szrl026 = e.CurrentValue.ConvertTo<szrl026>();
        //    e.IsValidation = false;
        //}
        //private void Import_ConvertEvent(object sender, ConvertContext e)
        //{
        //    if (e.ECHeadEnum == ECHeadEnum.F)
        //        e.CurrentValue = e.CurrentValue.ToString() == "工事" ? "1" : "0";
        //}
        #endregion

    }
}
