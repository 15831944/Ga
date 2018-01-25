using Gmail.DDD.Config;
using Gmail.DDD.From;
using Gmail.DDD.Helper;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public sealed class UserContext
    {
        #region Init
        private static readonly Lazy<IUserSerialization> _instance = new Lazy<IUserSerialization>(() =>
        {
            IUserSerialization o = null;
            switch (int.Parse(PM2Config.Instance.GetSetting("UserPersistence")))
            {
                case 0:
                    o = new SessionUserSerialization();
                    break;
                case 1:
                    o = new CookieUserSerialization();
                    break;
            }
            return o;

        }, true);
        public static IUserSerialization Instance { get { return _instance.Value; } }
        static UserContext() { }
        private UserContext()
        {
            
        }

        #endregion

        private static CurrentUserInfo CurrentUserInfo
        {
            get {
                CurrentUserInfo o = Instance.CurrentUserInfo;
                #region 持久化信息失效 - 重新持久化
                if (o == null)
                {
                    //获取用户凭证数据
                    FromUserData uData = FormsAuthenticationHelper.FromUserData;
                    if (uData == null)
                        throw new Exception("请求未认证,获取失败.");
                    ILossUserSerialization uSerialization = DependencyConfig.Instance.Container.Resolve<ILossUserSerialization>();
                    o = uSerialization.Serialization(uData.LoginCore, false);
                }
                #endregion
                return o; 
            }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public static string Pj00401 { get { return UserContext.CurrentUserInfo.Pj00401; } }
        
        /// <summary>
        /// 用户姓名
        /// </summary>
        public static string Pj00402 { get { return UserContext.CurrentUserInfo.Pj00402; } }
        
        /// <summary>
        /// 用户编码
        /// </summary>
        public static string Pj00421 { get { return UserContext.CurrentUserInfo.Pj00421; } }
        
        /// <summary>
        /// 部门ID
        /// </summary>
        public static string Pj00301 { get { return UserContext.CurrentUserInfo.Pj00301; } }
        
        /// <summary>
        /// 部门名称
        /// </summary>
        public static string Pj00302 { get { return UserContext.CurrentUserInfo.Pj00302; } }
        
        /// <summary>
        /// 公司ID
        /// </summary>
        public static string Pj02501 { get { return UserContext.CurrentUserInfo.Pj02501; } }
        
        /// <summary>
        /// 公司名称
        /// </summary>
        public static string Pj02505 { get { return UserContext.CurrentUserInfo.Pj02505; } }

    }
}
