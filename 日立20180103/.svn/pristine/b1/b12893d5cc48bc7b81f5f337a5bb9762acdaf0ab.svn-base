#region using
using Gmail.DDD.AOP;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.IOC;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Models;
using PM2.Models.Code001;
using PM2.Models.Code031;
using PM2.Repository.Code031;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2.Service.Code001;
#endregion
namespace PM2.Service.Code031
{
    public class szrl125ServeHelper : Iszrl125ServeHelper
    {
        private IDbContextScopeFactory _scopeFactory;
        private Iszrl125Repository_Facade _szrl125Repository;
        #region ctor
        public szrl125ServeHelper(
            IDbContextScopeFactory scopeFactory,
            Iszrl125Repository_Facade szrl125Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl125Repository = szrl125Repository;
        }
        #endregion

        #region 数据保存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szrl125"></param>
        /// <param name="isTrue">是否同步自定义数据</param>
        /// <returns></returns>
        public async Task<List<object>> SaveAsync(szrl125 szrl125, bool isTrue)
        {
             //设置对应关系
            List<object> upPks = new List<object>();
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                szrl125 _szrl125 = await this._szrl125Repository.GetSzrl126s(szrl125.rl12502);
                _szrl125.rl12503 = szrl125.rl12503;
                _szrl125.rl12505 = szrl125.rl12505;

                #region 更新[待支付确认]合同支付情况
                if (szrl125.szrl126s.IsAny())
                {
                    CopySettings uSettings = new CopySettings
                    {
                        Exclude = "rl12601,rl12602,rl12620,rl12621,rl12622"
                    };

                    foreach (szrl126 szrl126 in szrl125.szrl126s)
                    {
                        szrl126 _szrl126 = _szrl125.szrl126s.SingleOrDefault(x => x.rl12601.Equals(szrl126.rl12601));
                        #region 更新操作
                        if (_szrl126 != null)
                        {
                            _szrl126.SetValues(szrl126, uSettings);
                            _szrl126.rl12620 = UserContext.Pj00401;

                            //自定义新增数据同步
                            if (_szrl126.rl12603 == 2 && isTrue)
                            {
                                _szrl126.rl12606 = _szrl126.rl12610;
                                _szrl126.rl12607 = _szrl126.rl12611;
                                _szrl126.rl12608 = _szrl126.rl12612;
                            }
                            
                            //自定义新增数据删除
                            if (_szrl126.rl12603 == 2 && _szrl126.rl12611 == 0)
                                this._szrl125Repository.Szrl126Remove(_szrl126);

                        }
                        #endregion
                        #region 新增自定义数据
                        if (_szrl126 == null)
                        {
                            if (szrl126.rl12611 > 0)
                            {
                                szrl126.rl12601 = null;
                                szrl126.rl12602 = _szrl125.rl12501;
                                szrl126.rl12614 = -1;
                                szrl126.rl12620 = UserContext.Pj00401; 
                                this._szrl125Repository.Szrl126Add(szrl126);

                                upPks.Add(new
                                {
                                    rl12604 = szrl126.rl12604,
                                    rl12601 = szrl126.rl12601
                                });
                            }
                        }
                        #endregion
                    }
                    await scope.SaveChangesAsync();
                }
                #endregion
            }
            return upPks;

            throw new NotImplementedException();
        }
        #endregion
        #region 数据备份
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szrl125"></param>
        /// <returns></returns>
        public async Task Databackup(szrl125 szrl125)
        {
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                szrl125 _szrl125 = await this._szrl125Repository.GetSzrl126s(szrl125.rl12502);
                if (!_szrl125.szrl140s.IsAny())
                {
                    CopySettings settings = new CopySettings
                    {
                        #region 字段映射
                        AliasName = (x) =>
                        {
                            switch (x)
                            {
                                case "rl12602": return "rl14002"; break;
                                case "rl12603": return "rl14003"; break;
                                case "rl12604": return "rl14004"; break;
                                case "rl12605": return "rl14005"; break;
                                case "rl12606": return "rl14006"; break;
                                case "rl12607": return "rl14007"; break;
                                case "rl12608": return "rl14008"; break;
                                case "rl12609": return "rl14009"; break;
                                case "rl12610": return "rl14010"; break;
                                case "rl12611": return "rl14011"; break;
                                case "rl12612": return "rl14012"; break;
                                case "rl12613": return "rl14013"; break;
                                case "rl12614": return "rl14014"; break;
                                case "rl12615": return "rl14015"; break;
                                case "rl12616": return "rl14016"; break;
                                case "rl12617": return "rl14017"; break;
                                case "rl12618": return "rl14018"; break;
                                case "rl12619": return "rl14019"; break;
                                case "rl12620": return "rl14020"; break;
                                case "rl12621": return "rl14021"; break;
                                case "rl12622": return "rl14022"; break;
                            }
                            return null;
                        }
                        #endregion
                    };
                    #region 备份数据
                    _szrl125.szrl126s.ForEach((x, y, isTrue) =>{
                        szrl140 szrl140 = new szrl140();
                        szrl140.rl14001 = null;
                        szrl140.SetValues(x, settings);
                        this._szrl125Repository.Szrl140Add(szrl140);
                    });
                    #endregion
                }
                await scope.SaveChangesAsync();
            }
        }
        #endregion
        
    }
}
