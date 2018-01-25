using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    public interface Iszrl105ServerAsync : IService
    {
        #region 加载合同信息
        /// <summary>
        /// 加载合同信息
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        Task<IOperateResult> LoadFromAsync(string pk);
        #endregion
    }
}
