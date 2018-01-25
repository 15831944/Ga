using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class Date_CenterCellStyle : CellStyleBase
    {
        protected override ICellStyle Create(Gmail.DDD.Utility.IComponent<WorkbookAdapter> wAdapter, IWorkbook workbook, IDataFormat format, CellStyleContext context)
        {
            ICellStyle style = CellStyleCreate.Instance.Create(wAdapter, context);
            style.Alignment = HorizontalAlignment.Center;
            style.DataFormat = format.GetFormat("yyyy-MM-dd");
            return style;
        }
    }
}
