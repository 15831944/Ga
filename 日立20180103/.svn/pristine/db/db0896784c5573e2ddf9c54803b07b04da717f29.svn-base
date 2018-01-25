using Gmail.DDD.Service;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface IExportHeaderCommand : IService
    {
        event EventHandler<ExportContext> SuccessEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit">基本操作单元</param>
        /// <param name="context">单元格式构造</param>
        /// <param name="hAttributes">获取模型[表头集合]特性</param>
        void Execute(IExcelUnitWork unit, ExportContext context, IEnumerable<ExcelAttribute> hAttributes);
    }
}
