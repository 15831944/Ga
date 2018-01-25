using Gmail.DDD.Entity;
using Newtonsoft.Json;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code031
{
    /// <summary>
    /// [待支付确认]临时备份[0,预付款, 1:验收款]
    /// </summary>
    [Table(Name = "szrl140")]
    public partial class szrl140 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl14001 { get; set; }

        /// <summary>
        /// 主表ID szrl125.rl12501
        /// </summary>
        public string rl14002 { get; set; }

        /// <summary>
        /// 初始来源 0:合同支付计划, 1:合同验收计划
        /// </summary>
        public int rl14003 { get; set; }

        /// <summary>
        /// 来源ID  
        /// </summary>
        public string rl14004 { get; set; }

        /// <summary>
        /// 支付济
        /// </summary>
        public int rl14005 { get; set; }

        /// <summary>
        /// 支付日期
        /// </summary>
        public string rl14006 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl14007 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal rl14008 { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public string rl14009 { get; set; }

        /// <summary>
        /// 支付日期
        /// </summary>
        public string rl14010 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl14011 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal rl14012 { get; set; }

        /// <summary>
        /// 附件ID
        /// </summary>
        public string rl14013 { get; set; }

        /// <summary>
        /// 付款性质
        /// </summary>
        public int rl14014 { get; set; }

        /// <summary>
        /// 预付款扣款金额
        /// </summary>
        public decimal rl14015 { get; set; }

        /// <summary>
        /// 预付款扣款占合同%
        /// </summary>
        public decimal rl14016 { get; set; }

        /// <summary>
        /// 本次实际支付金额(含税)
        /// </summary>
        public decimal rl14017 { get; set; }

        /// <summary>
        /// 本次实际支付金额(不含税)
        /// </summary>
        public decimal rl14018 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string rl14019 { get; set; }

        /// <summary>
        /// 担当者 sdpj004.pj00401
        /// </summary>
        public string rl14020 { get; set; }

        /// <summary>
        /// 是否正式数据
        /// </summary>
        public int rl14021 { get; set; }

        /// <summary>
        /// 排序序号
        /// </summary>
        public int rl14022 { get; set; }

        /// <summary>
        /// 合同支付情况
        /// </summary>
        [JsonIgnore]
        public virtual szrl125 szrl125 { get; set; }

    }
}
