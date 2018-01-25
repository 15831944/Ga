using PM2.Models.Code019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public interface IFileContext
    {
        /// <summary>
        /// 单据主键
        /// </summary>
        string fk { set; get; }

        /// <summary>
        /// Http文件信息
        /// </summary>
        System.Web.HttpPostedFileBase HttpFile { get; set; }

        /// <summary>
        /// 上传文件状态
        /// </summary>
        OperationState OperationState { get; set; }

        #region WebUploader
        /// <summary>
        /// 文件md5
        /// </summary>
        string md5 { get; set; }

        /// <summary>
        /// [文件分块号]
        /// </summary>
        int chunk { get; set; }

        /// <summary>
        /// [文件总分块数量]
        /// </summary>
        int chunks { get; set; }

        /// <summary>
        /// [文件分块大小]
        /// </summary>
        int chunkSize { get; set; }

        /// <summary>
        /// Md5文件名称
        /// </summary>
        string md5name { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// [文件总大小]
        /// </summary>
        int size { get; set; }
        #endregion

    }
}
