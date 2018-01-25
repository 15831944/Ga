using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public class ImportContext : OperaConext
    {
        private int _erIndex = -1, 
                    _ecIndex = -1;

        #region 读取-结束[X,Y 单元格数据(-1: 自动)
        /// <summary>
        /// 从指定Row[0]结束
        /// </summary>
        public int EndRowIndex { get { return this._erIndex; } set { this._erIndex = value; } }

        /// <summary>
        /// 从指定Cell[0]结束
        /// </summary>
        public int EndCellIndex { get { return this._ecIndex; } set { this._ecIndex = value; } }
        #endregion

    }
}
