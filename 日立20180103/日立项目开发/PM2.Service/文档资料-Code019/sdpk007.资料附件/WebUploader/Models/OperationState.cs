using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public enum OperationState
    {
        None,

        /// <summary>
        /// 获取文件信息
        /// </summary>
        FileInfo,

        /// <summary>
        /// 分片上传
        /// </summary>
        ChunkUpload,

        /// <summary>
        /// 文件上传
        /// </summary>
        FileUpload,

        /// <summary>
        /// 文件合并
        /// </summary>
        FileMerge
    }
}
