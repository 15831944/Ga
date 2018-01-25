using Gmail.DDD.Entity;
using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface ImportDataCommand: IService
    {
        /// <summary>
        /// [数据转换]
        /// </summary>
        event EventHandler<ConvertContext> ConvertEvent;

        /// <summary>
        /// [数据验证]
        /// </summary>
        event EventHandler<ValidationContext> ValidationEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit">基本操作单元</param>
        /// <param name="context">单元格式构造</param>
        IEnumerable<TModel> Execute<TModel>(IExcelUnitWork unit, ImportContext context)
            where TModel : IEntity;
    }
}
