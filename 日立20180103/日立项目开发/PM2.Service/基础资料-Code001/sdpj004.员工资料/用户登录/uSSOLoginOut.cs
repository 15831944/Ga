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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PM2.Service.Code001
{
    public class uSSOLoginOut : ILoginOut
    {
        #region Init
        /// <summary>
        /// ServerUri -> SSO统一登陆
        /// </summary>
        public Uri LoginUri { private set; get; }

        /// <summary>
        /// ServerUri -> SSO获取令牌
        /// </summary>
        public Uri TokenUri { private set; get; }

        /// <summary>
        /// ServerUri -> (分站: 业务网站)用户退出清除凭证
        /// </summary>
        public Uri LoginOutUri { private set; get; }

        public uSSOLoginOut()
        {
            this.LoginUri = new UriBuilder(PM2Config.Instance.SSOConfig.SSOServer)
            {
                Path = "/Login/Index/"
            }.Uri;
            this.TokenUri = new UriBuilder(PM2Config.Instance.SSOConfig.SSOServer)
            {
                Path = "/SSOServer/TokenVerification/",
                Query = "BackURL={0}"
            }.Uri;
            this.LoginOutUri = new UriBuilder(PM2Config.Instance.SSOConfig.SSOServer)
            {
                Path = "/SSOServer/ClearToken/",
                Query = "tokenKey={0}"
            }.Uri;
        }
        #endregion
        #region ILoginOut
        public IOperateResult LoginOut()
        {
            IOperateResult oResult = null;
            FormsAuthenticationHelper.LoginOut(() =>
            {
                //清空主站凭证
                if (HttpHelper.Request.QueryString["Gmail_Net_Token"] == null)
                {
                    oResult = new RedirectOperateResult(this.GetTokenUrl());
                }
                else
                {
                    if (HttpHelper.Request.QueryString["Gmail_Net_Token"] != "{Token}")
                    {
                        string tokenValue = HttpHelper.Request.QueryString["Gmail_Net_Token"];
                        using (var http = new HttpClient())
                        {
                            //Post 请求
                            var content = new FormUrlEncodedContent(new Dictionary<string, string>() { { "tokenKey", tokenValue } });
                            http.PostAsync(this.LoginOutUri.ToString(), content).Wait();
                        }
                    }
                }
            });
            if (oResult == null)
                oResult = new RedirectOperateResult(this.LoginUri.ToString());
            return oResult;

        }
        #region 主站令牌Url
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetTokenUrl()
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            Regex reg = new Regex(@"^.*\?.+=.+$");
            if (reg.IsMatch(url))
                url += "&Gmail_Net_Token={Token}";
            else
                url += "?Gmail_Net_Token={Token}";

            return string.Format(this.TokenUri.ToString(), HttpUtility.UrlEncode(url));
        }
        #endregion
        #endregion
        
    }
}
