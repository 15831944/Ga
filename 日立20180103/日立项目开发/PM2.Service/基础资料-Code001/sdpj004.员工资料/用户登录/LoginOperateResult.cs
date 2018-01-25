using Gmail.DDD.JsonConvert;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public class LoginOperateResult : JsonOperateResult<LoginOperateResultType>
    {
        private IJsonConvert _ajax = null;
        public LoginOperateResult(LoginOperateResultType resultType, object _params = null)
            : base(resultType)
        {
            string _message = this.ResultType.GetType()
                    .GetMember(this.ResultType.ToString())
                    .FirstOrDefault()
                    .ToDescription();

            bool success = resultType == LoginOperateResultType.Success ? true : false;
            this._ajax = new AjaxJsonConvert(success, _message, _params);
        }
        public override IJsonConvert Result
        {
            get { return this._ajax; }
        }
    }
}
