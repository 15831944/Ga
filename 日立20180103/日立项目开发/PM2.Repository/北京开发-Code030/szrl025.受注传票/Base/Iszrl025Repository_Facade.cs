using Gmail.DDD.IOC;
using Gmail.DDD.Mvc;
using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using PM2.Models.Code030;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code030
{
    public interface Iszrl025Repository_Facade : IEFRepository<szrl025>
    {
        int Szrl025_check(string pj00402, string rl02535);
    }
}
