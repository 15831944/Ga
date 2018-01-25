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
using Gmail.DDD.AOP;
using PM2.Repository.Code031;
#endregion
namespace PM2.Service.Code031
{
    public class AdvanceBeforeSaveAttribute : BeforeExecuteAttribute
    {
        public AdvanceBeforeSaveAttribute()
            : base(true)
        { }

        #region 保存前验证
        /// <summary>
        /// 保存前验证
        /// </summary>
        /// <param name="context"></param>
        protected override void ActionExecute(MethodContext context)
        {
            szrl125 szrl125 = context.GetParValue<szrl125>("szrl125");
            IDbContextScopeFactory scopeFactory = this.Resolve<IDbContextScopeFactory>();
            Iszrl125Repository_Facade _szrl125Repository = this.Resolve<Iszrl125Repository_Facade>();
            using (IDbContextScope scope = scopeFactory.CreateScope())
            {
                //当数据是否初始化
                bool isInit = _szrl125Repository.IsInitialize(szrl125.rl12502);
                if (isInit)
                    return;

                szrl125 _szrl125 = _szrl125Repository.GetModels(x => x.rl12502.Equals(szrl125.rl12502)).Single();
                _szrl125.rl12507 = szrl125.rl12507;
                scope.SaveChanges();
                context.ReturnValue  = OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "数据初始化成功!", new
                {
                    rl12507 = _szrl125.rl12507
                });
            }
        }
        #endregion
    }
}
