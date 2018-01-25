using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public sealed class WorkbookAdapter : IComponent<WorkbookAdapter>
    {
        private IWorkbook _workbook = null;
        public IWorkbook XSSFWorkbook { get { return this._workbook; } }

        /// <summary>
        /// 当前操作 Sheet
        /// </summary>
        public SheetContext SheetContext { get; private set; }

        #region 操作 ISheet
        /// <summary>
        /// 创建 ISheet
        /// </summary>
        /// <param name="sheetName">Sheet 名称</param>
        /// <returns></returns>
        public SheetContext CreateSheet(string sheetName)
        {
            //SheetIndex 下标从 0开始.
            this.SheetContext.SheetIndex = this._workbook.NumberOfSheets == 0 ? 0 : this._workbook.NumberOfSheets -1;
            this.SheetContext.Sheet = this._workbook.CreateSheet(sheetName);
            this.SheetContext.SheetName = this._workbook.GetSheetName(this.SheetContext.SheetIndex);
            return this.SheetContext;
        }

        /// <summary>
        /// 切换 Sheet
        /// </summary>
        /// <param name="sheetIndex">Sheet 下标</param>
        /// <returns></returns>
        public SheetContext ChangeSheet(int sheetIndex)
        {
            this.SheetContext.SheetIndex = sheetIndex;
            this.SheetContext.Sheet = this._workbook.GetSheetAt(sheetIndex);
            this.SheetContext.SheetName = this._workbook.GetSheetName(this.SheetContext.SheetIndex);
            return this.SheetContext;
        }
        #endregion
        #region ctor
        public WorkbookAdapter()
            : this(null, null)
        { }
        public WorkbookAdapter(string path)
            : this(path, null)
        { }
        public WorkbookAdapter(System.IO.Stream stream)
            : this(null, stream)
        { }
        private WorkbookAdapter(string path, System.IO.Stream stream)
        {
            this.SheetContext = new SheetContext();
            if (!string.IsNullOrEmpty(path))
                this._workbook = new XSSFWorkbook(path);
            else if (stream != null)
                this._workbook = new XSSFWorkbook(stream);
            else
                this._workbook = new XSSFWorkbook(); 
        }
        #endregion
        public WorkbookAdapter Current
        {
            get { return this; }
        }

    }
}
