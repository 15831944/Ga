using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.PagedList;
using Gmail.DDD.Service;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl111Model;

namespace PM2.Service.Code030
{
    public class klbdeSaver : IklbdeServer
    {

        #region ==========================注入========================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl111> _szrl111Repository;
        public klbdeSaver(
              IDbContextScopeFactory scopeFactory,
              IEFRepository<szrl111> szrl111Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._szrl111Repository = szrl111Repository;
        }
        #endregion




        /// <summary>
        /// 查询表格数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IOperateResult Selectdg(IPageContext context)
        {
            throw new NotImplementedException();
        }

     



    }
}
