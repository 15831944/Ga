using Gmail.DDD.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.NPOI
{
    public interface ICellStyleFormat
    {
        ICellStyle Create(IComponent<WorkbookAdapter> wAdapter, CellStyleContext context);
    }
}
