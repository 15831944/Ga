using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Models.Code001;
using Gmail.DDD.PagedList;
using Gmail.DDD.Mvc;

namespace PM2.Service.Code030
{
    public interface Iszrl025Server : IService
    {
        #region MyRegion
        /// <summary>
        /// 获取作番信息
        /// </summary>
        /// <param name="id">作番id</param>
        /// <returns></returns>
        IOperateResult GetForsomeInfo(IRequestGetter context);
        /// <summary>
        /// 营业合同
        /// </summary>
        /// <param name="Forsomenum">作番号</param>
        /// <returns></returns>
        List<szrl019> GetBusiness(string Forsomenum);
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="id">作番id</param>
        /// <returns></returns>
        IOperateResult Add(szrl025 szrl025);
        // IOperateResult GetContract();

        IOperateResult Update(szrl025 szrl025);
        IOperateResult Recognize(szrl025 szrl025);
        #endregion
       
        IOperateResult SelectIsRecognize(szrl025 szrl025);
        /// <summary>
        /// 显示明显
        /// </summary>
        /// <param name="rl02501"></param>
        /// <returns></returns>
        IOperateResult Selectdg(IPageContext context);

        /// <summary>
        /// 显示作番下所有合同
        /// </summary>
        /// <param name="rl02501"></param>
        /// <returns></returns>
        IOperateResult GetSzrl019Info(IPageContext context);

        /// <summary>
        /// 保存合同
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        IOperateResult SaveVoucher(HttpCollection vParams);
        IOperateResult DeleteVoucher(string VoucherId, string CirculationNumber);
        IOperateResult ExportExcel(List<szrl026CBN> cnb, string ct1, string ct2, string ct3, string ct4);
        IOperateResult ExportExcel2(szrl018 szrl018, szrl025 szrl025, string z1821, string z1922, string z2023);
        
        IEnumerable<szrl026CBN> SelectgExcel(string rl02501);

        /// <summary>
        /// 删除传票
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        IOperateResult Remove(HttpCollection vParams);

    }
}
