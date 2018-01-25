using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;

namespace PM2.Models.Code030
{
    public partial class sdbo002 : Enttity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string bo00201 { get; set; }
        /// <summary>
        /// 作番号
        /// </summary>
        [EasyTextbox]
        public string bo00220 { get; set; }
        /// <summary>
        /// 作番名称
        /// </summary>
        [EasyTextbox]
        public string bo00202 { get; set; }
        /// <summary>
        /// 采购部本部长
        /// </summary>
        [EasyTextbox]
        public string bo00203 { get; set; }
        /// <summary>
        /// 采购部部长
        /// </summary>
        [EasyTextbox]
        public string bo00204 { get; set; }
        /// <summary>
        /// 采购部科长
        /// </summary>
        [EasyTextbox]
        public string bo00205 { get; set; }
        /// <summary>
        /// 采购部担当
        /// </summary>
        [EasyTextbox]
        public string bo00206 { get; set; }
        /// <summary>
        /// 工程管理部长
        /// </summary>
        [EasyTextbox]
        public string bo00207 { get; set; }
        /// <summary>
        /// 工程管理科长
        /// </summary>
        [EasyTextbox]
        public string bo00208 { get; set; }
        /// <summary>
        /// 工程管理担当
        /// </summary>
        [EasyTextbox]
        public string bo00209 { get; set; }
        /// <summary>
        /// 财务部本部长
        /// </summary>
        [EasyTextbox]
        public string bo00210 { get; set; }
        /// <summary>
        /// 财务部部长
        /// </summary>
        [EasyTextbox]
        public string bo00211 { get; set; }
        /// <summary>
        /// 财务部本科长
        /// </summary>
        [EasyTextbox]
        public string bo00212 { get; set; }
        /// <summary>
        /// 财务部担当
        /// </summary>
        [EasyTextbox]
        public string bo00213 { get; set; }
        /// <summary>
        /// 营业部本部长
        /// </summary>
        [EasyTextbox]
        public string bo00214 { get; set; }
        /// <summary>
        /// 营业部部长
        /// </summary>
        [EasyTextbox]
        public string bo00215 { get; set; }
        /// <summary>
        /// 营业部科长
        /// </summary>
        [EasyTextbox]
        public string bo00216 { get; set; }
        /// <summary>
        /// 营业部本担当
        /// </summary>
        [EasyTextbox]
        public string bo00217 { get; set; }
        /// <summary>
        /// 作番id
        /// </summary>
        [EasyTextbox]
        public string bo00218 { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        [EasyTextbox]
        public string bo00219 { get; set; }
    }
}
