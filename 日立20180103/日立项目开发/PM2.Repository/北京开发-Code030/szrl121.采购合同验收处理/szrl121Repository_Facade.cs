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
    public class szrl121Repository_Facade : EFRepository<szrl121>, Iszrl121Repository_Facade
    {
        public szrl121Repository_Facade(IDbContextFactory factory, IUnitOfWork unitOfWork)
             : base(factory, unitOfWork)
        { }

        public IEnumerable<szrl121SqlResult> QueryOverTimeData()
        {
            //string sql = @"SELECT rl12802,rl01806,rl10505,rl10522,rl10605,rl12106,rl12107,rl12108
            //               FROM szrl128  
            //               LEFT JOIN szrl105
            //               ON rl10503 = rl12802
            //               LEFT JOIN dbo.szrl018
            //               ON rl10502 = rl01801
            //               LEFT JOIN dbo.szrl106
            //               ON rl10501 = rl10602
            //               LEFT JOIN dbo.szrl121
            //               ON rl12801 = rl12124
            //               WHERE 
            //               rl10571=1 AND rl10572=1
            //               AND rl12107!=0 AND rl12108!=0
            //               AND CONVERT(DATETIME2,DATEADD(day,1,dateadd(dd,-day(rl12106),dateadd(m,1,rl12106)))) 
            //               <=   
            //               CONVERT(DATETIME2,GETDATE())
            //               AND rl12111 IN (0,1,2,3)";
            //    string sql = @"WITH MaxTable AS
            //                   (
            //SELECT [FileA] = rl12802,[FileB] = MAX(rl12813) FROM szrl128   GROUP BY rl12802
            //                   )
            // SELECT rl12802,rl01806,rl10505,rl10522,rl10605,rl12106,rl12107,rl12108
            //                   FROM szrl128  
            //                   LEFT JOIN szrl105
            //                   ON rl10503 = rl12802
            //                   LEFT JOIN dbo.szrl018
            //                   ON rl10502 = rl01801
            //                   LEFT JOIN dbo.szrl106
            //                   ON rl10501 = rl10602
            //                   LEFT JOIN dbo.szrl121
            //                   ON rl12801 = rl12124
            //                   WHERE 
            //                   rl10571=1 AND rl10572=1
            //                   AND rl12107!=0 AND rl12108!=0
            //                   AND CONVERT(DATETIME2,DATEADD(day,1,dateadd(dd,-day(rl12106),dateadd(m,1,rl12106)))) 
            //                   <=   
            //                   CONVERT(DATETIME2,GETDATE())
            //                   AND rl12111 IN (0,1,2,3) 
            //                   AND rl12124 IN (
            //                     SELECT rl12801 FROM szrl128 INNER JOIN MaxTable
            //                     ON rl12802 = [FileA]
            //                     AND [FileB] = rl12813)";
            string sql = "select * from rlvw_QueryOverTimeData";
            System.Data.Common.DbParameter[] abc = new System.Data.Common.DbParameter[] { };
            return this.SQLHelper.ExecuteSqlQuery<szrl121SqlResult>(sql,abc);
        }
    }
}
