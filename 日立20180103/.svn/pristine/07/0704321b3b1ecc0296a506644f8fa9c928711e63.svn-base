using Gmail.DDD.Service;
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
using PM2.Repository.Code030;
using Gmail.DDD.Repositorys;
using Gmail.DDD.DBContextScope; 
using PM2.Models.Code030.Szrl105Model;
using PM2.Models.Code030.szrl100Model;
using NPOI.HSSF.UserModel;
using System.Web;
using System.IO;
using System.Data;
using PM2.Service.Code001;

namespace PM2.Service.Code030
{
    public class szrl105ExcelExport : IExcelExportServer
    {  
        private IExcelUnitWork _unit;
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl132> _szrl132Repository;//验收处理变更
        private IEFRepository<Szrl105> _szrl105Repository;//szrl105.采购合同登记 
        private IEFRepository<szrl018> _szrl018Repository;//szrl018作番
        private IEFRepository<szrl100> _szrl100Repository;//szrl100供应商
        private IEFRepository<szrl005> _szrl005Repository;//szrl005采购申请
        private IEFRepository<szrl106> _szrl106Repository;//szrl106合同材料明细

        public szrl105ExcelExport(
               IDbContextScopeFactory scopeFactory,
               IEFRepository<szrl132> szrl132Repository,
               IEFRepository<Szrl105> szrl105Repository,
               IEFRepository<szrl018> szrl018Repository,
               IEFRepository<szrl100> szrl100Repository,
               IEFRepository<szrl005> szrl005Repository,
               IEFRepository<szrl106> szrl106Repository
            )
        {
            this._scopeFactory = scopeFactory;
            this._szrl132Repository = szrl132Repository;
            this._szrl105Repository = szrl105Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl100Repository = szrl100Repository;
            this._szrl005Repository = szrl005Repository;
            this._szrl106Repository = szrl106Repository;
        }
        public IOperateResult Export(IRequestGetter vParams)
        {
            string excelid = vParams.GetValue<string>("excelid"); //模板id
            excelid = "51F6CCAB-8470-47DA-A209-7D2C1C8ADED3";     //到时候注释
            string cgheid = vParams.GetValue<string>("cgheid"); //采购合同主键id


            var _132model = new szrl132();
            htfmExcel _htfmmodel = null;
            List<szrl106> _htfmlst = null;
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                 _132model = this._szrl132Repository.GetModels(a => a.rl13201 == excelid).ToList().FirstOrDefault();
                //105合同登记           10502 = 01801
                //018作番        关联   10510 = 10001
                //100供应商      关系   10501 = 10602
                //005采购申请           10504 = 00501 
                //106合同材料明细       
                _htfmmodel = (from a in this._szrl105Repository.GetModels(a => a.rl10501 == cgheid)
                             join b in this._szrl018Repository.GetModels()
                             on a.rl10502 equals b.rl01801
                             join c in this._szrl100Repository.GetModels()
                             on a.rl10510 equals c.rl10001
                             //join d in this._szrl106Repository.GetModels()   先不关联106，另外查询
                             //on a.rl10501 equals d.rl10602
                             join e in this._szrl005Repository.GetModels()
                             on a.rl10504 equals e.rl00501
                             select new htfmExcel
                             {
                                 rl10003 = c.rl10003,
                                 rl10009 = c.rl10009,
                                 rl10010 = c.rl10010,
                                 rl10011 = c.rl10011,
                                 rl10505 = a.rl10505,
                                 rl10506 = a.rl10506,
                                 rl10502 = a.rl10502,
                                 rl01835 = b.rl01835,
                                 rl10513 = a.rl10513,
                                 rl10514 = a.rl10514,
                                 rl10511 = a.rl10511,
                                 rl10515 = a.rl10515,
                                 rl10512 = a.rl10512,
                                 rl10531 = a.rl10531,
                                 rl10530 = a.rl10530,
                                 rl10536 = a.rl10536,
                                 rl10535 = a.rl10535,
                                 rl10541 = a.rl10541,
                                 rl10540 = a.rl10540,
                                 rl10544 = a.rl10544,
                                 rl10543 = a.rl10543,
                                 rl10533 = a.rl10533,
                                 rl10532 = a.rl10532,
                                 rl10538 = a.rl10538,
                                 rl10537 = a.rl10537,
                                 rl10560 = a.rl10560,
                                 rl10561 = a.rl10561,
                                 rl10562 = a.rl10562,
                                 rl10563 = a.rl10563,
                                 rl10522 = a.rl10522,
                                 rl10521 = a.rl10521,
                                 rl00514 = e.rl00514,
                                 rl10567 = a.rl10567
                             }).ToList().FirstOrDefault();
                _htfmlst = (from a in this._szrl105Repository.GetModels(a => a.rl10501 == cgheid)
                           join d in this._szrl106Repository.GetModels()
                           on a.rl10501 equals d.rl10602
                           select d).ToList();
            }
            if (_132model != null)
            {
                #region 合同封面
                string _url = "~/Content/Areas/AreasCode030/szrl105/Excel/" + excelid + "/" + _132model.rl13204 + ".xls";
                string path = HttpHelper.Request.MapPath(_url);
                ExcelUnitWorkFactory unitFactory = new ExcelUnitWorkFactory();
                this._unit = unitFactory.Create(path, 0);
                this._unit.SetCellValue(0, 3, "(登陆号："+ UserContext.Pj00421 + ")");
                this._unit.SetCellValue(2, 0, _htfmmodel.rl10003);
                this._unit.SetCellValue(3, 0, _htfmmodel.rl10009);
                this._unit.SetCellValue(5, 0, "TEL:" + _htfmmodel.rl10010);
                this._unit.SetCellValue(6, 0, "FAX:" + _htfmmodel.rl10011);
                this._unit.SetCellValue(14, 0,  _htfmmodel.rl10505);
                this._unit.SetCellValue(14, 2, _htfmmodel.rl10506); 
                this._unit.SetCellValue(14, 3, _htfmmodel.rl10502); 
                this._unit.SetCellValue(14, 5, _htfmmodel.rl01835.ToString("f2"));
                this._unit.SetCellValue(14, 7, _htfmmodel.rl10513);
                this._unit.SetCellValue(14, 11, _htfmmodel.rl10514);
                this._unit.SetCellValue(14, 14, _htfmmodel.rl10511);
                this._unit.SetCellValue(22, 0, _htfmmodel.rl10515);
                this._unit.SetCellValue(22, 1, _htfmmodel.rl10512);
                this._unit.SetCellValue(20, 6, _htfmmodel.rl10531.ToString());
                this._unit.SetCellValue(20, 9, _htfmmodel.rl10530.ToString());
                this._unit.SetCellValue(21, 6, _htfmmodel.rl10536.ToString());
                this._unit.SetCellValue(21, 9, _htfmmodel.rl10535.ToString());
                this._unit.SetCellValue(22, 6, _htfmmodel.rl10541.ToString());
                this._unit.SetCellValue(22, 9, _htfmmodel.rl10540.ToString());
                this._unit.SetCellValue(23, 6, _htfmmodel.rl10544.ToString());
                this._unit.SetCellValue(23, 9, _htfmmodel.rl10543.ToString());
                #region 工事件名
                if (_htfmlst.Count() > 6)
                { 
                    this._unit.SetCellValue(28, 0, "1");
                    this._unit.SetCellValue(28, 1, "请查看明细");
                    this._unit.SetCellValue(28, 10, "请查看明细");
                    this._unit.SetCellValue(28, 11, "请查看明细");
                    this._unit.SetCellValue(28, 12, "请查看明细");
                    this._unit.SetCellValue(28, 13, "请查看明细");
                    this._unit.SetCellValue(28, 14, "请查看明细");
                }
                else
                {
                    for (var i = 0; i < _htfmlst.Count(); i++)
                    {
                        var rindex = 28 + i; 
                        this._unit.SetCellValue(rindex, 0, (i+1).ToString());
                        this._unit.SetCellValue(rindex, 1, _htfmlst[i].rl10605);
                        this._unit.SetCellValue(rindex, 10, _htfmlst[i].rl10610.ToString("f2"));
                        this._unit.SetCellValue(rindex, 11, _htfmlst[i].rl10611);
                        this._unit.SetCellValue(rindex, 12, _htfmlst[i].rl10613.ToString("f2"));
                        this._unit.SetCellValue(rindex, 13, _htfmlst[i].rl10612.ToString("f2"));
                        this._unit.SetCellValue(rindex, 14, _htfmlst[i].rl10614.ToString("f2"));
                    }
                }
                #endregion

                #endregion

                #region 请款书
                _url = "~/Content/Areas/AreasCode030/szrl105/Excel/" + excelid + "/" + _132model.rl13205 + ".xls";
                #endregion
                #region 验收证明书
                _url = "~/Content/Areas/AreasCode030/szrl105/Excel/" + excelid + "/" + _132model.rl13206 + ".xls";
                #endregion
                #region 特别条件书
                _url = "~/Content/Areas/AreasCode030/szrl105/Excel/" + excelid + "/" + _132model.rl13207 + ".xls";
                #endregion
                #region 一半条件书
                _url = "~/Content/Areas/AreasCode030/szrl105/Excel/" + excelid + "/" + _132model.rl13208 + ".xls";
                #endregion 
                return new Excel_OperateResult(this._unit, "xxxxx");
            }
            else
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
         
    }
}
