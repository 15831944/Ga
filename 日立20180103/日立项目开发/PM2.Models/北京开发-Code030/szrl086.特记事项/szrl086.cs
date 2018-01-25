using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    public partial class szrl086 : Enttity
    {
        #region Model
         
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl08601 { get; set; }
        /// <summary>
        /// 作番id
        /// </summary>        
        [EasyTextbox]
        public string rl08602 { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>        
        [EasyTextbox]
        public string rl08603 { get; set; }
        /// <summary>
        /// 变更类型
        /// </summary>        
        [EasyTextbox]
        public string rl08604 { get; set; }
        /// <summary>
        /// 事项
        /// </summary>        
        [EasyTextbox]
        public string rl08605 { get; set; }
        /// <summary>
        /// 文字说明
        /// </summary>        
        [EasyTextbox]
        public string rl08606 { get; set; }
        /// <summary>
        /// 数量
        /// </summary>        
        [EasyTextbox]
        public decimal rl08607 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>        
        [EasyTextbox]
        public string rl08608 { get; set; }
        #endregion
    }
}
