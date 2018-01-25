using Gmail.DDD.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;
using NPOI.SS.UserModel;

namespace PM2.Code.NPOI
{
    public class ExportDataCommand : IExportDataCommand
    {
        /// <summary>
        /// 导出成功
        /// </summary>
        public event EventHandler<ExportContext> SuccessEvent;

        #region IExportDataCommand
        public void Execute<TModel>(IExcelUnitWork unit, ExportContext context, IEnumerable<TModel> source) 
            where TModel : IEntity
        {
            var props = from x in EntityMetadataProviders.Instance.GetMetadataForType(typeof(TModel), null).Properties
                        from y in x.GetAttributes<ExcelAttribute>()
                        where (y.Operation == Operation.All || y.Operation == Operation.Export) && y.HraderGroup == HraderGroupEnum.Three
                        select new KeyValuePair<EntityMetadataContext, ExcelAttribute>(x, y); 

            #region 设置数据格式:值
            foreach (var date in source)
            {
                int cIndex = context.CellIndex;
                foreach (KeyValuePair<EntityMetadataContext, ExcelAttribute> prop in props)
                {
                    string value = prop.Key.PropertyDescriptor.GetValue(date).ToString();
                    if (context.CellStyleContext != null)
                        unit.SetCellValue(context.RowIndex, cIndex, value, context.CellStyleContext);
                    else
                        unit.SetCellValue(context.RowIndex, cIndex, value, prop.Value.CStyle);
                    cIndex = cIndex + 1;
                }
                context.RowIndex += 1;
            }
            #endregion

            if (this.SuccessEvent != null)
                this.SuccessEvent.Invoke(this, context);

        }
        #endregion

    }
}
