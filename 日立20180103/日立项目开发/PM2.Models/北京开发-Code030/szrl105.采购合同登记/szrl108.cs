using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030.Szrl105Model
{
    //szrl108
    public class szrl108 : Enttity
    {

        /// <summary>
        /// ID
        /// <//summary> 
        [EasyTextbox]
        public string rl10801 { get; set; }
        /// <summary>
        /// 编码
        /// <//summary> 
        [EasyTextbox]
        public string rl10802 { get; set; }
        /// <summary>
        /// 验收期间（中文）
        /// <//summary> 
        [EasyTextbox]
        public string rl10803 { get; set; }
        /// <summary>
        /// 验收期间（日文）
        /// <//summary> 
        [EasyTextbox]
        public string rl10804 { get; set; }
        /// <summary>
        /// 备注
        /// <//summary> 
        [EasyTextbox]
        public string rl10805 { get; set; }
        /// <summary>
        /// 添加时间
        /// <//summary> 
        [EasyTextbox]
        public DateTime? rl10806 { get; set; }

    }
}


