using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.JsonConvert;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Web;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030.szrl041Service
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class szrl041Server : CmDataService<szrl041>, Iszrl041Server
    {
        #region ================= 属性等 ==================
        private IDbContextScopeFactory _scopeFactory;
        IEFRepository<szrl004> _szrl004Repository;
        IEFRepository<szrl011> _szrl011Repository;
        IEFRepository<szrl018> _szrl018Repository;
		IEFRepository<szrl041> _szrl041Repository;

        public szrl041Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl004> szrl004Repository,
             IEFRepository<szrl011> szrl011Repository,
             IEFRepository<szrl018> szrl018Repository,
             IEFRepository<szrl041> szrl041Repository
        ) : base(scopeFactory, szrl041Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl004Repository = szrl004Repository;
            this._szrl011Repository = szrl011Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl041Repository = szrl041Repository;

        }

        #endregion


        /// <summary>
        /// 取批量验收详细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public PagerResult Get_szrl042(PagerInfo info)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                PagerResult result = new PagerResult();
                var items = _szrl041Repository.GetModels().ToArray();
                result.total = items.Length;
                result.rows = items.Skip((info.page - 1) * info.rows).Take(info.rows);
                return result;
            }
        }


        /// <summary>
        /// 取批量验收信息
        /// 先按批量验收ID取，不存在则按作番ID取
        /// </summary>
        /// <param name="id">批量验收ID</param>
        /// <param name="zno">作番ID</param>
        /// <returns></returns>
        public szrl041 Get_szrl041(string id, string zid)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var item = _szrl041Repository.GetModels(x => x.rl04101 == id).FirstOrDefault();
                if (item == null)
                {
                    var query = (from m in _szrl018Repository.GetModels()
                            join k in _szrl004Repository.GetModels()
                            on m.rl01802 equals k.rl00401
                            where m.rl01801 == zid
                            select new
                            {
                                m.rl01806,
                                m.rl01807,
                                m.rl01802,
                                k.rl00403
                            }).FirstOrDefault();
                    if (query != null)
                    {
                        item = new szrl041();
                        item.rl04101 = "";
                        item.rl04102 = "";
                        item.rl04103 = query.rl01806;
                        item.rl04104 = query.rl01807;
                        item.rl04105 = query.rl01802;
                        item.rl04106 = query.rl00403;
                    }
                }
                return item;
            }
        }

    }
}
