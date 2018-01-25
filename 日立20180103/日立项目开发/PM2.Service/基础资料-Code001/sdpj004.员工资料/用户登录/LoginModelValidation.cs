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
    public class LoginModelValidation : ModelFluentValidation<LoginModel>
    {
        private IEFRepository<sdey003> _sdey003Repository;
        private IDbContextScopeFactory _scopeFactory;
        public LoginModelValidation(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdey003> sdey003Repository,
            IEFRepository<sdey003> sdey003Repositoryx)
        {
            this._scopeFactory = scopeFactory;
            this._sdey003Repository = sdey003Repository;
        }

        #region 验证机制
        protected override void Validation()
        {
            this.RuleFor(p => p.LoginCode).Must((model, value) =>
            {
                using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
                {
                    sdey003 sdey003 = this._sdey003Repository.Find(x => x.ey00313.Equals(value));
                    string _ey00301 = sdey003 == null ? null : sdey003.ey00301;
                    return !string.IsNullOrEmpty(_ey00301);
                }

            }).WithMessage("用户名|密码不存在.");

        }
        #endregion
        
    }
}
