using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using PM2.Code;
using PM2.Models.Code001;
using PM2.Repository.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    /// <summary>
    /// 读取数据库 -> 持久化用户信息
    /// </summary>
    public class LossUserSerialization : ILossUserSerialization
    {
        private volatile IEFRepository<sdey003> _sdey003Repository;
        private volatile Isdpj004Repository _sdpj004Repository;
        private volatile IDbContextScopeFactory _scopeFactory;

        public LossUserSerialization(
            IDbContextScopeFactory scopeFactory,
            Isdpj004Repository sdpj004Repository, 
            IEFRepository<sdey003> sdey003Repository)
        {
            this._scopeFactory = scopeFactory;
            this._sdpj004Repository = sdpj004Repository;
            this._sdey003Repository = sdey003Repository;
        }

        #region ILossUserSerialization
        public CurrentUserInfo Serialization(string loginCore, bool isSave)
        {
            CurrentUserInfo userInfo = UserContext.Instance.CurrentUserInfo;
            if (userInfo == null)
            {
                string pj00421 = null;
                //登陆成功 -> 获取用户对象
                using (IDbContextReadOnlyScope dbScope = this._scopeFactory.CreateReadOnlyScope())
                {
                    pj00421 = this._sdey003Repository.Find(x => x.ey00313.Equals(loginCore)).ey00301;
                    userInfo = this._sdpj004Repository.GetUserInfo(pj00421);
                }

                //用户信息持久化
                UserContext.Instance.Serialization(userInfo, isSave);

            }
            return userInfo;
        }
        #endregion
       
    }
}
