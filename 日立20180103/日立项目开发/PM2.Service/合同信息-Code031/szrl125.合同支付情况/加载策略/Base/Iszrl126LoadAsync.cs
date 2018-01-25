﻿using Gmail.DDD.Service;
using PM2.Models.Code031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code031
{
    public interface Iszrl126LoadAsync: IService
    {
        /// <summary>
        /// 加载[待支付确认]合同支付情况
        /// </summary>
        /// <param name="rl12502">合同ID</param>
        /// <returns></returns>
        Task<IEnumerable<szrl126SVEntity>> LoadAsync(string rl12502);
    }
}
