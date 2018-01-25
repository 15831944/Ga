using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using PM2.Models.Code030;
using PM2.Models.Code031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code030
{
    public interface Iszrl128Repository : IScopeDependency
    {
        /// <summary>
        /// 合同验收计划
        /// </summary>
        /// <param name="pk">合同ID</param>
        /// <returns></returns>
        Task<IEnumerable<szrl128Model>> LoadAsync(string pk);

        /// <summary>
        /// 转换-[待支付确认]合同支付情况
        /// </summary>
        /// <param name="rl12502"></param>
        /// <returns></returns>
        Task<IEnumerable<szrl126>> GetSzrl126s(string rl12502);
    }
}
