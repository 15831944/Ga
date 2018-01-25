using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Code.Specification
{
    public interface ISpecification
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        string Where { set; get; }

        /// <summary>
        /// DbParameters
        /// </summary>
        IEnumerable<DbParameter> DbParameters { set; get; }
    }
}
