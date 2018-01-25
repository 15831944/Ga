using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public class FileUploadAsync : IFileUploadAsync
    {
        private IFileUploadAsync _upload;
        public FileUploadAsync(Autofac.Features.Indexed.IIndex<Auto_FileType, IFileUploadAsync> uploads)
        {
            this._upload = uploads[Auto_FileType.DboUploadAsync];
        }
        #region IFileUploadAsync
        public async Task<Gmail.DDD.Service.IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            try
            {
                string path = UploadHelper.GetFilePath(fileContext);
                fileContext.HttpFile.SaveAs(path);
                return await this._upload.UploadAsync(fileContext);
            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult<IOperateResult>(OperateResultFactory.AjaxOperateResult("文件上传失败!"));
        }
        #endregion
        
    }
}
