using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.szrl111Model
{
    //szrl111
    public class szrl111 : Enttity
    {

        /// <summary>
        /// ID
        /// </summary> 
        [EasyTextbox]
        public string rl11101 { get; set; }
        /// <summary>
        /// 材料分类
        /// </summary> 
        [EasyTextbox]
        public string rl11102 { get; set; }
        /// <summary>
        /// 材料编码
        /// </summary> 
        [EasyTextbox]
        public string rl11103 { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary> 
        [EasyTextbox]
        public string rl11104 { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary> 
        [EasyTextbox]
        public string rl11105 { get; set; }
        /// <summary>
        /// 品牌
        /// </summary> 
        [EasyTextbox]
        public string rl11106 { get; set; }
        /// <summary>
        /// 产地
        /// </summary> 
        [EasyTextbox]
        public string rl11107 { get; set; }
        /// <summary>
        /// 属性
        /// </summary> 
        [EasyTextbox]
        public string rl11108 { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary> 
        [EasyTextbox]
        public string rl11109 { get; set; }
        /// <summary>
        /// 备注
        /// </summary> 
        [EasyTextbox]
        public string rl11110 { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary> 
        [EasyTextbox]
        public DateTime rl11111 { get; set; }
        /// <summary>
        /// 添加人
        /// </summary> 
        [EasyTextbox]
        public string rl11112 { get; set; }

    }
}

