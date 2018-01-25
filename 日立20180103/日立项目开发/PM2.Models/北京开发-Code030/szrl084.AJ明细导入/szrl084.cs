using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    public partial class szrl084 : Enttity
    {
        #region Model
        /// <summary>
        /// rl08401
        /// </summary>        
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl08401 { get; set; }
        /// <summary>
        /// 目录代码
        /// </summary>        
        [EasyTextbox]
        public string rl08402 { get; set; }
        /// <summary>
        /// 一级目录
        /// </summary>        
        [EasyTextbox]
        public string rl08403 { get; set; }
        /// <summary>
        /// 材料编码
        /// </summary>        
        [EasyTextbox]
        public string rl08404 { get; set; }
        /// <summary>
        /// 件品名及摘要
        /// </summary>        
        [EasyTextbox]
        public string rl08405 { get; set; }
        /// <summary>
        /// 数量
        /// </summary>        
        [EasyTextbox]
        public decimal rl08406 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>        
        [EasyTextbox]
        public string rl08407 { get; set; }
        /// <summary>
        /// 税込金額——単価(税込）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08408 { get; set; }
        /// <summary>
        /// 税込金額——小計（税込）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08409 { get; set; }
        /// <summary>
        /// 税込金額——計（税込）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08410 { get; set; }
        /// <summary>
        /// 税率
        /// </summary>        
        [EasyTextbox]
        public decimal rl08411 { get; set; }
        /// <summary>
        /// 税抜金額——単価(税抜）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08412 { get; set; }
        /// <summary>
        /// 税抜金額——小計（税抜）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08413 { get; set; }
        /// <summary>
        /// 税抜金額——計（税抜）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08414 { get; set; }
        /// <summary>
        /// 作番id
        /// </summary>        
        [EasyTextbox]
        public string rl08415 { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>        
        [EasyTextbox]
        public string rl08416 { get; set; }
        /// <summary>
        /// 变更类型
        /// </summary>        
        [EasyTextbox]
        public string rl08417 { get; set; }
        #endregion
    }
}
