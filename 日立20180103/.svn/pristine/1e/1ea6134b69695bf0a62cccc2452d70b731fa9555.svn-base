using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface IExcelUnitWorkFactory : IService
    {
        #region 基本操作
        IExcelUnitWork Create(string sheetName);
        IExcelUnitWork Create(string filePath, int sheetIndex);
        IExcelUnitWork Create(Stream stream, int sheetIndex);
        #endregion
    }
}
