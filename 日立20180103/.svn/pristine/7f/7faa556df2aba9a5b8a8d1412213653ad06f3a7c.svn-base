#region using
using FluentValidation;
using Gmail.DDD.Config;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Helper;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Service;
using Gmail.DDD.SSO;
using PM2.Code;
using PM2.Repository.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Gmail.DDD.Extensions;
using PM2.Models.Code030;	 
#endregion
namespace PM2.Service.Code030
{
    public class szrl105ServerAsync : Iszrl105ServerAsync
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdvw_szrl105View> _sdvw_szrl105ViewRepository;

        public szrl105ServerAsync(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdvw_szrl105View> sdvw_szrl105ViewRepository
        )
        {
            this._scopeFactory = scopeFactory;
            this._sdvw_szrl105ViewRepository = sdvw_szrl105ViewRepository;
        }

        #region 加载合同信息
        /// <summary>
        /// 加载合同信息
        /// </summary>
        /// <param name="pk"></param>
        /// <returns></returns>
        public async Task<IOperateResult> LoadFromAsync(string pk)
        {
            TaskAsync.StartAsync();
            using (IDbContextReadOnlyScope scope = this._scopeFactory.CreateReadOnlyScope())
            {
                sdvw_szrl105View x = await this._sdvw_szrl105ViewRepository.FindAsync(pk);
                return OperateResultFactory.FromLoadOperateResult(new { 
                     #region 基本信息
                     rl10503 = x.rl10503, //合同ID
                     rl01807 = x.rl01807, //项目名称
                     rl10505 = x.rl10505, //合同编号
                     rl10515 = x.rl10515, //开工日期
                     rl01806 = x.rl01806, //作番号
                     rl10606 = x.rl10606, //合同名称
                     rl10512 = x.rl10512, //完工日期
                     rl10519 = x.rl10519.AsTwoPoint(), //合同金额(含税)
                     rl10003 = x.rl10003, //供应商
                     rl10531 = x.rl10531.AsTwoPoint(), //预付款总金额
                     ProcA = x.ProcA.AsTwoPoint(),     //预付款未支付金额
                     ProcB = x.ProcB.AsPercentage(),   //已扣预付款占合同%
                     ProcC = x.ProcC.AsPercentage(),   //预付款占合同%
                     ProcD = x.ProcD.AsTwoPoint(),     //预付款累计扣款金额
                     ProcE = x.ProcE.AsTwoPoint(),     //已验收金额
                     ProcF = x.ProcF.AsTwoPoint(),     //预付款累计支付金额
                     ProcG = x.ProcG.AsTwoPoint(),     //预付款未扣款金额
                     ProcH = x.ProcH.AsPercentage(),   //已验收金额占合同%
                     ProcI = x.ProcI.AsTwoPoint(),     //累计含税发票金额
                     ProcJ = x.ProcJ.AsTwoPoint(),     //累计不含税发票金额
                     ProcK = x.ProcK.AsPercentage(),   //预付款累计支付占合同%
                     ProcL = x.ProcL.AsTwoPoint(),     //税率
                     pj00402 = x.pj00402,              //合同登录人员
                     ProcM = x.ProcM.AsTwoPoint(),     //本次含税发票金额
                     ProcN = x.ProcN.AsTwoPoint(),     //本次不含税发票金额
                     #endregion
                     #region 验收计划
                     rl12103 = x.rl12103,              //验收日期
                     rl12104 = x.rl12104.AsTwoPoint(), //验收比率
                     rl12105 = x.rl12105.AsTwoPoint(), //验收金额
                     
                     rl12106 = x.rl12106,              //验收日期
                     rl12107 = x.rl12107.AsTwoPoint(), //验收比率
                     rl12108 = x.rl12108.AsTwoPoint(), //验收金额
                     rl12110 = x.rl12110
                     #endregion
                });
            }
        }
        #endregion
        
    }
}
