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
using PM2.Models.Code030;
using Gmail.DDD.Mvc;

namespace PM2.Repository.Code030
{
    public class szrl025Repository_Facade : EFRepository<szrl025>, Iszrl025Repository_Facade
    {
        public szrl025Repository_Facade(IDbContextFactory factory, IUnitOfWork unitOfWork)
             : base(factory, unitOfWork)
        { }

        public int Szrl025_check(string pj00402, string rl02535)
        {
          
            szrl025_check szrl025_check = new szrl025_check {
                rl02530 = pj00402,
                rl02531= DateTime.Now.ToString("yyyy-MM-dd"),
                rl02532 = 2,
                rl02535= rl02535
            };
            return this.SQLHelper.ExecuteNonQuery<szrl025_check>(szrl025_check);

        }
    }
}
