using Gmail.DDD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    [Function(Name = "GetModuleWeb", FuncType = FunctionType.Proc)]
    public class GetModuleWeb : ProcedureEntity
    {
        [Parameter(Index = 0)]
        public string loginCode { get; set; }
    }
}
