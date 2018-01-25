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
using Gmail.DDD.JsonConvert;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;
using System.Threading;

namespace PM2.Service.Code001
{
    public class SSOUserLogin : ILogin
    {
        private ILogin _login;
        public SSOUserLogin(
            Autofac.Features.Indexed.IIndex<Auto_ILogin, ILogin> logins
            )
        {
            this._login = logins[Auto_ILogin.LoginTempDbCon];
        }

        #region ILogin
        public async Task<IOperateResult> LoginAsync(LoginModel login)
        {
            try
            {
                TaskAsync.StartAsync();
                //正常登陆
                IOperateResult loginResult = await this._login.LoginAsync(login)
                                                       .ConfigureAwait(false);
                if (loginResult.GetResultType<LoginOperateResultType>() == LoginOperateResultType.Error)
                    return loginResult;

                //SSO-Login
                loginResult = SSOProviderConfig.Instance.Login(FormsAuthenticationHelper.FromUserData, login.BackUrl, true) ?? loginResult;
                return loginResult;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
