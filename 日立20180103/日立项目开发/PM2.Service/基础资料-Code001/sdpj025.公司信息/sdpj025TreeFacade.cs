using FluentValidation;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Code;
using PM2.Models.Code001;
using PM2.Repository.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Gmail.DDD.Extensions;
using Gmail.DDD.JsonConvert;
using Gmail.DDD.Orderable;
using System.Threading;
using Gmail.DDD.Mvc;
using System.Data.Entity;

namespace PM2.Service.Code001
{
    public class sdpj025TreeFacade : EasyTreeBaseAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdpj025> _sdpj025Repository;
        public sdpj025TreeFacade(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdpj025> sdpj025Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._sdpj025Repository = sdpj025Repository;
        }

        #region 构建Tree
        /// <summary>
        /// 构建Tree
        /// </summary>
        /// <returns></returns>
        public override async Task<IOperateResult> TreeLoadAsync(IRequestGetter rGetter = null)
        {
            TaskAsync.StartAsync();
            try
            {
                #region 构建Tree
                IEnumerable<IEasyTreeNode> treeNodes = null;
                using (IDbContextReadOnlyScope readScope = this._scopeFactory.CreateReadOnlyScope())
                {
                    treeNodes = await this._sdpj025Repository.GetModels().Select(
                        x => new EasyTreeNode
                        {
                            ID = x.pj02501,
                            Text = x.pj02505,
                            ParentId = x.pj02502,
                            OrderBy = x.pj02504,
                            Params = new { nodeType = "sdpj25" }
                        }
                    ).ToArrayAsync();
                }
                return OperateResultFactory.TreeOperateResult(treeNodes);
                #endregion
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(ex.Message);
                throw ex;
            }
        }
        #endregion
    }
}