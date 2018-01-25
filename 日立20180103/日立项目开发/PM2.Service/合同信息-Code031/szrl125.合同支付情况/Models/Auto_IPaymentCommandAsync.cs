﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code031
{
    public enum Auto_IPaymentCommandAsync
    {
        /// <summary>
        /// 预付款|验收款
        /// </summary>
        AdvancePaymentAsync,

        /// <summary>
        /// 支付计划调整
        /// </summary>
        AdjustPaymentAsync,

        /// <summary>
        /// 带入验收计划
        /// </summary>
        IntoPaymentAsync,

        /// <summary>
        /// 恢复原支付计划
        /// </summary>
        RestorePaymentAsync

    }
}
