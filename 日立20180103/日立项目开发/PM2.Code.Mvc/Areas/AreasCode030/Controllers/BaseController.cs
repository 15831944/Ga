using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code030;
using PM2.Service.Code030.szrl111Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code030.Controllers
{
    public class BaseController : Controller
    {
        protected ContentResult Json2(object Data)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

            return Content(JsonConvert.SerializeObject(Data, Formatting.Indented, timeConverter));
        }



        protected FileResult ExcelFileResult(string fileName, MemoryStream ms)
        {
            fileName = string.Format("{0}-{1}.xls", fileName, DateTime.Now.ToString("yyyyMMdd"));
            fileName = HttpUtility.UrlEncode(fileName, Encoding.GetEncoding("UTF-8"));
            return File(ms, "application/vnd.ms-excel", fileName);
        }
    }
}