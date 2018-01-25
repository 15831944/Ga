using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030.szrl041Service
{
    public interface Iszrl041Server : IService, ICmDataService<szrl041>
    {
        /// <summary>
        /// 取批量验收详细信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        PagerResult Get_szrl042(PagerInfo info);


        /// <summary>
        /// 取批量验收信息
        /// 先按批量验收ID取，不存在则按作番号取
        /// </summary>
        /// <param name="id">批量验收ID</param>
        /// <param name="zno">作番号</param>
        /// <returns></returns>
        szrl041 Get_szrl041(string id, string zno);
    }
}
