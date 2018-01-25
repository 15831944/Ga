using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code001
{
    public interface Isdpj004Repository : IEFRepository<sdpj004>
    {
        /// <summary>
        /// 获取用户对象
        /// </summary>
        /// <param name="pj00421">用户编码</param>
        /// <returns></returns>
        CurrentUserInfo GetUserInfo(string pj00421);
    }
}
