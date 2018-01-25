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
    public class EImportDataCommand : ImportDataCommand
    {
        public event EventHandler<ConvertContext> ConvertEvent;
        public event EventHandler<ValidationContext> ValidationEvent;

        public IEnumerable<TModel> Execute<TModel>(IExcelUnitWork unit, ImportContext context) 
            where TModel : IEntity
        {
            var props = from x in EntityMetadataProviders.Instance.GetMetadataForType(typeof(TModel), null).Properties
                        from y in x.GetAttributes<ExcelAttribute>()
                        where (y.Operation == Operation.All || y.Operation == Operation.Import) && y.HraderGroup == HraderGroupEnum.Three && y.ECHeadEnum != ECHeadEnum.None
                        select new KeyValuePair<EntityMetadataContext, ExcelAttribute>(x,y); 
            return this.Import<TModel>(props, unit, context);
        }
        #region 导入数据
        private IEnumerable<TModel> Import<TModel>(IEnumerable<KeyValuePair<EntityMetadataContext, ExcelAttribute>> props, IExcelUnitWork unit, ImportContext context)
            where TModel : IEntity
        {
            IRow hRow = unit.WorkbookAdapter.Current.SheetContext.Sheet.GetRow(context.RowIndex);
            if (hRow != null)
            {
                List<TModel> oitems = new List<TModel>();
                int rowCount = (context.EndRowIndex == -1) ? unit.WorkbookAdapter.Current.SheetContext.Sheet.LastRowNum : context.EndRowIndex;
                int cellCount = (context.EndCellIndex == -1) ? hRow.LastCellNum : context.EndCellIndex;
                for (int i = context.RowIndex; i <= rowCount; i++)
                {
                    object o = System.Activator.CreateInstance<TModel>();
                    for (int j = context.CellIndex; j < cellCount; j++)
                    {
                        ECHeadEnum fileName = j.ConvertTo<ECHeadEnum>();
                        EntityMetadataContext prop = props.SingleOrDefault(x => x.Value.ECHeadEnum == fileName).Key;
                        if (prop != null)
                        {
                            try
                            {
                                object value = unit.GetCellValue(i, j);
                                #region 数据转换
                                if (this.ConvertEvent != null)
                                {
                                    ConvertContext EventArgs = new ConvertContext
                                    {
                                        ECHeadEnum = fileName,
                                        PropertyDescriptor = prop.PropertyDescriptor,
                                        CurrentValue = value
                                    };
                                    this.ConvertEvent.Invoke(this, EventArgs);
                                    value = EventArgs.Result;
                                }
                                #endregion
                                prop.PropertyDescriptor.SetValue(o, value.ConvertTo(prop.VType));
                            }
                            catch
                            {
                            }
                        }
                    }
                    #region 数据验证
                    if (this.ValidationEvent != null)
                    {
                        ValidationContext EventArges = new ValidationContext
                        {
                            CurrentValue = o
                        };
                        this.ValidationEvent.Invoke(this, EventArges);
                        if (!EventArges.IsValidation)
                            continue;
                    }
                    #endregion
                    oitems.Add((TModel)o);
                }
                return oitems;
            }
            return null;
        }
        #endregion
    }
}
