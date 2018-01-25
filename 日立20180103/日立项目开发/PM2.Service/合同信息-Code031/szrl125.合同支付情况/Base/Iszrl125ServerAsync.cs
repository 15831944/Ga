#region using
using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models;
using PM2.Models.Code001;
using PM2.Models.Code031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace PM2.Service.Code031
{
    public interface Iszrl125ServerAsync : IService
    {        
        #region 预付款|验收款
        /// <summary>
        /// 预付款|验收款
        /// </summary>
        /// <param name="szrl125">模型</param>
        /// <returns></returns>
        Task<IOperateResult> AdvancePaymentAsync(szrl125 szrl125);
        #endregion
        #region 支付计划调整
        /// <summary>
        /// 支付计划调整
        /// </summary>
        /// <param name="szrl125">模型</param>
        /// <returns></returns>
        Task<IOperateResult> AdjustPaymentAsync(szrl125 szrl125);
        #endregion
        #region 带入验收计划
        /// <summary>
        /// 带入验收计划
        /// </summary>
        /// <param name="szrl125">模型</param>
        /// <returns></returns>
        Task<IOperateResult> IntoPaymentAsync(szrl125 szrl125);
        #endregion
        #region 恢复原支付计划
        /// <summary>
        /// 恢复原支付计划
        /// </summary>
        /// <param name="szrl125">模型</param>
        /// <returns></returns>
        Task<IOperateResult> RestorePaymentAsync(szrl125 szrl125);
        #endregion

        #region 数据保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="szrl125">模型</param>
        /// <returns></returns>
        Task<IOperateResult> SaveAsync(szrl125 szrl125);
        #endregion
        #region 数据加载
        /// <summary>
        /// 数据加载
        /// </summary>
        /// <param name="pk">合同ID</param>
        /// <param name="rl12507">状态: -1 初始化</param>
        /// <returns></returns>
        Task<IOperateResult> LoadAsync(string pk, int rl12502);
        #endregion

    }
}

