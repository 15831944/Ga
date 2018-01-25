using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Gmail.DDD.Entity;

namespace PM2.Service.Code030
{
    public class Staffing_sdbo001: SVEntity

    {
        #region Model
        /// <summary>
        /// 主键
        /// </summary>
        public string bo00101 { get; set; }
        /// <summary>
        /// 作番号
        /// </summary>
        public string bo00102 { get; set; }
        /// <summary>
        /// 作番名称
        /// </summary>
        public string bo00103 { get; set; }
        /// <summary>
        /// 作番现场审批本部长名称
        /// </summary>
        public string bo00104 { get; set; }
        /// <summary>
        /// 作番现场审批所长名称
        /// </summary>
        public string bo00105 { get; set; }
        /// <summary>
        /// 作番现场审批建筑工事长名称
        /// </summary>
        public string bo00106 { get; set; }
        /// <summary>
        /// 作番现场审批机械工事长名称
        /// </summary>
        public string bo00107 { get; set; }
        /// <summary>
        /// 作番现场审批建电气事长名称
        /// </summary>
        public string bo00108 { get; set; }
        /// <summary>
        /// 作番现场审批成套工事长名称
        /// </summary>
        public string bo00109 { get; set; }
        /// <summary>
        /// 作番现场审批建筑科长名称
        /// </summary>
        public string bo00110 { get; set; }
        /// <summary>
        /// 作番现场审批机械科长名称
        /// </summary>
        public string bo00111 { get; set; }
        /// <summary>
        /// 作番现场审批电气科长名称
        /// </summary>
        public string bo00112 { get; set; }
        /// <summary>
        /// 作番现场审批成套科长名称
        /// </summary>
        public string bo00113 { get; set; }
        /// <summary>
        /// 作番现场审批担当A1.1
        /// </summary>
        public string bo00114 { get; set; }
        /// <summary>
        /// 作番现场审批担当A1.2
        /// </summary>
        public string bo00115 { get; set; }
        /// <summary>
        /// 作番现场审批担当A1.3
        /// </summary>
        public string bo00116 { get; set; }
        /// <summary>
        /// 作番现场审批担当A1.4
        /// </summary>
        public string bo00117 { get; set; }
        /// <summary>
        /// 作番现场审批担当A1.5
        /// </summary>
        public string bo00118 { get; set; }
        /// <summary>
        /// 作番现场审批担当M1.1
        /// </summary>
        public string bo00119 { get; set; }
        /// <summary>
        /// 作番现场审批担当M1.2
        /// </summary>
        public string bo00120 { get; set; }
        /// <summary>
        /// 作番现场审批担当M1.3
        /// </summary>
        public string bo00121 { get; set; }
        /// <summary>
        /// 作番现场审批担当M1.4
        /// </summary>
        public string bo00122 { get; set; }
        /// <summary>
        /// 作番现场审批担当M1.5
        /// </summary>
        public string bo00123 { get; set; }
        /// <summary>
        /// 作番现场审批担当E1.1
        /// </summary>
        public string bo00124 { get; set; }
        /// <summary>
        /// 作番现场审批担当E1.2
        /// </summary>
        public string bo00125 { get; set; }
        /// <summary>
        /// 作番现场审批担当E1.3
        /// </summary>
        public string bo00126 { get; set; }
        /// <summary>
        /// 作番现场审批担当E1.4
        /// </summary>
        public string bo00127 { get; set; }
        /// <summary>
        /// 作番现场审批担当E1.5
        /// </summary>
        public string bo00128 { get; set; }
        /// <summary>
        /// 作番现场审批担当P1.1
        /// </summary>
        public string bo00129 { get; set; }
        /// <summary>
        /// 作番现场审批担当P1.2
        /// </summary>
        public string bo00130 { get; set; }
        /// <summary>
        /// 作番现场审批担当P1.3
        /// </summary>
        public string bo00131 { get; set; }
        /// <summary>
        /// 作番现场审批担当P1.4
        /// </summary>
        public string bo00132 { get; set; }
        /// <summary>
        /// 作番现场审批担当P1.5
        /// </summary>
        public string bo00133 { get; set; }
        /// <summary>
        /// 部门审批采购本部长名称
        /// </summary>
        public string bo00134 { get; set; }
        /// <summary>
        /// 部门审批采购部长名称
        /// </summary>
        public string bo00135 { get; set; }
        /// <summary>
        /// 部门审批采购科长名称
        /// </summary>
        public string bo00136 { get; set; }
        /// <summary>
        /// 部门审批采购担当名称
        /// </summary>
        public string bo00137 { get; set; }
        /// <summary>
        /// 部门审批工程本部长名称
        /// </summary>
        public string bo00138 { get; set; }
        /// <summary>
        /// 部门审批工程部长名称
        /// </summary>
        public string bo00139 { get; set; }
        /// <summary>
        /// 部门审批工程科长名称
        /// </summary>
        public string bo00140 { get; set; }
        /// <summary>
        /// 部门审批工程担当名称
        /// </summary>
        public string bo00141 { get; set; }
        /// <summary>
        /// 部门审批财务本部长名称
        /// </summary>
        public string bo00142 { get; set; }
        /// <summary>
        /// 部门审批财务部长名称
        /// </summary>
        public string bo00143 { get; set; }
        /// <summary>
        /// 部门审批财务科长名称
        /// </summary>
        public string bo00144 { get; set; }
        /// <summary>
        /// 部门审批财务担当名称
        /// </summary>
        public string bo00145 { get; set; }
        /// <summary>
        /// 部门审批营业本部长名称
        /// </summary>
        public string bo00146 { get; set; }
        /// <summary>
        /// 部门审批营业部长名称
        /// </summary>
        public string bo00147 { get; set; }
        /// <summary>
        /// 部门审批营业科名称
        /// </summary>
        public string bo00148 { get; set; }
        /// <summary>
        /// 部门审批营业担当名称
        /// </summary>
        public string bo00149 { get; set; }
        /// <summary>
        /// 作番id
        /// </summary>
        public string bo00150 { get; set; }
        /// <summary>
        /// bo002主键
        /// </summary>
        public string bo00151 { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string bo00152 { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string bo00153 { get; set; }
        #endregion
    }
}
