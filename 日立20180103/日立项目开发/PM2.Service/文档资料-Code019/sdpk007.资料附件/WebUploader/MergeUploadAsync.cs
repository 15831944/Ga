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
    public class MergeUploadAsync : IFileUploadAsync
    {
        private IFileUploadAsync _upload;
        public MergeUploadAsync(Autofac.Features.Indexed.IIndex<Auto_FileType, IFileUploadAsync> uploads)
        {
            this._upload = uploads[Auto_FileType.DboUploadAsync];
        }

        #region IFileUploadAsync
        public async Task<Gmail.DDD.Service.IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(UploadHelper.GetFileCacheDirectory(fileContext));
                //检查文件是否已存在
                if (!UploadHelper.IsFileExists(fileContext))
                {
                    string path = UploadHelper.GetFilePath(fileContext);
                    //保险
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    await Task.Factory.StartNew(() =>
                    {
                        foreach (FileInfo file in dir.GetFiles().OrderBy(f => int.Parse(f.Name)))
                        {
                            file.Open(FileMode.Open)
                                .ReadWrite(new FileStream(path, FileMode.Append, FileAccess.Write));
                        }
                    }).ConfigureAwait(false);
                }
                //删除分片文件
                if (dir.Exists)
                    dir.Delete(true);
                return await this._upload.UploadAsync(fileContext);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
