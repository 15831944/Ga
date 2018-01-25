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
#endregion
namespace PM2.Repository.Code030
{
    public class szrl128Repository : Iszrl128Repository
    {
        private IUnitOfWork _unitOfWork;
        public szrl128Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region 获取-合同验收计划
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pk">合同ID</param>
        /// <returns></returns>
        public async Task<IEnumerable<szrl128Model>> LoadAsync(string pk)
        {
            try
            {
                string sql = "select " +
                    "rl12802, " + //--合同ID
                    "rl12102, " + //--状态 1: 今回检收,2: 今月再度检收预定

                    "rl12101, " + //--计划ID
                        //--验收计划
                    "rl12103, " + //--验收日期
                    "rl12104, " + //--验收比率
                    "rl12105, " + //--验收金额
                        //--实际验收
                    "rl12106, " + //--验收日期
                    "rl12107, " + //--验收比率
                    "rl12108, " + //--验收金额

                    "rl12110  " + //--备注

                "from szrl128 inner join szrl121 " +
                "on rl12124 = rl12801 " +
                "where rl12802 = @rl12802 and rl12804 = 1 and rl12809 = 1 " +
                "and rl12102 in(1, 2) " +
                "order by rl12102 ";
                return
                    await this._unitOfWork.ExecuteSqlQueryAsync<szrl128Model>(sql, new System.Data.SqlClient.SqlParameter("@rl12802", pk));

            }
            catch (Exception ex)
            {
                
                throw;
            }
            
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
            IEnumerable<szrl128Model> szrl128s = await this.LoadAsync(rl12502);
            List<szrl126> szrl126s = new List<szrl126>();

            var _rl12622 = 0;
            szrl128s.OrderBy(x => x.rl12102).ForEach((x, y, isTrue) =>
            {
                szrl126 szrl126 = new szrl126
                {
                    //rl12601 = x.rl10701,    //ID
                    rl12605 = x.rl12102 == 1 ? 0 : 1, //0: 金回支付, 1: 今后支付预定
                    rl12603 = 1,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
                    rl12604 = x.rl12101,      //来源ID  

                    #region 元支付预定
                    rl12606 = x.rl12103, //支付日期
                    rl12607 = x.rl12104, //-%
                    rl12608 = x.rl12105, //金额
                    #endregion
                    #region 金回支付
                    rl12609 = x.rl12102 == 1 ? DateTime.Now.ToString("yyyy-MM-dd") : string.Empty, //处理日期
                    rl12610 = x.rl12106, //支付日期
                    rl12611 = x.rl12107, //-%
                    rl12612 = x.rl12108, //金额
                    #endregion

                    rl12613 = string.Empty, //附件ID
                    rl12614 = -1,           //付款性质 0: 预付款, 1:质保款, 2:验收款
                    rl12615 = 0,            //预付款扣款金额
                    rl12616 = 0,            //预付款扣款占合同%
                    rl12617 = 0,            //本次实际支付金额(含税)
                    rl12618 = 0,            //本次实际支付金额(不含税)

                    rl12619 = x.rl12110,    //备注
                    rl12620 = string.Empty, //担当者
                    rl12621 = 1,            //是否正式数据 0: 否, 1: 是
                    rl12622 = _rl12622      //排序序号
                };
                szrl126s.Add(szrl126);
                #region 金回支付[默认-2条空数据]
                if (x.rl12102 == 1)
                {
                    _rl12622 = _rl12622 + 1;
                    szrl126 szrl126_01 = new szrl126
                    {
                        //rl12601 = PrimaryKeyHelper.NewComb().ToString(),
                        rl12605 = 0,              //0: 金回支付, 1: 今后支付预定
                        rl12603 = 1,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
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
                        rl12603 = 1,              //初始来源 0:合同支付计划, 1:合同验收计划, 2: 自定义新增
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
