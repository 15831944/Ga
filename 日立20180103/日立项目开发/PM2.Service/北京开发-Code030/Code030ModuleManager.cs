﻿using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models.Code100;
using PM2.Service.Code030.szrl111Service;

namespace PM2.Service.Code030
{
    public class Code030ModuleManager : ModuleManager
    {
        public override void Load()
        {
            //作番维护
            this.RegisterType<sdbo001Server, Isdbo001Server>();
            //作番人员设置
            //this.RegisterType<sdbo004Server, Isdbo004Server>();
            //作番Tree
            this.RegisterType<szrl001Tree, IEasyTree>(serviceName: Auto_TreeType.szrl001Tree);
            //受注传票
            this.RegisterType<Szrl025Server, Iszrl025Server>();
            // 供应商信息管理
            this.RegisterType<Szrl100Server, Iszrl100Server>();
            // 采购合同登记
            this.RegisterType<Szrl105Service.Szrl105Server, Szrl105Service.ISzrl105Server>();
            this.RegisterType<Szrl105Service.Szrl005Server, Szrl105Service.ISzrl005Server>();
            //导出受注传票
            this.RegisterType<szrl025ExcelExport, IExcelExportServer>(serviceName: Auto_ExcelType.Szrl025ExcelExport);
            //导出受注传票明细
            this.RegisterType<szrl026ExcelExport, IExcelExportServer>(serviceName: Auto_ExcelType.Szrl026ExcelExport);
            //实行预算导出
            this.RegisterType<sdbo003ExcelExport, IExcelExportServer>(serviceName: Auto_ExcelType.Sdbo003ExcelExport);
            // 材料库
            this.RegisterType<szrl111Server, Iszrl111Server>();
            this.RegisterType<szrl112Server, Iszrl112Server>();
            this.RegisterType<ExcelService, IExcelService>();
            // 营业合同登记
            this.RegisterType<szrl033Service.szrl033Server, szrl033Service.Iszrl033Server>();
            //实行预算
            this.RegisterType<sdbo003Server, Isdbo003Server>();
            // 营业合同批量验收登记
            this.RegisterType<szrl041Service.szrl041Server, szrl041Service.Iszrl041Server>();
            //压力测试
            this.RegisterType<Szrl888Server, Iszrl888Server>();
            //开票通知汇总表
            this.RegisterType<szrl116Server, Iszrl116Server>();
            //营业合同验收/收款计划更新
            this.RegisterType<szrl030Server, Iszrl030Server>();
            //批量验收登记
            this.RegisterType<szrl035Server, Iszrl035Server>();
            //szrl121.采购合同验收处理
            this.RegisterType<szrl121Server, Iszrl121Server>();
            //合同Tree
            this.RegisterType<szrl121Tree, IEasyTree>(serviceName: Auto_TreeType.szrl105Tree);
            //szrl124.采购合同验收处理变更
            this.RegisterType<szrl124Server, Iszrl124Server>();
 			//szrl130.采购合同验收处理取消
            this.RegisterType<szrl130Server, Iszrl130Server>();
            //szrl105.采购合同登记
            this.RegisterType<szrl105ExcelExport, IExcelExportServer>(serviceName: Auto_ExcelType.Szrl105ExcelExport);
            #region szrl105.采购合同登记
            this.RegisterType<szrl105ServerAsync, Iszrl105ServerAsync>();
            #endregion 
        } 
    }
}
