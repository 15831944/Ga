using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2.Models.Code030;
using Gmail.DDD.Mvc;
using PM2.Code.NPOI;
using Gmail.DDD.Helper;
namespace PM2.Service.Code030
{
    public class sdbo003ExcelExport : IExcelExportServer
    {
        private IExcelUnitWork _unit;
        //private IExcelUnitWork _unit;
        public sdbo003ExcelExport(IExcelUnitWorkFactory unitFactory)
        {
            string path = HttpHelper.Request.MapPath("~/Content/Areas/AreasCode030/sdbo003/Excel/191D3AE4-F53D-4D53-8954-2FC06ECC3310.xlsx");
            this._unit = unitFactory.Create(path, 0);
           // this._unit = unitFactory.Create(path, 1);
        }
        public IOperateResult Export(IRequestGetter vParams)
        {
            #region 造假数据
            szrl031 szrl031 = new szrl031();
            szrl031.rl03101 = "2017-11-09";
            szrl031.rl03102 = "ISO编号：SHPCS-R-P10-018-1";
            szrl031.rl03103 = "2017年11月12改定版";
            szrl031.rl03104 = "hyc091A";
            szrl031.rl03105 = "邦永科技（广州）有限公司";
            szrl031.rl03106 = "封止材第二工厂建设工事";
            szrl031.rl03107 = "邦永科技（广州）有限公司";
            szrl031.rl03108 = "邦永科技（广州）有限公司";
            szrl031.rl03109 = "邦永科技（广州）有限公司";
            szrl031.rl03110 = "邦永科技（广州）有限公司封止材第二工厂建设工事";
            szrl031.rl03111 = "2017-5-12";
            szrl031.rl03112 = "2017-5-18";
            szrl031.rl03113 = "2016-4-26";
            szrl031.rl03114 = "2017-3-31";
            szrl031.rl03115 = "2016-2-30";
            szrl031.rl03116 = "2017-3-31";

            szrl031.rl03149 = "";
            szrl031.rl03150 = "-";
            szrl031.rl03151 = "-";
            szrl031.rl03152 = "";
            szrl031.rl03153 = "314844";
            szrl031.rl03154 = "546413164";
            szrl031.rl03155 = "1325487";
            szrl031.rl03156 = "31548431";
            szrl031.rl03157 = "313148";
            szrl031.rl03158 = "1.2";
            szrl031.rl03159 = "2";
            szrl031.rl03160 = "10";


            #endregion
            #region 使用模版导出Excel


            string zuofanid = vParams.GetValue<string>("string");
            string banben = vParams.GetValue<string>("banben");
            //szrl082 _szrl082=this._


            #region 标签1
          
            this._unit.SetCellValue(2, 1, szrl031.rl03101);
            this._unit.SetCellValue(1, 15, szrl031.rl03102);
            this._unit.SetCellValue(1, 21, szrl031.rl03103);
            this._unit.SetCellValue(7, 3, szrl031.rl03104);
            this._unit.SetCellValue(11, 3, szrl031.rl03105);
            this._unit.SetCellValue(11, 3, szrl031.rl03106);
            this._unit.SetCellValue(12, 3, szrl031.rl03107);
            this._unit.SetCellValue(13, 3, szrl031.rl03108);
            this._unit.SetCellValue(14, 3, szrl031.rl03109);
            this._unit.SetCellValue(15, 3, szrl031.rl03110);
            this._unit.SetCellValue(18, 3, szrl031.rl03111);
            this._unit.SetCellValue(19, 3, szrl031.rl03112);
            this._unit.SetCellValue(21, 3, szrl031.rl03113);
            this._unit.SetCellValue(22, 3, szrl031.rl03114);
            this._unit.SetCellValue(23, 3, szrl031.rl03115);
            this._unit.SetCellValue(24, 3, szrl031.rl03116);

            this._unit.SetCellValue(29, 4, szrl031.rl03149);
            this._unit.SetCellValue(31, 4, szrl031.rl03150);
            this._unit.SetCellValue(31, 4, szrl031.rl03151);
            this._unit.SetCellValue(32, 4, szrl031.rl03152);
            this._unit.SetCellValue(33, 4, szrl031.rl03153);
            this._unit.SetCellValue(34, 4, szrl031.rl03154);
            this._unit.SetCellValue(35, 4, szrl031.rl03155);
            this._unit.SetCellValue(36, 4, szrl031.rl03156);
            this._unit.SetCellValue(37, 4, szrl031.rl03157);
            this._unit.SetCellValue(38, 4, szrl031.rl03158);
            this._unit.SetCellValue(39, 4, szrl031.rl03159);
            this._unit.SetCellValue(41, 4, szrl031.rl03160);
            #endregion
            #region 标签2
            this._unit.ChangeSheet(1);
            this._unit.InsertCopyRows(8, 6);//8 ,9,10,11,12,13
            for (int i = 8; i < 14; i++)
            {
                this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(), CellStyleEnum.Double_None, false);
                this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
                this._unit.SetCellValue(i, 9,(Convert.ToDecimal(this._unit.GetCellValue(i,6))* Convert.ToDecimal(this._unit.GetCellValue(i, 8))).ToString(), CellStyleEnum.Double_None, false);
            }
            #region 注释
            //for (int i = 8; i < 10; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 14; i < 137; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 139; i < 232; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 234; i < 235; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 237; i < 240; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 244; i < 262; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 264; i < 272; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 274; i < 276; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 278; i < 284; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 286; i < 287; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 291; i < 316; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 318; i < 338; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 340; i < 355; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 357; i < 376; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            //for (int i = 384; i < 394; i++)
            //{
            //    this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(),CellStyleEnum.Double_None, false);
            //    this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
            //}
            #endregion 
            this._unit.InsertCopyRows(15, 5);//15,16,17,18,19
            for (int i = 15; i < 20; i++)
            {
                this._unit.SetCellValue(i, 6, GetRandomNumber(1, 3).ToString(), CellStyleEnum.Double_None, false);
                this._unit.SetCellValue(i, 8, GetRandomNumber(1, 999999).ToString(), CellStyleEnum.Double_None, false);
                this._unit.SetCellValue(i, 9, (Convert.ToDecimal(this._unit.GetCellValue(i, 6)) * Convert.ToDecimal(this._unit.GetCellValue(i, 8))).ToString(), CellStyleEnum.Double_None, false);
            }
            #endregion
            this._unit.SheetRecalculation();
            // FileStream file = new FileStream(@"template/book1.xls", FileMode.Open, FileAccess.Read);
            return new Excel_OperateResult(this._unit, "实行预算");
            #endregion
        }
        public static string GetRandomNumber(int min, int max)
        {
            int rtn = 0;
            Random r = new Random();
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            r = new Random(iSeed);
            rtn = r.Next(min, max + 1);
            return rtn.ToString();
        }
    }
}
