using Gmail.DDD.AOP;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using PM2.Models.Code019;
using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PM2.Service.Code019
{
    public class FileInfoUploadAsync : IFileUploadAsync
    {
        #region IFileUploadAsync
        public async Task<IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            bool b = await Task.Factory.StartNew<bool>(() => {
                bool isExists = false;
                if (UploadHelper.IsFileExists(fileContext))
                    return true;
                return isExists;
            }).ConfigureAwait(false);
            if (b)
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new { isUpload = true });
            else {
                DirectoryInfo dir = new DirectoryInfo(UploadHelper.GetFileCacheDirectory(fileContext));
                var query = from x in dir.GetFiles()
                            orderby int.Parse(x.Name)
                            select new {
                                name = int.Parse(x.Name),
                                size = x.Length
                            };
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new { isUpload = false, chunks = query.ToArray() });
            }
        }
        #endregion
        
    }
}
