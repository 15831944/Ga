using Gmail.DDD.Extensions;
using Gmail.DDD.Mvc;
using Gmail.DDD.PagedList;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Utility;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl111Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code030
{
    public class szrl111Repository_Facade : EFRepository<szrl111>, Iszrl111Repository_Facade
    {
        private IEFRepository<szrl083> _szrl083Repository;
        private IEFRepository<szrl112> _szrl112Repository;
        public szrl111Repository_Facade(IDbContextFactory factory, IUnitOfWork unitOfWork,
           IEFRepository<szrl083> szrl083Repository,
           IEFRepository<szrl112> szrl112Repository
        ) : base(factory, unitOfWork)
        {
             this._szrl083Repository = szrl083Repository;
            this._szrl112Repository = szrl112Repository;
        }
        /// <summary>
        /// 材料库分页--KLBDE明细勾选材料库最下级目录时使用
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        //public IPagedList GetPageModels_111(IRequestGetter context, string rl11211)
        //{
        //    IQueryable<szrl112> query_szrl112s = this._szrl112Repository.GetModels(x => x.rl11209.Equals(rl11211) && x.rl11211.Length.Equals(rl11211_max));
        //    return query_szrl112s.ToPagedList(context);
        //}
        public IEnumerable<szrl112> GetPageModels_111(string rl11211)
        {
            int rl11211_max = this._szrl112Repository.GetModels(x => x.rl11209.Equals(rl11211)).Max(x => x.rl11211.Length);
            IEnumerable<szrl112> query_szrl112s = this._szrl112Repository.GetModels(x => x.rl11209.Equals(rl11211) && x.rl11211.Length.Equals(rl11211_max));
            return query_szrl112s;
        }
    }
}
