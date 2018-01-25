using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class Int_RightCellStyle : CellStyleBase
    {
        protected override ICellStyle Create(Gmail.DDD.Utility.IComponent<WorkbookAdapter> wAdapter, IWorkbook workbook, IDataFormat format, CellStyleContext context)
        {
            ICellStyle style = CellStyleCreate.Instance.Create(wAdapter, context);
            style.Alignment = HorizontalAlignment.Right;
            style.DataFormat = format.GetFormat("0");
            return style;
        }
    }
}
