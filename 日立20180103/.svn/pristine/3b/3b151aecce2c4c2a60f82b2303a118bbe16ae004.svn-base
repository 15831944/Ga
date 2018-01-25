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
using PM2.Repository.Code030;
using PM2.Models.Code030;
#endregion
namespace PM2.Service.Code031
{
    /// <summary>
    /// 支付计划调整
    /// </summary>
    public class AdjustPaymentAsync : IPaymentCommandAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl125Repository_Facade _szrl125Repository;
        private Iszrl125ServeHelper _serveHelper;

        #region ctor
        public AdjustPaymentAsync(
            IDbContextScopeFactory scopeFactory,
            Iszrl125Repository_Facade szrl125Repository,
            Iszrl125ServeHelper serveHelper)
        {
            this._scopeFactory = scopeFactory;
            this._szrl125Repository = szrl125Repository;
            this._serveHelper = serveHelper;
        }
        #endregion
        #region IPaymentCommandAsync
        public async Task<IOperateResult> CommandAsync(szrl125 szrl125)
        {
            try
            {
                //保存当前数据
                List<object> records = await this._serveHelper.SaveAsync(szrl125, false);

                //数据备份
                await this._serveHelper.Databackup(szrl125);
                #region 计划调整
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    if (szrl125.rl12507 == 0 || szrl125.rl12507 == 4)
                        szrl125.rl12507 = 2; //[调整支付计划]预付款
                    if (szrl125.rl12507 == 1 || szrl125.rl12507 == 5)
                        szrl125.rl12507 = 3; //[调整支付计划]验收款

                    szrl125 _szrl125 = await this._szrl125Repository.GetSzrl126s(szrl125.rl12502);
                    _szrl125.rl12507 = szrl125.rl12507;

                    //数据合并汇总
                    szrl126 szrl126 = _szrl125.szrl126s.SingleOrDefault(x => x.rl12605 == 0 && x.rl12604 != "-1");
                    szrl126.rl12611 = _szrl125.szrl126s.Where(x => x.rl12605 == 0).Sum(x => x.rl12611);
                    szrl126.rl12612 = _szrl125.szrl126s.Where(x => x.rl12605 == 0).Sum(x => x.rl12612);
                    szrl126.rl12605 = 1;

                    //删除默认附加数据
                    this._szrl125Repository.Szrl126RemoveRange(_szrl125.szrl126s.Where(x => x.rl12605 == 0 && x.rl12604 == "-1").ToList());
                    
                    await scope.SaveChangesAsync();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new {
                        rl12507 = szrl125.rl12507,
                        records = records
                    });
                }
                #endregion
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #endregion
        
    }
}
