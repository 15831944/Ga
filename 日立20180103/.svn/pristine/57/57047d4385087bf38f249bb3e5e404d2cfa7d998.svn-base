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
    /// 恢复原支付计划
    /// </summary>
    public class RestorePaymentAsync : IPaymentCommandAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl125Repository_Facade _szrl125Repository;
        #region ctor
        public RestorePaymentAsync(
            IDbContextScopeFactory scopeFactory,
            Iszrl125Repository_Facade szrl125Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl125Repository = szrl125Repository;
        }
        #endregion
        #region IPaymentCommandAsync
        public async Task<IOperateResult> CommandAsync(szrl125 szrl125)
        {
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                if (szrl125.rl12507 == 2 || szrl125.rl12507 == 4)
                    szrl125.rl12507 = 0; //预付款
                if (szrl125.rl12507 == 3 || szrl125.rl12507 == 5)
                    szrl125.rl12507 = 1; //验收款

                szrl125 _szrl125 = await this._szrl125Repository.GetSzrl126s(szrl125.rl12502);
                _szrl125.rl12507 = szrl125.rl12507;

                //删除现有数据
                this._szrl125Repository.Szrl126RemoveRange(_szrl125.szrl126s.ToList());

                #region 数据恢复
                if (_szrl125.szrl140s.IsAny())
                {
                    CopySettings settings = new CopySettings
                    {
                        #region 字段映射
                        AliasName = (x) =>
                        {
                            switch (x)
                            {
                                case "rl14002": return "rl12602"; break;
                                case "rl14003": return "rl12603"; break;
                                case "rl14004": return "rl12604"; break;
                                case "rl14005": return "rl12605"; break;
                                case "rl14006": return "rl12606"; break;
                                case "rl14007": return "rl12607"; break;
                                case "rl14008": return "rl12608"; break;
                                case "rl14009": return "rl12609"; break;
                                case "rl14010": return "rl12610"; break;
                                case "rl14011": return "rl12611"; break;
                                case "rl14012": return "rl12612"; break;
                                case "rl14013": return "rl12613"; break;
                                case "rl14014": return "rl12614"; break;
                                case "rl14015": return "rl12615"; break;
                                case "rl14016": return "rl12616"; break;
                                case "rl14017": return "rl12617"; break;
                                case "rl14018": return "rl12618"; break;
                                case "rl14019": return "rl12619"; break;
                                case "rl14020": return "rl12620"; break;
                                case "rl14021": return "rl12621"; break;
                                case "rl14022": return "rl12622"; break;
                            }
                            return null;
                        }
                        #endregion
                    };
                    #region 恢复数据
                    _szrl125.szrl140s.ForEach((x, y, isTrue) =>
                    {
                        szrl126 szrl126 = new szrl126();
                        szrl126.rl12601 = null;
                        szrl126.SetValues(x, settings);
                        this._szrl125Repository.Szrl126Add(szrl126);
                    });
                    #endregion

                    //删除临时存储
                    this._szrl125Repository.Szrl140RemoveRange(_szrl125.szrl140s.ToList());

                }
                #endregion
                await scope.SaveChangesAsync();
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new
                {
                    rl12507 = szrl125.rl12507
                });
            }
        }
        #endregion
        
    }
}
