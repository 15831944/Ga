using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using PM2.Models;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public interface ILogin : IAopService
    {
        /// <summary>
        /// 注意: 此方法没有任何意义....
        ///     只是单纯的测试await Task -> HttpContext is Null
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<IOperateResult> LoginAsync(LoginModel login);
    }
}

