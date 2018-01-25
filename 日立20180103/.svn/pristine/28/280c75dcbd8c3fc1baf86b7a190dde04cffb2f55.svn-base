using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Models.Code001;
using Gmail.DDD.PagedList;
using Gmail.DDD.Mvc;

namespace PM2.Service.Code030
{
    public interface Iszrl116Server: IService
    {
        IEnumerable<szrl116TableEntity> QueryOfferTable(int pageIndex, int pageSize, out int rowCount);
        IOperateResult ClickOfferSendBag(szrl116 model);
        IOperateResult ClickPlanB(szrl116 model,string zuofanid,string hetongid);
        IOperateResult QueryWarmLists(IPageContext vParams);
        IOperateResult HaveDone(szrl116 model);
        IOperateResult NextTime(szrl116 model);
        IOperateResult ReturnBtn(szrl116 model);
        IOperateResult AcceptBtn(szrl116 model);
        IOperateResult KPRQ(szrl116 model);
        IOperateResult GCBCL(szrl116 model);
        IOperateResult GCBCLGB(szrl116 model);
    }
}
