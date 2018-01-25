﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Models.Code001;
using Gmail.DDD.Mvc;
using Gmail.DDD.PagedList;

namespace PM2.Service.Code030
{
    public interface Isdbo001Server : IService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IOperateResult GetIndexInfo(IRequestGetter context);
        /// <summary>
        /// 保存和修改
        /// </summary>
        /// <param name="sf"></param>
        /// <returns></returns>
        IOperateResult Add(Staffing_sdbo001 sf,IRequestGetter context);
        /// <summary>
        /// 查询人员集合
        /// </summary>
        /// <returns></returns>
        IOperateResult List_sdpj004(IPageContext context);
        object List_sdpj004_2();
        IOperateResult List_sdpj004_3(IPageContext context);
    }
}
