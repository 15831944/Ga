using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ConvertContext : System.EventArgs
    {
        /// <summary>
        /// 当前[单元格头文]
        /// </summary>
        public ECHeadEnum ECHeadEnum { get; set; }

        /// <summary>
        /// 当前[单元格元数据]
        /// </summary>
        public PropertyDescriptor PropertyDescriptor { get; set; }

        /// <summary>
        /// 当前[单元格数据]
        /// </summary>
        public object CurrentValue { get; set; }

        /// <summary>
        /// 变更[单元格数据]
        /// </summary>
        private object result;
        public object Result { set { this.result = value; } get { return this.result ?? this.CurrentValue; } }

    }
}
