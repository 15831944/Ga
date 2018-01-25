using Gmail.DDD.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code001
{
    [Table(Name = "sdey003")]
    public partial class sdey003 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string ey00301 { get; set; }

        /// <summary>
        /// RTXQQ号码
        /// </summary>
        [Column(Index = 2)]
        public string ey00302 { get; set; }

        /// <summary>
        /// RTXQQ密码
        /// </summary>
        [Column(Index = 3)]
        public string ey00303 { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Column(Index = 4)]
        public byte ey00304 { get; set; }

        /// <summary>
        /// PM2密码
        /// </summary>
        [Column(Index = 5)]
        public string ey00305 { get; set; }

        /// <summary>
        /// 是否系统管理员
        /// </summary>
        [Column(Index = 6)]
        public byte ey00306 { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [Column(Index = 7)]
        public string ey00307 { get; set; }

        /// <summary>
        /// 特殊限制
        /// </summary>
        [Column(Index = 8)]
        public byte ey00308 { get; set; }

        /// <summary>
        /// 网络地址
        /// </summary>
        [Column(Index = 9)]
        public string ey00309 { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Column(Index = 10)]
        public string ey00310 { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column(Index = 11)]
        public string ey00311 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column(Index = 12)]
        public string ey00312 { get; set; }

        /// <summary>
        /// 登陆名
        /// </summary>
        [Column(Index = 13)]
        public string ey00313 { get; set; }

        /// <summary>
        /// 前台登录校验软件狗
        /// </summary>
        [Column(Index = 14)]
        public byte ey00314 { get; set; }

        /// <summary>
        /// 软件狗序列号
        /// </summary>
        [Column(Index = 15)]
        public string ey00315 { get; set; }

        /// <summary>
        /// 校验间隔时间（分钟）
        /// </summary>
        [Column(Index = 16)]
        public int ey00316 { get; set; }

        /// <summary>
        /// 初始标志
        /// </summary>
        [Column(Index = 17)]
        public byte ey00317 { get; set; }

        /// <summary>
        /// 邮件SMTP
        /// </summary>
        [Column(Index = 18)]
        public string ey00318 { get; set; }

        /// <summary>
        /// 邮件端口
        /// </summary>
        [Column(Index = 19)]
        public int ey00319 { get; set; }

        /// <summary>
        /// 邮件账号
        /// </summary>
        [Column(Index = 20)]
        public string ey00320 { get; set; }

        /// <summary>
        /// 账号密码
        /// </summary>
        [Column(Index = 21)]
        public string ey00321 { get; set; }

        [JsonIgnore]
        public virtual ICollection<sdpj004> sdpj004s { get; set; }

        public sdey003()
        {
            this.sdpj004s = new List<sdpj004>();
        }

    }
}
