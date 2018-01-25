using Gmail.DDD.Repositorys;
using Gmail.DDD.Utility;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Gmail.DDD.DataContext;

namespace PM2.Repository.Code001
{
    public class sdey001Repository : EFRepository<PM2.Models.sdey001>, Isdey001Repository
    {
        /// <summary>
        /// 默认使用Byprj数据库-强制使用Studio数据库
        /// </summary>
        protected override DbContextType DbContextType
        {
	        get 
	        {
                return DbContextType.StudioDbContext;
	        }
        }

        public sdey001Repository(IDbContextFactory factory, IUnitOfWork unitOfWork)
            : base(factory, unitOfWork)
        { }

        /// <summary>
        /// 根据[账套号]获取:PrjConn
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public string GetPrjConn(string Account)
        {
            PM2.Models.sdey001 sdey001 = this.Find(Account);
            string prjConn = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True", sdey001.ey00104, sdey001.ey00106, sdey001.ey00107, sdey001.ey00108);
            return prjConn;
        }
    }
}
