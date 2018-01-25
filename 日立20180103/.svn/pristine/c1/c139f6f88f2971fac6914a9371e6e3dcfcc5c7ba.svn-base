using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Service.Code019;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PM2.WebApp.Areas.Code019.Controllers
{
    public class FileUploadController : Controller
    {
        private IFileUploadAsync _upload;
        public FileUploadController(Autofac.Features.Indexed.IIndex<Auto_FileType, IFileUploadAsync> uploads)
        {
            this._upload = uploads[Auto_FileType.UploadStateAsync];
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// WebupLoader
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartialViewResult ChildAction(string id)
        {
            return PartialView("TComponent/FileUpload/_WebupLoader", id);
        }  

        /// <summary>
        /// 附件上传
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UploadAsync(FileContext context)
        {
            IOperateResult result = await this._upload.UploadAsync(context);
            return result.ToActionResult(this.ControllerContext);
        }


    }
}