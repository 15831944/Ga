#region using
using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models;
using PM2.Models.Code001;
using PM2.Models.Code031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace PM2.Service.Code031
{
    public interface Iszrl125ServeHelper : IService
    {
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="szrl125"></param>
        /// <returns></returns>
        Task<List<object>> SaveAsync(szrl125 szrl125, bool isTrue);

        /// <summary>
        /// 数据备份
        /// </summary>
        /// <param name="szrl125"></param>
        /// <returns></returns>
        Task Databackup(szrl125 szrl125);
        
    }
}
