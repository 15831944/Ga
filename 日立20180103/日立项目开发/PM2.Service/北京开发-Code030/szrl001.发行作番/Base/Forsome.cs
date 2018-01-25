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
    public  class Forsome
    {
        public Forsome()
        {
            Executed = new int[] { 0, 1, 2 };
            ExternalActuarial = new int[] { 3 };
            Whole = new int[] { 0, 1, 2, 3 };
        }
        /// <summary>
        /// 已执行
        /// </summary>
        public int[] Executed { get; set; }
        /// <summary>
        /// 已外部精算
        /// </summary>
        public int[] ExternalActuarial { get; set; }
        /// <summary>
        /// 全部
        /// </summary>
        public int[] Whole { get; set; }
    }
}
