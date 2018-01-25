using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.PagedList;
using Gmail.DDD.Service;
using PM2.Models;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public interface Isdpk007Server : IService
    {
        /// <summary>
        /// 获取[模块附件列表]
        /// </summary>
        /// <param name="context">分页参数</param>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        IOperateResult GetModels(IPageContext context, string pk);

        /// <summary>
        /// 删除模块附件
        /// </summary>
        /// <param name="pks"></param>
        IOperateResult Remove(string[] pks);

    }
}
