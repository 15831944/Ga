using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public enum Operation
    {
        All,
        /// <summary>
        /// 只支持导入
        /// </summary>
        Import,
        /// <summary>
        /// 只支持导出
        /// </summary>
        Export
    }
}
