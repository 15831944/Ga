using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Models.Code030;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using Gmail.DDD.JsonConvert;
using PM2.Service.Code001;
using Gmail.DDD.PagedList;
using Gmail.DDD.Mvc;
using PM2.Repository.Code030;
using System.Data.Entity;
using Gmail.DDD.Config;

namespace PM2.Service.Code030
{
    public class szrlxxxServer : IszrlxxxServer
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl001> _szrl001Repository;
        private IEFRepository<szrl004> _szrl004Repository;
        private IEFRepository<szrl018> _szrl018Repository;

        public szrlxxxServer(
          IDbContextScopeFactory scopeFactory,
           IEFRepository<szrl001> szrl001Repository,
           IEFRepository<szrl004> szrl004Repository,
           IEFRepository<szrl018> szrl018Repository 
      )
        {
            this._scopeFactory = scopeFactory;
            this._szrl001Repository = szrl001Repository;
            this._szrl004Repository = szrl004Repository;
            this._szrl018Repository = szrl018Repository; 
        }
    }
}
