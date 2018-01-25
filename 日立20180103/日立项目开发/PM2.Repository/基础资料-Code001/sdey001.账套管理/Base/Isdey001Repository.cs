using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code001
{
    public interface Isdey001Repository : IEFRepository<PM2.Models.sdey001>
    {
        /// <summary>
        /// 根据[账套号]获取:PrjConn
        /// </summary>
        /// <returns></returns>
        string GetPrjConn(string Account);
    }
}
