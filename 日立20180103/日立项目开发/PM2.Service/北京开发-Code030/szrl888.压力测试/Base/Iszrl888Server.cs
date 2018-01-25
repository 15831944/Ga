using Gmail.DDD.PagedList;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    /// <summary>
    /// 作番导航选择
    /// </summary>
    public  interface Iszrl888Server: IService
    {
        Task<IOperateResult> info(IPageContext context);
        Task<IOperateResult> add(szrl888 _szrl888);
        Task<IOperateResult> edit(szrl888 _szrl888);
        Task<IOperateResult> remove(string vid);
        Task<IOperateResult> editinfo(string vid);

        Task<IOperateResult> GetModuleWeb();
    }
}
