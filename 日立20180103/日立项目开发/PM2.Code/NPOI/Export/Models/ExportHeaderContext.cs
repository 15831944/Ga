using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ExportContext : OperaConext
    {
        /// <summary>
        /// 自定义单元格样式
        /// </summary>
        public CellStyleContext CellStyleContext { get; set; }
    }
}
