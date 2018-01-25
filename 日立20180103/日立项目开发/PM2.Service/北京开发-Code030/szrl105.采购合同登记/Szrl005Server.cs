using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using PM2.Models.Code030;

namespace PM2.Service.Code030.Szrl105Service
{
    class Szrl005Server : CmDataService<szrl005>, ISzrl005Server
    {
        #region ================= 属性等 ==================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl005> _szrl005Repository;

        public Szrl005Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl005> szrl005Repository
        ) : base(scopeFactory, szrl005Repository)
        {
            this._scopeFactory = scopeFactory;
            _szrl005Repository = szrl005Repository;

        }

        #endregion
    }
}
