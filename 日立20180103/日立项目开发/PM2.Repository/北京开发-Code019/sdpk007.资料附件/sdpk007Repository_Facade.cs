using Gmail.DDD.Repositorys;
using Gmail.DDD.Utility;
using Gmail.DDD.Extensions;
using PM2.Models.Code019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Gmail.DDD.DataContext;
using Gmail.DDD.PagedList;
using PM2.Models.Code001;

namespace PM2.Repository.Code019
{
    /// <summary>
    /// 外观层: 隐藏子系统 
    ///   -> 子系统: 相关或相互依赖的对象.
    /// 
    /// </summary>
    public class sdpk007Repository_Facade : EFRepository<sdpk007>, Isdpk007Repository_Facade
    {
        private IEFRepository<sdpj004> _sdpj004Repository;
        private IEFRepository<sdpk008> _sdpk008Repository;
        public sdpk007Repository_Facade(IDbContextFactory factory, IUnitOfWork unitOfWork,
            IEFRepository<sdpj004> sdpj004Repository,
            IEFRepository<sdpk008> sdpk008Repository
            )
            : base(factory, unitOfWork)
        {
            this._sdpj004Repository = sdpj004Repository;
            this._sdpk008Repository = sdpk008Repository;
        }

        #region 获取[模块附件列表]
        /// <summary>
        /// 获取[模块附件列表]
        /// </summary>
        /// <param name="context">当前[分页参数信息]</param>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        public IPagedList GetPageModels(IPageContext context, string pk)
        {
            IQueryable<sdpj004> sdpj004s = this._sdpj004Repository.GetModels();
            var query = from x in this.GetModels(x => x.pk00702.Equals(pk))
                        join z in sdpj004s
                        on x.sdpk008.pk00807 equals z.pj00421
                        orderby x.sdpk008.pk00805
                        select new
                        {
                            pk = x.sdpk008.pk00801, //附件ID
                            x.sdpk008.pk00803,      //附件名称
                            x.sdpk008.pk00805,      //创建时间
                            z.pj00402               //创建人
                        };
            return query.ToPagedList(context);
        }
        #endregion
        #region 获取[模块附件个数]
        /// <summary>
        /// 获取[模块附件个数]
        /// </summary>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        public int GetFileCount(string pk)
        {
            var query = from x in this.GetModels(x => x.pk00702.Equals(pk))
                        select x;
            return query.Count();
        }
        #endregion

        #region 添加附件
        /// <summary>
        /// 主表
        /// </summary>
        /// <param name="sdpk007"></param>
        /// <returns></returns>
        public sdpk007 AddSdpk007(sdpk007 sdpk007)
        {
            return this.Add(sdpk007);
        }

        /// <summary>
        /// 从表
        /// </summary>
        /// <param name="sdpk008"></param>
        /// <returns></returns>
        public sdpk008 AddSdpk008(sdpk008 sdpk008)
        {
            return this._sdpk008Repository.Add(sdpk008);
        }
        #endregion
        #region 删除附件
        /// <summary>
        /// 删除模块附件
        /// </summary>
        /// <param name="pks"></param>
        public void Remove(string[] pks)
        {
            string sql = "delete from sdpk007 where pk00701 in('" + pks.JoinToString().Replace(",", "','") + "');delete from sdpk008 where pk00801 in('" + pks.JoinToString().Replace(",", "','") + "')";
            this.SQLHelper.ExecuteNonQuery(sql);
        }
        #endregion

    }
}
