using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using PM2.Models.Code019;
using PM2.Repository.Code019;
using PM2.Service.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PM2.Service.Code019
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DboUploadAsync : IFileUploadAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Isdpk007Repository_Facade _sdpk007Repository_Facade;
        public DboUploadAsync(
            IDbContextScopeFactory scopeFactory,
            Isdpk007Repository_Facade sdpk007Repository_Facade)
        {
            this._scopeFactory = scopeFactory;
            this._sdpk007Repository_Facade = sdpk007Repository_Facade;
        }

        #region 数据库存储
        public async Task<IOperateResult> UploadAsync(IFileContext fileContext)
        {
            TaskAsync.StartAsync();
            using (IDbContextScope dbScope = this._scopeFactory.CreateScope())
            {
                #region sdpk008_Insert
                sdpk008 sdpk008 = new sdpk008
                {
                    pk00802 = fileContext.md5name,
                    pk00803 = fileContext.name,
                    pk00804 = new byte[] { },
                    pk00807 = UserContext.Pj00421,
                    pk00808 = UserContext.Pj00421,
                    pk00809 = string.Empty,
                    pk00810 = FileType.HardDisk,
                    pk00811 = string.Empty,
                    pk00812 = "1.0.0.0",
                    pk00813 = string.Empty,
                    pk00814 = string.Empty
                };
                this._sdpk007Repository_Facade.AddSdpk008(sdpk008);
                #endregion
                #region sdpk007_Insert
                sdpk007 sdpk007 = new Models.Code019.sdpk007
                {
                    pk00702 = fileContext.fk,
                    sdpk008 = sdpk008
                };
                this._sdpk007Repository_Facade.AddSdpk007(sdpk007);
                #endregion
                int index = await dbScope.SaveChangesAsync()
                                         .ConfigureAwait(false);
                if (index > 0)
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new
                    {
                        chunked = false,
                        pk00801 = sdpk008.pk00801,    //附件ID
                        pk00805 = sdpk008.pk00805,    //上传时间
                        pk00807 = UserContext.Pj00402 //上传人
                    });
                else
                    return OperateResultFactory.AjaxOperateResult("附件存储失败!");
            }
        }
        #endregion
        
    }
}
