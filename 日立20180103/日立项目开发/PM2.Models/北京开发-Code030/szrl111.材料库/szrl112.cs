using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;
using System.ComponentModel.DataAnnotations;

namespace PM2.Models.Code030.szrl111Model
{
    //szrl112
    public class szrl112 : Enttity
    {

        /// <summary>
        /// ID
        /// </summary> 
        [EasyTextbox]
        public string rl11201 { get; set; }
        /// <summary>
        /// 上级分类名称
        /// </summary> 
        [EasyTextbox]
        public string rl11202 { get; set; }
        /// <summary>
        /// 本机目录编码
        /// </summary> 
        [EasyTextbox]
        public string rl11203 { get; set; }
        /// <summary>
        /// 本级分类名称
        /// </summary> 
        [EasyTextbox]
        public string rl11204 { get; set; }
        /// <summary>
        /// 目录属性
        /// </summary> 
        [EasyTextbox]
        public string rl11205 { get; set; }
        /// <summary>
        /// 排序码
        /// </summary> 
        [EasyTextbox]
        public decimal rl11206 { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary> 
        [EasyTextbox]
        public DateTime rl11207 { get; set; }
        /// <summary>
        /// 添加人
        /// </summary> 
        [EasyTextbox]
        public string rl11208 { get; set; }
        /// <summary>
        /// 上级目录ID（内部）
        /// </summary> 
        [EasyTextbox]
        public string rl11209 { get; set; }

        /// <summary>
        /// 最大的目录ID
        /// </summary>
        public int rl11210 { get; set; }

        /// <summary>
        /// 本级目录编码（内部）
        /// </summary>
        public string rl11211 { get; set; }

        /// <summary>
        /// 最大的材料ID
        /// </summary>
        public int rl11212 { get; set; }

        /// <summary>
        /// 上级目录编码（全）
        /// </summary>
        public string rl11213 { get; set; }

        /// <summary>
        /// 上级目录ID
        /// </summary>
        public string rl11214 { get; set; }

        /// <summary>
        /// 目录级别
        /// </summary>
        public int rl11215 { get; set; }
    }
}

