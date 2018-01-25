using Gmail.DDD.Config;
using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public class UploadStateAsync : IFileUploadAsync
    {
        private IFileUploadAsync _upload;
        private Autofac.Features.Indexed.IIndex<Auto_FileType, IFileUploadAsync> _uploads;
        public UploadStateAsync(Autofac.Features.Indexed.IIndex<Auto_FileType, IFileUploadAsync> uploads)
        {
            this._uploads = uploads;
        }

        public async Task<IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            if (fileContext.OperationState == OperationState.None)
                return await Task.FromResult<IOperateResult>(OperateResultFactory.AjaxOperateResult("文件操作类型异常..."));
            #region 状态码
            switch (fileContext.OperationState)
            {
                case OperationState.FileInfo:
                    this._upload = this._uploads[Auto_FileType.FileInfoUploadAsync];
                    break;
                case OperationState.ChunkUpload:
                    this._upload = this._uploads[Auto_FileType.ChunkUploadAsync];
                    break;
                case OperationState.FileUpload:
                    this._upload = this._uploads[Auto_FileType.FileUploadAsync];
                    break;
                case OperationState.FileMerge:
                    this._upload = this._uploads[Auto_FileType.MergeUploadAsync];
                    break;
            }
            #endregion
            return await this._upload.UploadAsync(fileContext);

        }
    }
}
