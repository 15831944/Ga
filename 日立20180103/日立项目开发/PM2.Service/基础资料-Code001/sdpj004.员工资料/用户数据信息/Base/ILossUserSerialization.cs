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
    public interface ILossUserSerialization : IScopeDependency
    {
        CurrentUserInfo Serialization(string loginCore, bool isSave);

    }
}
