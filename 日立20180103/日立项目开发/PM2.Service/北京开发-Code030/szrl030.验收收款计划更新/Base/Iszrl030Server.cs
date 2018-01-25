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
    public interface Iszrl030Server : IService
    {
        IOperateResult QueryBasicData(HttpCollection vParams);
        IOperateResult QueryGridData(HttpCollection vParams);
        IOperateResult QueryKXXZ(HttpCollection vParams);
        IOperateResult Insert3032(IRequestGetter vParams);
        IOperateResult Insert2224(HttpCollection vParams);
    }
}
