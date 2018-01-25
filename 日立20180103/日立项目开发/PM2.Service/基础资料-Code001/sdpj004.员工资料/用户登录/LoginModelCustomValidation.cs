using FluentValidation;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Gmail.DDD.Service;

namespace PM2.Service.Code001
{
    public class LoginModelCustomValidation : ModelCustomValidation<LoginModel>
    {
        private IEFRepository<sdey003> _sdey003Repository;
        private IDbContextScopeFactory _scopeFactory;
        public LoginModelCustomValidation(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdey003> sdey003Repository,
            IEFRepository<sdey003> sdey003Repositoryx)
        {
            this._scopeFactory = scopeFactory;
            this._sdey003Repository = sdey003Repository;
        }

        #region 验证机制
        protected override void Validation(LoginModel entity, System.Web.Mvc.ModelStateDictionary errors)
        {
            using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
            {
                sdey003 sdey003 = this._sdey003Repository.Find(x => x.ey00313.Equals(entity.LoginCode));
                string _ey00301 = sdey003 == null ? null : sdey003.ey00301;
                if (string.IsNullOrEmpty(_ey00301))
                {
                    errors.AddModelError("LoginCode", "没有这个用户....");
                }
            }
        }
        #endregion
    }
}
