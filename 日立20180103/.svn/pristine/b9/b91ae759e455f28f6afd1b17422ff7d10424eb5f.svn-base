using Gmail.DDD.DataContext;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Repositorys.SQLBuilding;
using Gmail.DDD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code019
{
    public class Code019ModuleManager : ModuleManager
    {
        public override void Load()
        {
            #region 附件上传: PM2.Service\文档资料-Code019\sdpk007.资料附件\WebUploader
            this.RegisterType<UploadStateAsync, IFileUploadAsync>(serviceName: Auto_FileType.UploadStateAsync);
            this.RegisterType<FileInfoUploadAsync, IFileUploadAsync>(serviceName: Auto_FileType.FileInfoUploadAsync);
            this.RegisterType<ChunkUploadAsync, IFileUploadAsync>(serviceName: Auto_FileType.ChunkUploadAsync);
            this.RegisterType<FileUploadAsync, IFileUploadAsync>(serviceName: Auto_FileType.FileUploadAsync);
            this.RegisterType<MergeUploadAsync, IFileUploadAsync>(serviceName: Auto_FileType.MergeUploadAsync);
            this.RegisterType<DboUploadAsync, IFileUploadAsync>(serviceName: Auto_FileType.DboUploadAsync);

            this.RegisterType<sdey007Serve, Isdpk007Server>();
            #endregion
        }
    }
}
