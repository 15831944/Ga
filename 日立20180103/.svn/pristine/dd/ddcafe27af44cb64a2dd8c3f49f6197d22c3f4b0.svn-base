
using FluentValidation;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.From;
using Gmail.DDD.Helper;
using Gmail.DDD.Mvc;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Models.Code001;
using PM2.Repository.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PM2.Service.Code001
{
    public class UserLogin : ILogin
    {
        private ILossUserSerialization _userSerialization;
        public UserLogin(
            ILossUserSerialization userSerialization)
        {
            this._userSerialization = userSerialization;
        }

        #region ILogin
        [ModelValidation(typeof(LoginModelValidation), false)]
        [ModelValidation(typeof(LoginModelCustomValidation))]
        public async Task<IOperateResult> LoginAsync([InArgsValidation]LoginModel login)
        {
            TaskAsync.StartAsync();
            await Task.Factory.StartNew(() =>
            {
                bool isTrue = System.Web.HttpContext.Current == null;

                //读取数据库 -> 用户信息持久化
                this._userSerialization.Serialization(login.LoginCode, login.RememBerMe);
            }).ConfigureAwait(false);

            #region From 身份认证
            int expiration = login.RememBerMe ? 7 : 0;
            FormsAuthenticationHelper.FormsAuthentication(login.LoginCode, new FromUserData
            {
                LoginCore = login.LoginCode,
                Account = login.Account,
                DefaultConnectionString = FormsAuthenticationHelper.FromUserData.DefaultConnectionString
            }, expiration);
            #endregion
            return new LoginOperateResult(LoginOperateResultType.Success);

        }
        #endregion

    }
}
