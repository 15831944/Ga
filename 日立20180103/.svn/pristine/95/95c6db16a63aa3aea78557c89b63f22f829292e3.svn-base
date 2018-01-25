using Gmail.DDD.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code001
{
    [Table(Name = "sdpj025")]
    public partial class sdpj025 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string pj02501 { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Column(Index = 2)]
        public string pj02502 { get; set; }

        /// <summary>
        /// 排序吗
        /// </summary>

        [Column(Index = 3)]
        public string pj02503 { get; set; }

        /// <summary>
        /// 公司编码
        /// </summary>

        [Column(Index = 4)]
        public string pj02504 { get; set; }

        /// <summary>
        /// 公司简介
        /// </summary>

        [Column(Index = 5)]
        public string pj02505 { get; set; }

        /// <summary>
        /// 公司全称
        /// </summary>

        [Column(Index = 6)]
        public string pj02506 { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Column(Index = 7)]
        public string pj02507 { get; set; }

        /// <summary>
        /// 联系地址1
        /// </summary>
        [Column(Index = 8)]
        public string pj02508 { get; set; }

        /// <summary>
        /// 联系地址2
        /// </summary>
        [Column(Index = 9)]
        public string pj02509 { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Index = 10)]
        public string pj02510 { get; set; }

        /// <summary>
        /// 传真电话
        /// </summary>
        [Column(Index = 11)]
        public string pj02511 { get; set; }

        /// <summary>
        /// 法人代表
        /// </summary>
        [Column(Index = 12)]
        public string pj02512 { get; set; }

        /// <summary>
        /// 网络地址
        /// </summary>
        [Column(Index = 13)]
        public string pj02513 { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        [Column(Index = 14)]
        public string pj02514 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [Column(Index = 15)]
        public string pj02515 { get; set; }

        /// <summary>
        /// 当前财务月份
        /// </summary>
        [Column(Index = 16)]
        public string pj02516 { get; set; }

        /// <summary>
        /// 本位币
        /// </summary>
        [Column(Index = 17)]
        public string pj02517 { get; set; }

        /// <summary>
        /// 公司属性
        /// </summary>
        [Column(Index = 18)]
        public short pj02518 { get; set; }

        [JsonIgnore]
        public virtual sdpj025 Parent { get; set; }

        [JsonIgnore]
        public virtual ICollection<sdpj025> Children { get; set; }

        [JsonIgnore]
        public virtual ICollection<sdpj003> sdpj003s { get; set; }

        public sdpj025()
        {
            this.Children = new List<sdpj025>();
            this.sdpj003s = new List<sdpj003>();

        }

    }
}
