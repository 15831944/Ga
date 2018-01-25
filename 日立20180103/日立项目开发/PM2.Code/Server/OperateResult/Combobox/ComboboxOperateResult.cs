using Gmail.DDD.Helper;
using Gmail.DDD.JsonConvert;
using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM2.Code
{
    public class ComboboxOperateResult : JsonOperateResult<OperateResultType>
    {
        public ComboboxOperateResult(List<ComboboxItem> data)
            : base(OperateResultType.Success)
        {
            this._jsonClass = new ComboboxJsonConvert(data);
        }
    }
}
