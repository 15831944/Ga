#region using
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
using PM2.Models.Code031;
using System.Data.Entity;
using PM2.Repository.Code031;
using PM2.Service.Code001;
using PM2.Models.Code030.Szrl105Model;
#endregion
namespace PM2.Service.Code031
{
    public class szrl105TreeExtensions : IEasyTreeExtensions
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<Szrl105> _szrl105Repository;
        private IEFRepository<szrl125> _szrl125Repository;
        public szrl105TreeExtensions(IDbContextScopeFactory scopeFactory,
            IEFRepository<Szrl105> szrl105Repository,
            IEFRepository<szrl125> szrl125Repository
            )
        {
            this._scopeFactory = scopeFactory;
            this._szrl105Repository = szrl105Repository;
            this._szrl125Repository = szrl125Repository;
        }
        public IEnumerable<IEasyTreeNode> Addition(IEnumerable<IEasyTreeNode> source)
        {
            #region 获取合同附加信息
            using (IDbContextReadOnlyScope scope = this._scopeFactory.CreateReadOnlyScope())
            {
                var query = from x in this._szrl105Repository.GetModels(x => x.rl10572 == 1)
                            join y in this._szrl125Repository.GetModels()
                            on x.rl10503 equals y.rl12502 into szrl125s
                            from z in szrl125s.DefaultIfEmpty()
                            select new EasyTreeNode
                            {
                                ID = x.rl10503,
                                Text = "[" + x.rl10505 + "]",
                                ParentId = x.rl10502,
                                OrderBy = x.rl10505,
                                Params = new { nodeType = "szrl105", rl12507 = z == null ? -1 : z.rl12507 }
                            };
                IEnumerable<IEasyTreeNode> szrl105s = query.ToList();
                if (!szrl105s.IsNullOrEmpty())
                    return source.Concat(szrl105s);
                return source;
            }
            #endregion
            
        }
    }
}
