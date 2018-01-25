using PM2.Models.Code001;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public interface IUserSerialization
    {
         /// <summary>
         /// 持久化
         /// </summary>
         /// <param name="userInfo"></param>
         /// <param name="isSave">针对 Coorie生效</param>
         void Serialization(CurrentUserInfo userInfo, bool isSave);

         /// <summary>
         /// 得到当前登陆的实体
         /// </summary>
         CurrentUserInfo CurrentUserInfo { get; }

         /// <summary>
         /// 清楚实体
         /// </summary>
         void Clear();
    }
}
