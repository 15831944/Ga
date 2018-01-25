using Gmail.DDD.JsonConvert;
using Gmail.DDD.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM2.Service.Code030
{
    public static class IOperateResultExtensions
    {
        public static JsonResult ConvertJsonResult(this IOperateResult result)
        {
            AjaxJsonResultData data = null;
            if (result.GetType().IsAssignableFrom(typeof(AjaxOperateResult)))
            {
                var ajaxOperateResult = (AjaxOperateResult)result;
                var content = ajaxOperateResult.Result.ToJsonString();
                data = Newtonsoft.Json.JsonConvert.DeserializeObject<AjaxJsonResultData>(content);
            }
            return new JsonResult() { Data = data, ContentType = "text/html" };
        }

        public static IOperateResult AddParamsToOperateResult(this IOperateResult result, object otherData)
        {
            if (result.GetType().IsAssignableFrom(typeof(AjaxOperateResult)))
            {
                var ajaxOperateResult = (AjaxOperateResult)result;
                var jsonConvert = (AjaxJsonConvert)ajaxOperateResult.Result;
                jsonConvert.Pamrms = otherData;
            }
            return result;
        }
    }
}
