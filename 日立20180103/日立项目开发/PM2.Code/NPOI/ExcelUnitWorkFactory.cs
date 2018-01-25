using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ExcelUnitWorkFactory : IExcelUnitWorkFactory
    {
        #region 基本操作
        public IExcelUnitWork Create(string sheetName)
        {
            return new ExcelUnitWork(sheetName);
        }
        public IExcelUnitWork Create(string filePath, int sheetIndex)
        {
            return new ExcelUnitWork(filePath, sheetIndex);
        }
        public IExcelUnitWork Create(System.IO.Stream stream, int sheetIndex)
        {
            return new ExcelUnitWork(stream, sheetIndex);
        }
        #endregion
    }
}
