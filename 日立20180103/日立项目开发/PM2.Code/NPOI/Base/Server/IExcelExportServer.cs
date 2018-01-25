using Gmail.DDD.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.DDD.Service
{
    public interface IExcelExportServer : IService
    {
        IOperateResult Export(IRequestGetter vParams = null);

    }
}
