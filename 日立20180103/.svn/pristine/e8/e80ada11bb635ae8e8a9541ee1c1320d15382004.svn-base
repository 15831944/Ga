#region using
using FluentValidation;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Gmail.DDD.Extensions;
using PM2.Models.Code031;
using System.Data.Entity;
using PM2.Repository.Code031;
using PM2.Service.Code001;
#endregion
namespace PM2.Service.Code031
{
    /// <summary>
    /// 按钮组命令
    /// </summary>
    public interface IPaymentCommandAsync: IAopService
    {
        Task<IOperateResult> CommandAsync(szrl125 szrl125);
    }
}
