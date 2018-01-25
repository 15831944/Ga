using Gmail.DDD.Helper;
using PM2.Code;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public class SessionUserSerialization : IUserSerialization
    {
        public void Serialization(CurrentUserInfo userInfo, bool isSave)
        {
            SessionStateOperate.Instance.Write(NameParams.UserContext, userInfo);
        }

        public CurrentUserInfo CurrentUserInfo
        {
            get {
                return SessionStateOperate.Instance.Read<CurrentUserInfo>(NameParams.UserContext); 
            }
        }
        public void Clear()
        {
            SessionStateOperate.Instance.Remove(NameParams.UserContext);
        }

    }
}
