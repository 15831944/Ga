using Gmail.DDD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    public class szrl105Model : Enttity 
    {
        /// <summary>
        /// 合同ID
        /// </summary>
        public string rl10503 { get; set; }

        /// <summary>
        /// 支付计划ID
        /// </summary>
        public string rl10701 { get; set; }

        /// <summary>
        /// 计划支付日期
        /// </summary>
        public string rl10707 { get; set; }

        /// <summary>
        /// 计划支付%
        /// </summary>
        public decimal rl10708 { get; set; }

        /// <summary>
        /// 计划支付金额
        /// </summary>
        public decimal rl10709 { get; set; }
    }
}
