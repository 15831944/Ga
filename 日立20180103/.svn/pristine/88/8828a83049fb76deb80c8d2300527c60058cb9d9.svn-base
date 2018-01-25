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
using System.Data.Entity;

namespace PM2.Service.Code001
{
    public sealed class sdpj004TreeExtensions : IEasyTreeExtensions
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdpj004> _sdpj004Repository;
        public sdpj004TreeExtensions(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdpj004> _sdpj004Repository)
        {
            this._scopeFactory = scopeFactory;
            this._sdpj004Repository = _sdpj004Repository;
        }

        #region ITreeExtensions
        public IEnumerable<IEasyTreeNode> Addition(IEnumerable<IEasyTreeNode> source)
        {
            IEnumerable<IEasyTreeNode> nodes = source.AsEnumerable();
            using (IDbContextReadOnlyScope readScope = this._scopeFactory.CreateReadOnlyScope())
            {
                return nodes.Concat(this._sdpj004Repository.GetModels().Select(
                        x => new EasyTreeNode
                        {
                            ID = x.pj00401,
                            Text = x.pj00402,
                            ParentId = x.pj00417,
                            OrderBy = x.pj00421,
                            Params = new { nodeType = "sdpj004", pj00421 = x.pj00421 }
                        }
                    ).ToArray());
            }
        }
        #endregion

    }
}