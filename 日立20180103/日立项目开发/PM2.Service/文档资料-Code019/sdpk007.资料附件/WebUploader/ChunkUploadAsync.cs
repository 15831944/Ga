using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public class ChunkUploadAsync : IFileUploadAsync
    {
        #region IFileUploadAsync
        public async Task<IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            try
            {
                string path = UploadHelper.GetFileCachePath(fileContext);
                await fileContext.HttpFile.InputStream
                                 .ReadWriteAsync(new FileStream(path, FileMode.Create, FileAccess.Write))
                                 .ConfigureAwait(false);

                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
            }
            catch (Exception ex)
            {
            }
            return await 
                Task.FromResult<IOperateResult>(OperateResultFactory.AjaxOperateResult("分片上传失败!"));
        }
        #endregion
    }
}
