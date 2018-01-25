﻿using System;
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
    public interface Iszrl035Server : IService
    {
        IOperateResult QueryGridData(HttpCollection vParams);
        IEnumerable<szrl035BasicData> QueryBasicData(HttpCollection vParams);
        IOperateResult QueryYSJHGridData(HttpCollection vParams);
        IOperateResult QueryPLYSDJGridData(HttpCollection vParams);
        IOperateResult Insert3536(HttpCollection vParams);
        IOperateResult Query036GridData(HttpCollection vParams);
        IOperateResult DelGridData(HttpCollection vParams);
        IOperateResult AdmitPLYSDJData(HttpCollection vParams);
        IOperateResult SCKPTZ_035(HttpCollection vParams);
    }
}
