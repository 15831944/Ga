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
    public class sdpj003TreeFacade : EasyTreeBaseAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdpj003> _sdpj003Repository;
        private IEFRepository<sdpj025> _sdpj025Repository;
        public sdpj003TreeFacade(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdpj003> sdpj003Repository,
            IEFRepository<sdpj025> sdpj025Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._sdpj003Repository = sdpj003Repository;
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
            #region 获取公司信息
            IEnumerable<IEasyTreeNode> sdpj25Nodes = null;
            using (IDbContextReadOnlyScope readScope = this._scopeFactory.CreateReadOnlyScope())
            {
                sdpj25Nodes = await this._sdpj025Repository.GetModels().Select(
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
            #endregion
            #region 获取部门信息
            IEnumerable<IEasyTreeNode> sdpj003Nodes = null;
            using (IDbContextReadOnlyScope readScope = this._scopeFactory.CreateReadOnlyScope())
            {
                sdpj003Nodes = await this._sdpj003Repository.GetModels().Select(
                    x => new EasyTreeNode
                    {
                        ID = x.pj00301,
                        Text = x.pj00302,
                        ParentId = string.IsNullOrEmpty(x.pj00303) ? x.pj00311 : x.pj00303,
                        OrderBy = x.pj00304,
                        Params = new { nodeType = "sdpj003" }
                    }
               ).ToArrayAsync();
            }
            #endregion
            try
            {
                #region Tree
                IEnumerable<IEasyTreeNode> treeNodes = sdpj25Nodes.Concat(sdpj003Nodes);
                if (this.TreeExtensions != null)
                    treeNodes = this.TreeExtensions.Addition(treeNodes);
                return OperateResultFactory.TreeOperateResult(treeNodes, "部门信息");
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