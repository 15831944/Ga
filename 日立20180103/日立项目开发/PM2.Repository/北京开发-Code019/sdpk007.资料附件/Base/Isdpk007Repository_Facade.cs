using Gmail.DDD.Orderable;
using Gmail.DDD.PagedList;
using Gmail.DDD.Repositorys;
using PM2.Models.Code019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code019
{
    /// <summary>
    /// 外观层
    /// </summary>
    public interface Isdpk007Repository_Facade : IEFRepository<sdpk007>
    {
        /// <summary>
        /// 删除模块附件
        /// </summary>
        /// <param name="pks"></param>
        void Remove(string[] pks);

        /// <summary>
        /// 获取[模块附件列表]
        /// </summary>
        /// <param name="context">当前[分页参数信息]</param>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        IPagedList GetPageModels(IPageContext context, string pk);

        /// <summary>
        /// 获取[模块附件个数]
        /// </summary>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        int GetFileCount(string pk);

        sdpk007 AddSdpk007(sdpk007 sdpk007);
        sdpk008 AddSdpk008(sdpk008 sdpk008);

    }
}
