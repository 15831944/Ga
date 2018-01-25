#region using
using Gmail.DDD.Repositorys;
using Gmail.DDD.Utility;
using Gmail.DDD.Extensions;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PM2.Models.Code030;
using PM2.Models.Code031;
using Gmail.DDD.Helper;
#endregion
namespace PM2.Repository.Code030
{
    public class szrl105Repository : Iszrl105Repository
    {
        private IUnitOfWork _unitOfWork;
        public szrl105Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region 获取-合同支付计划
        /// <summary>
        /// 获取-合同支付计划
        /// </summary>
        /// <param name="rl12502">合同ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<szrl105Model>> LoadAsync(string rl12502)
        {
            string sql = "select "+
                "rl10503, "+ //合同ID
	
                "rl10701, "+ //支付计划ID
                "rl10707, "+ //计划支付日期
                "rl10708, "+ //计划支付%
                "rl10709  "+ //计划支付金额
	
            "from szrl105 inner join szrl107 "+
            "on rl10702 = rl10503 "+
            "where rl10572 = 1 and isnull(rl10709, 0) > 0  and rl10503 = @rl10503 "+
            "order by rl10503,rl10707";

            return
                await this._unitOfWork.ExecuteSqlQueryAsync<szrl105Model>(sql, new System.Data.SqlClient.SqlParameter("@rl10503", rl12502));
        }
        #endregion
        #region 转换-[待支付确认]合同支付情况
        /// <summary>
        /// 转换-[待支付确认]合同支付情况
        /// </summary>
        /// <param name="rl12502">合同ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<szrl126>> GetSzrl126s(string rl12502)
        {
            IEnumerable<szrl105Model> szrl105s = await this.LoadAsync(rl12502);
            List<szrl126> szrl126s = new List<szrl126>();

            var _rl12622 = 0;
            szrl105s.OrderBy(x => x.rl10707).ForEach((x, y, isTrue) =>
            {
                szrl126 szrl126 = new szrl126
                {
                    //rl12601 = x.rl10701,    //ID
                    rl12605 = y == 0 ? 0 : 1, //0: 金回支付, 1: 今后支付预定
                    rl12603 = 0,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
                    rl12604 = x.rl10701,      //来源ID  

                    #region 元支付预定
                    rl12606 = x.rl10707, //支付日期
                    rl12607 = x.rl10708, //-%
                    rl12608 = x.rl10709, //金额
                    #endregion
                    #region 金回支付
                    rl12609 = y == 0 ? DateTime.Now.ToString("yyyy-MM-dd") : string.Empty, //处理日期
                    rl12610 = x.rl10707, //支付日期
                    rl12611 = x.rl10708, //-%
                    rl12612 = x.rl10709, //金额
                    #endregion

                    rl12613 = string.Empty, //附件ID
                    rl12614 = -1,           //付款性质 0: 预付款, 1:质保款, 2:验收款
                    rl12615 = 0,            //预付款扣款金额
                    rl12616 = 0,            //预付款扣款占合同%
                    rl12617 = 0,            //本次实际支付金额(含税)
                    rl12618 = 0,            //本次实际支付金额(不含税)

                    rl12619 = string.Empty, //备注
                    rl12620 = string.Empty, //担当者
                    rl12621 = 1,            //是否正式数据 0: 否, 1: 是
                    rl12622 = _rl12622      //排序序号
                };
                szrl126s.Add(szrl126);
                #region 金回支付[默认-2条空数据]
                if (y == 0)
                {
                    _rl12622 = _rl12622 + 1;
                    szrl126 szrl126_01 = new szrl126
                    {
                        //rl12601 = PrimaryKeyHelper.NewComb().ToString(),
                        rl12605 = 0,              //0: 金回支付, 1: 今后支付预定
                        rl12603 = 0,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
                        rl12604 = "-1",           //来源ID  

                        #region 元支付预定
                        rl12606 = string.Empty,//支付日期
                        //rl12607 = x.rl10708, //-%
                        //rl12608 = x.rl10709, //金额
                        #endregion
                        #region 金回支付
                        rl12609 = DateTime.Now.ToString("yyyy-MM-dd"), //处理日期
                        rl12610 = string.Empty,//支付日期
                        //rl12611 = x.rl10708, //-%
                        //rl12612 = x.rl10709, //金额
                        #endregion

                        rl12613 = string.Empty, //附件ID
                        rl12614 = -1,           //付款性质 0: 预付款, 1:质保款, 2:验收款
                        rl12615 = 0,            //预付款扣款金额
                        rl12616 = 0,            //预付款扣款占合同%
                        rl12617 = 0,            //本次实际支付金额(含税)
                        rl12618 = 0,            //本次实际支付金额(不含税)

                        rl12619 = string.Empty, //备注
                        rl12620 = string.Empty, //担当者
                        rl12621 = 1,            //是否正式数据 0: 否, 1: 是
                        rl12622 = _rl12622      //排序序号
                    };
                    szrl126s.Add(szrl126_01);

                    _rl12622 = _rl12622 + 1;
                    szrl126 szrl126_02 = new szrl126
                    {
                        //rl12601 = PrimaryKeyHelper.NewComb().ToString(),
                        rl12605 = 0,              //0: 金回支付, 1: 今后支付预定
                        rl12603 = 0,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
                        rl12604 = "-1",           //来源ID  

                        #region 元支付预定
                        rl12606 = string.Empty,//支付日期
                        //rl12607 = x.rl10708, //-%
                        //rl12608 = x.rl10709, //金额
                        #endregion
                        #region 金回支付
                        rl12609 = DateTime.Now.ToString("yyyy-MM-dd"), //处理日期
                        rl12610 = string.Empty,//支付日期
                        //rl12611 = x.rl10708, //-%
                        //rl12612 = x.rl10709, //金额
                        #endregion

                        rl12613 = string.Empty, //附件ID
                        rl12614 = -1,           //付款性质 0: 预付款, 1:质保款, 2:验收款
                        rl12615 = 0,            //预付款扣款金额
                        rl12616 = 0,            //预付款扣款占合同%
                        rl12617 = 0,            //本次实际支付金额(含税)
                        rl12618 = 0,            //本次实际支付金额(不含税)

                        rl12619 = string.Empty, //备注
                        rl12620 = string.Empty, //担当者
                        rl12621 = 1,            //是否正式数据 0: 否, 1: 是
                        rl12622 = _rl12622      //排序序号
                    };
                    szrl126s.Add(szrl126_02);
                }
                #endregion
                _rl12622 = _rl12622 + 1;

            });
            return szrl126s;
        }
        #endregion

    }
}
