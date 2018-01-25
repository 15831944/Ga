using Gmail.DDD.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code001
{
    [Table(Name = "sdpj003")]
    public partial class sdpj003 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string pj00301 { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Column(Index = 2)]
        public string pj00302 { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        [Column(Index = 3)]
        public string pj00303 { get; set; }
        /// <summary>
        /// 排序吗
        /// </summary>
        [Column(Index = 4)]
        public string pj00304 { get; set; }
        /// <summary>
        /// 部门主管
        /// </summary>
        [Column(Index = 5)]
        public string pj00305 { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(Index = 6)]
        public string pj00306 { get; set; }
        /// <summary>
        /// 办公地点
        /// </summary>
        [Column(Index = 7)]
        public string pj00307 { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        [Column(Index = 8)]
        public string pj00308 { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        [Column(Index = 9)]
        public string pj00309 { get; set; }
        /// <summary>
        /// 组织属性
        /// </summary>
        [Column(Index = 10)]
        public byte pj00310 { get; set; }
        /// <summary>
        /// 所属公司
        /// </summary>
        [Column(Index = 11)]
        public string pj00311 { get; set; }
        /// <summary>
        /// 部门分管领导
        /// </summary>
        [Column(Index = 12)]
        public string pj00312 { get; set; }

        [JsonIgnore]
        public virtual sdpj003 Parent { get; set; }
        [JsonIgnore]
        public virtual ICollection<sdpj003> Children { get; set; }

        [JsonIgnore]
        public virtual sdpj025 sdpj025 { get; set; }
        [JsonIgnore]
        public virtual ICollection<sdpj004> sdpj004s { get; set; }

        public sdpj003()
        {
            this.Children = new List<sdpj003>();
            this.sdpj004s = new List<sdpj004>();
        }

    }
}
