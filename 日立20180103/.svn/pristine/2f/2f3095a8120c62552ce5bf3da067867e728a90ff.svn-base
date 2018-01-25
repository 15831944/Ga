#region using
using Gmail.DDD.AOP;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Models;
using PM2.Models.Code030;
using PM2.Repository.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2.Service.Code001;
using Gmail.DDD.Helper;
using PM2.Models.Code031;
#endregion
namespace PM2.Service.Code031
{
    /// <summary>
    /// 加载-合同支付计划
    /// </summary>
    public class szrl126PlanLoadAsync : Iszrl126LoadAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl105Repository _szrl105Repository;

        public szrl126PlanLoadAsync(IDbContextScopeFactory scopeFactory, Iszrl105Repository szrl105Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl105Repository = szrl105Repository;
        }

        #region Iszrl126LoadAsync
        public async Task<IEnumerable<szrl126SVEntity>> LoadAsync(string pk)
        {
            List<szrl126SVEntity> szrl126Svs = new List<szrl126SVEntity>();
            using (IDbContextReadOnlyScope scope = this._scopeFactory.CreateReadOnlyScope())
            {
                IEnumerable<szrl126> szrl126s = await this._szrl105Repository.GetSzrl126s(pk);
                return szrl126s.Select(x => {
                    szrl126SVEntity o = new szrl126SVEntity {
                        rl12601 = "-1",
                        //金回支付- 处理日期
                        rl12609 = x.rl12605 == 0 ? DateTime.Now.ToString("yyyy-MM-dd") : string.Empty,

                        rl12719 = -1,           //状态 0: 承认济, 1: AP已发行
                        //担当者
                        rl12620 = x.rl12605 == 0 && x.rl12604 != "-1" ? UserContext.Pj00402 : string.Empty  
                    };

                    string[] noCopyNames = { "rl12601", "rl12609", "rl12719", "rl12620" };
                    o.SetValues(x, new CopySettings
                    {
                        Validation = (n, v, tv) => {
                            return !noCopyNames.Contains(n);
                        }
                    });
                    return o;

                }).ToList();
            }
        }
        #endregion
        
    }
}
