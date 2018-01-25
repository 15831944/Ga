using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl033
    public class szrl033 : Enttity
    {

        /// <summary>
        /// 合同验收ID
        /// </summary> 
        [EasyTextbox]
        public string rl03301 { get; set; }
        /// <summary>
        /// 合同ID
        /// </summary> 
        [EasyTextbox]
        public string rl03302 { get; set; }
        /// <summary>
        /// 营业合同名称
        /// </summary> 
        [EasyTextbox]
        public string rl03303 { get; set; }
        /// <summary>
        /// 合同金额
        /// </summary> 
        [EasyTextbox]
        public decimal rl03304 { get; set; }
        /// <summary>
        /// 支付条件
        /// </summary> 
        [EasyTextbox]
        public string rl03305 { get; set; }
        /// <summary>
        /// 项目100%完工证明
        /// </summary> 
        [EasyTextbox]
        public byte rl03306 { get; set; }
        /// <summary>
        /// 工程完工证明取得日
        /// </summary> 
        [EasyTextbox]
        public string rl03307 { get; set; }
        /// <summary>
        /// 实际完工日期
        /// </summary> 
        [EasyTextbox]
        public string rl03308 { get; set; }
        /// <summary>
        /// 制单人
        /// </summary> 
        [EasyTextbox]
        public string rl03309 { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary> 
        [EasyTextbox]
        public string rl03310 { get; set; }
        /// <summary>
        /// 审核人
        /// </summary> 
        [EasyTextbox]
        public string rl03311 { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary> 
        [EasyTextbox]
        public string rl03312 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary> 
        [EasyTextbox]
        public int rl03313 { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary> 
        [EasyTextbox]
        public string rl03314 { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary> 
        [EasyTextbox]
        public string rl03315 { get; set; }
        /// <summary>
        /// 合同序列号
        /// </summary> 
        [EasyTextbox]
        public string rl03316 { get; set; }


        /// <summary>
        /// 验收登记明细
        /// </summary>
        public List<szrl034> szrl034List { get; set; }

    }
}

