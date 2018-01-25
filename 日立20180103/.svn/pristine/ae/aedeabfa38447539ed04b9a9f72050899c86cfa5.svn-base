using Gmail.DDD.Entity;
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
    public class SheetContext : SVEntity
    {
        public ISheet Sheet { get; set; }

        private int _sheetIndex = -1;
        public int SheetIndex { set { this._sheetIndex = 0; } get { return this._sheetIndex; } }
        public string SheetName { get; set; }
    }
}
