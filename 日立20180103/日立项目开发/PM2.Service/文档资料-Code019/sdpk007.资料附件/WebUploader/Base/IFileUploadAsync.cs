using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.IOC;

namespace PM2.Service.Code019
{
    public interface IFileUploadAsync : IAopService
    {
        /// <summary>
        /// 附件上传
        /// </summary>
        /// <param name="fileContext"></param>
        /// <returns></returns>
        Task<IOperateResult> UploadAsync(IFileContext fileContext);

    }
}
