using Gmail.DDD.Repositorys;
using Gmail.DDD.Utility;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PM2.Repository.Code001
{
    public class sdpj004Repository : EFRepository<sdpj004>, Isdpj004Repository
    {
        public sdpj004Repository(IDbContextFactory factory, IUnitOfWork unitOfWork)
            : base(factory, unitOfWork)
        {
        }

        /// <summary>
        /// 获取用户对象
        /// </summary>
        /// <param name="pj00421">用户编码</param>
        /// <returns></returns>
        public CurrentUserInfo GetUserInfo(string pj00421)
        {
            sdpj004 sdpj004 = this.GetModels(x => x.pj00421.Equals(pj00421)).AsNoTracking()
                .Include(x => x.sdey003)
                .Include(x => x.sdpj003.sdpj025).SingleOrDefault();
            if (sdpj004 != null)
            {
                return new CurrentUserInfo {
                    Pj00401 = sdpj004.pj00401,
                    Pj00402 = sdpj004.pj00402,
                    Pj00421 = sdpj004.pj00421,
                    Pj00301 = sdpj004.sdpj003.pj00301,
                    Pj00302 = sdpj004.sdpj003.pj00302,
                    Pj02501 = sdpj004.sdpj003.sdpj025.pj02501,
                    Pj02505 = sdpj004.sdpj003.sdpj025.pj02505
                };
            }                
            return null;
        }

    }
}
