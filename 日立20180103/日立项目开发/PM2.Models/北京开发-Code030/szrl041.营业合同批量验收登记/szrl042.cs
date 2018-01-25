using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl042
    public class szrl042 : Enttity
    {

        /// <summary>
        /// ID
        /// </summary> 
        [EasyTextbox]
        public string rl04201 { get; set; }
        /// <summary>
        /// 批量验收登记ID
        /// </summary> 
        [EasyTextbox]
        public string rl04202 { get; set; }
        /// <summary>
        /// 验收计划明细ID
        /// </summary> 
        [EasyTextbox]
        public string rl04203 { get; set; }
        /// <summary>
        /// 验收日期
        /// </summary> 
        [EasyTextbox]
        public string rl04204 { get; set; }
        /// <summary>
        /// 验收金额
        /// </summary> 
        [EasyTextbox]
        public decimal rl04205 { get; set; }
        /// <summary>
        /// 验收证明取得日
        /// </summary> 
        [EasyTextbox]
        public string rl04206 { get; set; }
        /// <summary>
        /// 外部/内部验收
        /// </summary> 
        [EasyTextbox]
        public string rl04207 { get; set; }
        /// <summary>
        /// 完工证明
        /// </summary> 
        [EasyTextbox]
        public bool rl04208 { get; set; }
        /// <summary>
        /// 状态
        /// </summary> 
        [EasyTextbox]
        public int rl04209 { get; set; }
        /// <summary>
        /// 款项性质
        /// </summary> 
        [EasyTextbox]
        public string rl04210 { get; set; }
        /// <summary>
        /// 计划验收比例
        /// </summary> 
        [EasyTextbox]
        public decimal rl04211 { get; set; }
        /// <summary>
        /// 计划验收金额
        /// </summary> 
        [EasyTextbox]
        public decimal rl04212 { get; set; }
        /// <summary>
        /// 计划验收日期
        /// </summary> 
        [EasyTextbox]
        public string rl04213 { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary> 
        [EasyTextbox]
        public string rl04214 { get; set; }
        /// <summary>
        /// 合同序列号
        /// </summary> 
        [EasyTextbox]
        public string rl04215 { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary> 
        [EasyTextbox]
        public decimal? rl04216 { get; set; }

    }
}

