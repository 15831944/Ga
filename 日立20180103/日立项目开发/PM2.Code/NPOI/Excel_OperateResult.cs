using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class Excel_OperateResult : ExcelOperateResult
    {
        private ExcelWorkContext _context;
        public Excel_OperateResult(IExcelUnitWork unit, string fileDownloadName)
        {
            this._context = new ExcelWorkContext {
                fileDownloadName = string.Format("{0}.xlsx", fileDownloadName),
                ExcelWorkbook = unit.WorkbookAdapter.Current.XSSFWorkbook
            };
        }
        protected override ExcelWorkContext WorkContext
        {
            get { return this._context; }
        }
    }
}

