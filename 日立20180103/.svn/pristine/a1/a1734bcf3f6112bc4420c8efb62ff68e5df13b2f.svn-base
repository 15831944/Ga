using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Repositorys;
using Gmail.DDD.PagedList;
using PM2.Models.Code030.szrl111Model;
using Gmail.DDD.Mvc;

namespace PM2.Repository.Code030
{
    public interface Iszrl111Repository_Facade : IEFRepository<szrl111>
    {
        /// <summary>
        /// 显示材料科明细--用于勾选
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        //IPagedList GetPageModels_111(IRequestGetter context, string rl11211);

        IEnumerable<szrl112> GetPageModels_111(string rl11211);
    }
}
