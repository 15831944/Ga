using Gmail.DDD.Entity;
using Gmail.DDD.Helper;
using PM2.Models.Code019;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public class FileContext : IFileContext
    {
        public string fk { get; set; }
        public System.Web.HttpPostedFileBase HttpFile { set; get; }

        private OperationState _state = OperationState.None;
        public OperationState OperationState {
            set {
                this._state = value;
            }
            get {
                if (this._state == Code019.OperationState.None)
                {
                    //标准上传
                    if (this.chunks == 1)
                        this._state = Code019.OperationState.FileUpload;

                    //分片上传
                    if (this.chunks > 1)
                        this._state = Code019.OperationState.ChunkUpload;
                }
                return this._state;
            }
        }
        #region WebUploader
        /// <summary>
        /// 文件md5
        /// </summary>
        public string md5 { get; set; }

        /// <summary>
        /// [文件分块号]
        /// </summary>
        public int chunk { get; set; }

        /// <summary>
        /// [文件总分块数量]
        /// </summary>
        public int chunks { get; set; }

        /// <summary>
        /// [文件分块大小]
        /// </summary>
        public int chunkSize { get; set; }

        /// <summary>
        /// Md5文件名称
        /// </summary>
        public string md5name { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// [文件总大小]
        /// </summary>
        public int size { get; set; }
        #endregion

    }

}
