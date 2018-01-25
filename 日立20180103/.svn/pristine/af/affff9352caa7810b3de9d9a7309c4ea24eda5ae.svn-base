using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public abstract class CellStyleBase : ICellStyleFormat
    {
        public ICellStyle Create(IComponent<WorkbookAdapter> wAdapter, CellStyleContext context)
        {
            IWorkbook workbook = wAdapter.Current.XSSFWorkbook;
            IDataFormat _format = workbook.CreateDataFormat();
            return this.Create(wAdapter, workbook, _format, context);
        }
        protected abstract ICellStyle Create(IComponent<WorkbookAdapter> wAdapter, IWorkbook workbook, IDataFormat format, CellStyleContext context);
    }
}
