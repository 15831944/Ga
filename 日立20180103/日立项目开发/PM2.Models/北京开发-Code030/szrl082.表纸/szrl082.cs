using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    public partial class szrl082 : Enttity
    {
        #region Model
        /// <summary>
        /// 主键
        /// </summary>        
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl08201 { get; set; }
        /// <summary>
        /// 初回発行日
        /// </summary>        
        [EasyTextbox]
        public string rl08202 { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>        
        [EasyTextbox]
        public string rl08203 { get; set; }
        /// <summary>
        /// 作番ID
        /// </summary>        
        [EasyTextbox]
        public string rl08204 { get; set; }
        /// <summary>
        /// 予算作成日
        /// </summary>        
        [EasyTextbox]
        public string rl08205 { get; set; }
        /// <summary>
        /// 予算審議会開催日
        /// </summary>        
        [EasyTextbox]
        public string rl08206 { get; set; }
        /// <summary>
        /// 機材手配日
        /// </summary>        
        [EasyTextbox]
        public string rl08207 { get; set; }
        /// <summary>
        /// 着工予定日
        /// </summary>        
        [EasyTextbox]
        public string rl08208 { get; set; }
        /// <summary>
        /// 工事完成予定日
        /// </summary>        
        [EasyTextbox]
        public string rl08209 { get; set; }
        /// <summary>
        /// 受注日
        /// </summary>        
        [EasyTextbox]
        public string rl08210 { get; set; }
        /// <summary>
        /// 契約納期
        /// </summary>        
        [EasyTextbox]
        public string rl08211 { get; set; }
        /// <summary>
        /// 訂正日
        /// </summary>        
        [EasyTextbox]
        public string rl08212 { get; set; }
        /// <summary>
        /// 訂正No
        /// </summary>        
        [EasyTextbox]
        public string rl08213 { get; set; }
        /// <summary>
        /// 見積金額（提出金額）
        /// </summary>        
        [EasyTextbox]
        public decimal rl08214 { get; set; }
        /// <summary>
        /// 外貨換算(RATE)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08215 { get; set; }
        /// <summary>
        /// 総受注予定金額
        /// </summary>        
        [EasyTextbox]
        public decimal rl08216 { get; set; }
        /// <summary>
        /// 現状受注金額
        /// </summary>        
        [EasyTextbox]
        public decimal rl08217 { get; set; }
        /// <summary>
        /// VAT(増値税)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08218 { get; set; }
        /// <summary>
        /// 手配受注金額
        /// </summary>        
        [EasyTextbox]
        public decimal rl08219 { get; set; }
        /// <summary>
        /// 実行予算金額(ＢＰ)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08220 { get; set; }
        /// <summary>
        /// 損益金額
        /// </summary>        
        [EasyTextbox]
        public decimal rl08221 { get; set; }
        /// <summary>
        /// 損益率(％)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08222 { get; set; }
        /// <summary>
        /// 目標粗利率(％)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08223 { get; set; }
        /// <summary>
        /// 粗利率(%)
        /// </summary>        
        [EasyTextbox]
        public decimal rl08224 { get; set; }
        /// <summary>
        /// 受注传票版本号
        /// </summary>        
        [EasyTextbox]
        public string rl08225 { get; set; }
        /// <summary>
        /// 訂正前予算
        /// </summary>        
        [EasyTextbox]
        public string rl08226 { get; set; }
        /// <summary>
        /// 比例
        /// </summary>        
        [EasyTextbox]
        public decimal rl08227 { get; set; }
        /// <summary>
        /// NO11的J3【城建税及び附加等】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08228 { get; set; }
        /// <summary>
        /// NO17的【小計(直接費)】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08229 { get; set; }
        /// <summary>
        /// NO18【割掛率(会社経費)】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08230 { get; set; }
        /// <summary>
        /// NO19【技術提携料(受注金額比率)】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08231 { get; set; }
        /// <summary>
        /// NO20【小計(経費)】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08232 { get; set; }
        /// <summary>
        /// NO21【実行予算総合計】
        /// </summary>        
        [EasyTextbox]
        public decimal rl08233 { get; set; }
        /// <summary>
        /// 变更类型
        /// </summary>        
        [EasyTextbox]
        public string rl08234 { get; set; }
        /// <summary>
        /// 变更理由
        /// </summary>        
        [EasyTextbox]
        public string rl08235 { get; set; }
        /// <summary>
        /// 是否正式版   0 否  1 是
        /// </summary>        
        [EasyTextbox]
        public byte rl08236 { get; set; }
        /// <summary>
		/// 制单人
        /// </summary>        
        [EasyTextbox]
        public string rl08237 { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>        
        [EasyTextbox]
        public string rl08238 { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>        
        [EasyTextbox]
        public string rl08239 { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>        
        [EasyTextbox]
        public string rl08240 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>        
        [EasyTextbox]
        public int rl08241 { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>        
        [EasyTextbox]
        public string rl08242 { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>        
        [EasyTextbox]
        public string rl08243 { get; set; }
        /// <summary>
        /// 比例2
        /// </summary>        
        [EasyTextbox]
        public decimal rl08244 { get; set; }
        /// <summary>
        /// 比例3
        /// </summary>        
        [EasyCombobox]
        public decimal rl08245 { get; set; }
        /// <summary>
        /// NO17小计直接费 不含税
        /// </summary>
        [EasyTextbox]
        public decimal rl08246 { get; set; }
        #endregion
    }
}
