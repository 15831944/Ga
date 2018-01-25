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
    /// 带入验收计划
    /// </summary>
    public class IntoPaymentAsync : IPaymentCommandAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl128Repository _szrl128Repository;
        private Iszrl125Repository_Facade _szrl125Repository;
        private Iszrl125ServeHelper _serveHelper;
        #region ctor
        public IntoPaymentAsync(
            IDbContextScopeFactory scopeFactory,
            Iszrl128Repository szrl128Repository,
            Iszrl125Repository_Facade szrl125Repository,
            Iszrl125ServeHelper serveHelper)
        {
            this._scopeFactory = scopeFactory;
            this._szrl128Repository = szrl128Repository;
            this._szrl125Repository = szrl125Repository;
            this._serveHelper = serveHelper;
        }
        #endregion
        #region IPaymentCommandAsync
        public async Task<IOperateResult> CommandAsync(szrl125 szrl125)
        {
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                //数据备份
                await this._serveHelper.Databackup(szrl125);

                if (szrl125.rl12507 == 0 || szrl125.rl12507 == 2)
                    szrl125.rl12507 = 4; //[带入验收计划]预付款
                if (szrl125.rl12507 == 1 || szrl125.rl12507 == 3)
                    szrl125.rl12507 = 5; //[带入验收计划]验收款

                szrl125 _szrl125 = await this._szrl125Repository.GetSzrl126s(szrl125.rl12502);
                _szrl125.rl12507 = szrl125.rl12507;

                //删除原有数据
                this._szrl125Repository.Szrl126RemoveRange(_szrl125.szrl126s.ToList());

                #region 初始化-[待支付确认]合同支付情况
                IEnumerable<szrl126> szrl126s = await this._szrl128Repository.GetSzrl126s(szrl125.rl12502);
                szrl126s.ForEach((x, y, isTrue) =>
                {
                    x.rl12601 = null;
                    x.rl12609 = (x.rl12605 == 0 && x.rl12604 != "-1") ? DateTime.Now.ToString("yyyy-MM-dd") : string.Empty;
                    x.rl12620 = UserContext.Pj00401;
                    x.rl12602 = _szrl125.rl12501;
                    x.rl12621 = 1;
                    this._szrl125Repository.Szrl126Add(x);
                });
                #endregion

                int index = await scope.SaveChangesAsync();
                if (index > 0)
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "数据初始化成功!", 
                        new { rl12507 = _szrl125.rl12507 }
                    );
                else
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "数据初始化失败!");

            }
        }
        #endregion

    }
}
