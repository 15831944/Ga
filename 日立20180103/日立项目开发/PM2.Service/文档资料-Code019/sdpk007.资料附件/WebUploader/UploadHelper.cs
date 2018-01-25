using Gmail.DDD.Config;
using Gmail.DDD.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public sealed class UploadHelper
    {
        /// <summary>
        /// 获取文件[存储路径]
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static string GetFilePath(IFileContext fileContext)
        {
            return System.IO.Path.Combine(GetFileDirectory(fileContext), fileContext.md5name);
        }

        /// <summary>
        /// 获取文件[存储目录]
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static string GetFileDirectory(IFileContext fileContext)
        {
            string folder = PM2Config.Instance.FileConfig.FilePath;
            if (folder.Contains("~"))
                folder = HttpHelper.RequestContext.HttpContext.Server.MapPath(folder);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder;
        }

        /// <summary>
        /// 获取分片文件[存储路径]
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static string GetFileCachePath(IFileContext fileContext)
        {
            return System.IO.Path.Combine(GetFileCacheDirectory(fileContext), fileContext.chunk.ToString());
        }

        /// <summary>
        /// 获取分片文件[存储目录]
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static string GetFileCacheDirectory(IFileContext fileContext)
        {
            string folder = System.IO.Path.Combine(GetFileDirectory(fileContext), "FileCache", string.Format("[{0}]", fileContext.md5));
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder;
        }

        /// <summary>
        /// 检测文件是否存在
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static bool IsFileExists(IFileContext fileContext)
        {
            string path = UploadHelper.GetFilePath(fileContext);
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists || (fileInfo.Exists && fileInfo.Length != fileContext.size))
                return false;
            return true;
        }

        /// <summary>
        /// 检测文件[分块是否存在]
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        public static bool IsFileChunkExists(IFileContext fileContext)
        {
            if (!IsFileExists(fileContext))
            {
                #region 大文件存在N块
                if (fileContext.chunks > 1)
                {
                    string path = GetFileCachePath(fileContext);
                    FileInfo fileInfo = new FileInfo(path);
                    if (!fileInfo.Exists)
                        return false;
                    if (fileInfo.Exists)
                    {
                        if (fileContext.chunkSize != fileInfo.Length)
                            return false;
                    }
                }
                #endregion
            }
            return true;
        }

    }
}
