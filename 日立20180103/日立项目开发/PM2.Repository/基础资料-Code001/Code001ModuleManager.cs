using Gmail.DDD.DataContext;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Entity;
using Gmail.DDD.IOC;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Repositorys.SQLBuilding;
using Gmail.DDD.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Repository.Code001
{
    public class Code001ModuleManager : ModuleManager
    {
        public override void Load()
        {
            this.RegisterType<sdpj004Repository, Isdpj004Repository>();
            this.RegisterType<sdey001Repository, Isdey001Repository>();
        }
        
    }
}
