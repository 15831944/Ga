using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using Gmail.DDD.Extensions;
using PM2.Models.Code001;
using PM2.Repository.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.Security;
using Gmail.DDD.From;

namespace PM2.Service.Code001
{
    /// <summary>
    /// 根据登录信息 -> 临时设置ByPrj数据库连接
    /// </summary>
    public class LoginTempDbCon : ILogin
    {
        private ILogin _login;
        private IDbContextScopeFactory _scopeFactory;
        private Isdey001Repository _sdey001Repository;

        public LoginTempDbCon(
            Autofac.Features.Indexed.IIndex<Auto_ILogin, ILogin> logins,
            IDbContextScopeFactory scopeFactory,
            Isdey001Repository sdey001Repository
            )
        {
            this._scopeFactory = scopeFactory;
            this._sdey001Repository = sdey001Repository;
            this._login = logins[Auto_ILogin.UserLogin];
        }

        #region ILogin
        public async Task<IOperateResult> LoginAsync(LoginModel login)
        {
            TaskAsync.StartAsync();
            #region 临时设置用户数据库连接
            using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
            {
                string connStr = this._sdey001Repository.GetPrjConn(login.Account);
                if (string.IsNullOrEmpty(connStr))
                    throw new Exception("数据库连接字符串错误.");
                FormsAuthenticationHelper.FromUserData = new FromUserData { DefaultConnectionString = connStr };
            }
            #endregion
            //正常登陆
            return await this._login.LoginAsync(login)
                             .ConfigureAwait(false);

        }
        #endregion
        
    }
}
