using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    /// <summary>
    /// Excel只存在一层表头[HraderGroupEnum.Three]
    /// </summary>
    public class ThreeHeardCommand : ExportHeaderCommand
    {
        #region ExportHeaderCommand
        /// <summary>
        /// 
        /// </summary>
        protected override int CreateHeader()
        {
            //设置第三层表头
            this.CreateRow(this._context.RowIndex, HraderGroupEnum.Three);
            return this._context.RowIndex += 1;
        }
        #endregion
        
        
    }
}
