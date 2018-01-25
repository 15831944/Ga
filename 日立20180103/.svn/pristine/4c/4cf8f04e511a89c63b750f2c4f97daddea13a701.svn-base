using Gmail.DDD.AOP;
using Gmail.DDD.Config;
using Gmail.DDD.Helper;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Models;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public class uLoginOut : ILoginOut
    {
        public IOperateResult LoginOut()
        {
            FormsAuthenticationHelper.LoginOut(() => {

                //删除主站SSO-用户凭证Key
                string key = CookieStateOperate.Instance.Read("Gmail_Net_Token");
                SSOProviderConfig.Instance.LoginOut(key);
                //删除临时主站令牌Cookie
                CookieStateOperate.Instance.Remove("Gmail_Net_Token");

            });
            return new RedirectOperateResult(System.Web.Security.FormsAuthentication.LoginUrl);

        }
    }
}
