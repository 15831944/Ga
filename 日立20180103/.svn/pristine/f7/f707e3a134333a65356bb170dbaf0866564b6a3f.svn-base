using Gmail.DDD.DataContext;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Repositorys.SQLBuilding;
using Gmail.DDD.Service;
using Gmail.DDD.Utility;
using PM2.Code;
using PM2.Models.Code100;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public class Code001ModuleManager : ModuleManager
    {
        public override void Load()
        {
            //账套管理
            this.RegisterType<sdey001Serve, Isdey001Server>();
            #region 用户登录|登出
            //用户登录
            this.RegisterType<UserLogin, ILogin>(serviceName: Auto_ILogin.UserLogin);
            //根据登录信息 -> 临时设置ByPrj数据库连接
            this.RegisterType<LoginTempDbCon, ILogin>(serviceName: Auto_ILogin.LoginTempDbCon);
            //SSO用户登录
            this.RegisterType<SSOUserLogin, ILogin>(serviceName: Auto_ILogin.SSOUserLogin);
            //从数据库读取 -> 持久化用户信息
            this.RegisterType<LossUserSerialization, ILossUserSerialization>();

            //用户登出-主站
            this.RegisterType<uLoginOut, ILoginOut>(serviceName: Auto_ILoginOut.LoginOut);
            //用户登出-分站
            this.RegisterType<uSSOLoginOut, ILoginOut>(serviceName: Auto_ILoginOut.SSOLoginOut);
            #endregion

            //部门Tree
            this.RegisterType<sdpj003TreeFacade, IEasyTreeAsync>(serviceName: Auto_TreeType.sdpj003Tree);
            //公司Tree
            this.RegisterType<sdpj025TreeFacade, IEasyTreeAsync>(serviceName: Auto_TreeType.sdpj025Tree);
            //人员Tree
            this.RegisterType<sdpj004TreeExtensions, IEasyTreeExtensions>(serviceName: Auto_TreeType.sdpj004Tree);

            //公司维护
            this.RegisterType<sdpj025Serve, Isdpj025Server>();
            //部门维护
            this.RegisterType<sdepj003Serve, Isdpj003Server>();
            //部门人员维护
            this.RegisterType<sdpj004Serve, Isdpj004Server>();

        }
    }
}
