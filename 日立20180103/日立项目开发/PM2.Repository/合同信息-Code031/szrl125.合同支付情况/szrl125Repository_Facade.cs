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
namespace PM2.Repository.Code031
{
    public class szrl125Repository_Facade : EFRepository<szrl125>, Iszrl125Repository_Facade
    {
        private IEFRepository<szrl126> _szrl126Repository;
        private IEFRepository<szrl127> _szrl127Repository;
        private IEFRepository<szrl140> _szrl140Repository;
        public szrl125Repository_Facade(IDbContextFactory dbFactory, 
            IUnitOfWork unitOfWork,
            IEFRepository<szrl126> szrl126Repository,
            IEFRepository<szrl127> szrl127Repository,
            IEFRepository<szrl140> szrl140Repository)
            : base(dbFactory, unitOfWork)
        {
            this._szrl126Repository = szrl126Repository;
            this._szrl127Repository = szrl127Repository;
            this._szrl140Repository = szrl140Repository;
        }

        #region 检测合同是否为初始化状态
        /// <summary>
        /// 检测合同是否为[初始化状态]
        /// </summary>
        /// <param name="rl12502">合同ID</param>
        /// <returns></returns>
        public bool IsInitialize(string rl12502)
        {
            szrl125 szrl125 = this.GetModels(x => x.rl12502.Equals(rl12502))
                                  .Include(x => x.szrl126s)
                                  .Include(x => x.szrl127s)
                                  .AsNoTracking()
                                  .SingleOrDefault();
            if (szrl125 != null)
            {
                if (szrl125.szrl127s.IsAny())
                    return false;

                if (szrl125.szrl126s.IsAny())
                    return false;
            }
            return true;
        }
        #endregion
        #region 获取-[待支付确认]合同支付情况
        /// <summary>
        /// 获取-[待支付确认]合同支付情况
        /// </summary>
        /// <param name="rl12502">合同ID</param>
        /// <returns></returns>
        public async Task<szrl125> GetSzrl126s(string rl12502)
        {
            return await this.GetModels(x => x.rl12502.Equals(rl12502))
                             .Include(x => x.szrl126s)
                             .Include(x=> x.szrl140s)
                             .SingleOrDefaultAsync();
        }
        #endregion
        #region 获取-[已支付确认]合同支付情况
        /// <summary>
        /// 获取-[已支付确认]合同支付情况
        /// </summary>
        /// <param name="rl12502"></param>
        /// <returns></returns>
        public async Task<szrl125> GetSzrl127s(string rl12502)
        {
            try
            {
                IQueryable<szrl125> szrl125s = this.GetModels(x => x.rl12502.Equals(rl12502))
                                               .Include(x => x.szrl127s);
                return await szrl125s.SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 操作-[待支付确认]合同支付情况
        public void Szrl126Add(szrl126 szrl126)
        {
            this._szrl126Repository.Add(szrl126);
        }

        public void Szrl126Remove(szrl126 szrl126)
        {
            this._szrl126Repository.Remove(szrl126);
        }

        public void Szrl126RemoveRange(IEnumerable<szrl126> szrl126s)
        {
            this._szrl126Repository.RemoveRange(szrl126s);
        }
        #endregion
        #region 操作-[待支付确认]临时备份[0,预付款, 1:验收款]
        public void Szrl140Add(szrl140 szrl140)
        {
            this._szrl140Repository.Add(szrl140);
        }

        public void Szrl140Remove(szrl140 szrl140)
        {
            this._szrl140Repository.Remove(szrl140);
        }

        public void Szrl140RemoveRange(IEnumerable<szrl140> szrl140s)
        {
            this._szrl140Repository.RemoveRange(szrl140s);
        }
        #endregion

    }
}
