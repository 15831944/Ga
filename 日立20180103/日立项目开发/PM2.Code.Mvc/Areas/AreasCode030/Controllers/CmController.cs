using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.Repositorys;
using PM2.Service.Code030.CM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class CmController<TEntity> : Controller where TEntity : Enttity
    {
        private ICmDataService<TEntity> _dataService;
        private IEFRepository<TEntity> _entityRepository;
        public CmController(IDbContextScopeFactory scopeFactory, IEFRepository<TEntity> entityRepository)
        {
            _dataService = new CmDataService<TEntity>(scopeFactory, entityRepository);
            _entityRepository = entityRepository;
        }

        [HttpPost]
        public ActionResult GetAll()
        {
            var list = _dataService.FindAll();
            return Json(list);
        }
    }
}