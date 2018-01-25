using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.szrl033Model
{
    //szrl041
    public class szrl041 : Enttity
    {

        /// <summary>
        /// ID
        /// </summary> 
        [EasyTextbox]
        public string rl04101 { get; set; }
        /// <summary>
        /// 批次
        /// </summary> 
        [EasyTextbox]
        public string rl04102 { get; set; }
        /// <summary>
        /// 作番号
        /// </summary> 
        [EasyTextbox]
        public string rl04103 { get; set; }
        /// <summary>
        /// 作番名称
        /// </summary> 
        [EasyTextbox]
        public string rl04104 { get; set; }
        /// <summary>
        /// 客户ID
        /// </summary> 
        [EasyTextbox]
        public string rl04105 { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary> 
        [EasyTextbox]
        public string rl04106 { get; set; }
        /// <summary>
        /// 制单人
        /// </summary> 
        [EasyTextbox]
        public string rl04107 { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary> 
        [EasyTextbox]
        public string rl04108 { get; set; }
        /// <summary>
        /// 审核人
        /// </summary> 
        [EasyTextbox]
        public string rl04109 { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary> 
        [EasyTextbox]
        public string rl04110 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary> 
        [EasyTextbox]
        public int rl04111 { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary> 
        [EasyTextbox]
        public string rl04112 { get; set; }
        /// <summary>
        /// 最后修改日期
        /// </summary> 
        [EasyTextbox]
        public string rl04113 { get; set; }

    }
}

