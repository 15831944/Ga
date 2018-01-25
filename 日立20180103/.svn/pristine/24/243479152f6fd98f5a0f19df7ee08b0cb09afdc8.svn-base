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

namespace PM2.Service.Code001
{
    public class sdey001Serve : Isdey001Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private Isdey001Repository _sdey001Repository;
        public sdey001Serve(
            IDbContextScopeFactory scopeFactory,
            Isdey001Repository _sdey001Repository)
        {
            this._scopeFactory = scopeFactory;
            this._sdey001Repository = _sdey001Repository;
        }


        /// <summary>
        /// 获取所有账套信息
        /// </summary>
        /// <returns></returns>
        public IOperateResult GetList()
        {
            List<ComboboxItem> data = new List<ComboboxItem>();
            using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
            {
                data.AddRange(this._sdey001Repository.GetModels(order => order.Asc(x => x.ey00101)).Select(x=> new ComboboxItem {
                        id = x.ey00101,
                        text = x.ey00102,
                        selected = x.ey00101.Equals("1001")
                    }).ToList());
            }
            return new ComboboxOperateResult(data);
        }


    }
}
