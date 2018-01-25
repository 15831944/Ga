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
    /// 预付款|验收款
    /// </summary>
    public class AdvancePaymentAsync : IPaymentCommandAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl105Repository _szrl105Repository;
        private Iszrl125Repository_Facade _szrl125Repository;
        #region ctor
        public AdvancePaymentAsync(
            IDbContextScopeFactory scopeFactory,
            Iszrl105Repository szrl105Repository,
            Iszrl125Repository_Facade szrl125Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl105Repository = szrl105Repository;
            this._szrl125Repository = szrl125Repository;
        }
        #endregion
        #region IPaymentCommandAsync
        [AdvanceBeforeSaveAttribute]
        public async Task<IOperateResult> CommandAsync(szrl125 szrl125)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    //初始化-合同支付情况
                    this._szrl125Repository.Add(szrl125);

                    #region 初始化-[待支付确认]合同支付情况
                    //设置对应关系
                    List<object> records = new List<object>();
                    IEnumerable<szrl126> szrl126s = await this._szrl105Repository.GetSzrl126s(szrl125.rl12502);
                    szrl126s.ForEach((x, y, isTrue) =>
                    {
                        x.rl12609 = (x.rl12605 == 0 && x.rl12604 != "-1") ? DateTime.Now.ToString("yyyy-MM-dd") : string.Empty;
                        x.rl12620 = UserContext.Pj00401; 
                        x.rl12602 = szrl125.rl12501;
                        x.rl12621 = 1;
                        this._szrl125Repository.Szrl126Add(x);

                        records.Add(new
                        {
                            rl12604 = x.rl12604,
                            rl12601 = x.rl12601
                        });
                    });
                    #endregion
                    int index = await scope.SaveChangesAsync();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "数据初始化成功!", new {
                        rl12507 = szrl125.rl12507,
                        records = records
                    });

                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #endregion
        
    }
}
