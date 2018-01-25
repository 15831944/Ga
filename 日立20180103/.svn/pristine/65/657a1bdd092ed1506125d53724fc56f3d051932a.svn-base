using FluentValidation;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Gmail.DDD.Extensions;
using PM2.Repository.Code019;
using Gmail.DDD.PagedList;

namespace PM2.Service.Code019
{
    public class sdey007Serve : Isdpk007Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private Isdpk007Repository_Facade _sdpk007Repository;
        public sdey007Serve(
            IDbContextScopeFactory scopeFactory,
            Isdpk007Repository_Facade sdpk007Repository)
        {
            this._scopeFactory = scopeFactory;
            this._sdpk007Repository = sdpk007Repository;
        }

        #region 获取所有账套信息
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">分页参数</param>
        /// <param name="pk">模块ID</param>
        /// <returns></returns>
        public IOperateResult GetModels(IPageContext context, string pk)
        {
            IPagedList pageList = null;
            using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
            {
                pageList = this._sdpk007Repository.GetPageModels(context, pk);
            }
            return OperateResultFactory.GridOperateResult(pageList);
        }
        #endregion
        #region 删除模块附件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pks"></param>
        /// <returns></returns>
        public IOperateResult Remove(string[] pks)
        {
            using (IDbContextScope dbScope = this._scopeFactory.CreateScope())
            {
                this._sdpk007Repository.Remove(pks);
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }
        #endregion

    }
}
