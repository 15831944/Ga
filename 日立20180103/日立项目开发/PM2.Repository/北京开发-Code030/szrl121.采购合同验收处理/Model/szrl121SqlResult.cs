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
using Gmail.DDD.Entity;
using Gmail.DDD.Mvc;

namespace PM2.Repository.Code030
{
    public class szrl121SqlResult : SVEntity
    { 
        public string rl12121 { get; set; }
        public string rl01806 { get; set; }
        public string rl10505 { get; set; }
        public decimal rl10522 { get; set; }
        public string rl10605 { get; set; }
        public string rl12106 { get; set; }
        public decimal rl12107 { get; set; }
        public decimal rl12108 { get; set; }
    }
}
