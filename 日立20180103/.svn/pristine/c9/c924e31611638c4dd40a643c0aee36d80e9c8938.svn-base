using Gmail.DDD.Entity;
using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface IExportDataCommand : IService
    {
        event EventHandler<ExportContext> SuccessEvent;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit">基本操作单元</param>
        /// <param name="context">单元格式构造</param>
        /// <param name="source">导出数据源</param>
        void Execute<TModel>(IExcelUnitWork unit, ExportContext context, IEnumerable<TModel> source) 
            where TModel : IEntity;

    }

}
