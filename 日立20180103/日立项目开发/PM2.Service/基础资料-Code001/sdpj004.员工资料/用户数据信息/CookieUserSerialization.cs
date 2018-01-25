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
    public class CookieUserSerialization : IUserSerialization
    {
        public void Serialization(CurrentUserInfo userInfo, bool isSave)
        {
            Nullable<DateTime> time = null;
            if(isSave)
                time = DateTime.Now.AddDays(7);

            CookieStateOperate.Instance.Write<CurrentUserInfo>(NameParams.UserContext, userInfo, time);
        }
        public CurrentUserInfo CurrentUserInfo
        {
            get { return CookieStateOperate.Instance.Read<CurrentUserInfo>(NameParams.UserContext); }
        }
        public void Clear()
        {
            CookieStateOperate.Instance.Remove(NameParams.UserContext);
        }

    }
}
