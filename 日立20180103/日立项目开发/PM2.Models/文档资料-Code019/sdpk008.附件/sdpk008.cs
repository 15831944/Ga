using Gmail.DDD.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code019
{
    [Table(Name = "sdpk008")]
    public partial class sdpk008 : Enttity
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string pk00801 { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>
        public string pk00802 { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string pk00803 { get; set; }

        /// <summary>
        /// 附件内容
        /// </summary>
        public byte[] pk00804 { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(ColumnType = ColumnType.CreateDateTime)]
        public string pk00805 { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Column(ColumnType = ColumnType.UpdateDateTime)]
        public string pk00806 { get; set; }

        /// <summary>
        /// 数据所有者
        /// </summary>
        public string pk00807 { get; set; }

        /// <summary>
        /// 数据修改人
        /// </summary>
        public string pk00808 { get; set; }

        /// <summary>
        /// 数据访问权限
        /// </summary>
        public string pk00809 { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        public FileType pk00810 { get; set; }

        /// <summary>
        /// 文档号
        /// </summary>
        public string pk00811 { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string pk00812 { get; set; }

        /// <summary>
        /// 修改原因
        /// </summary>
        public string pk00813 { get; set; }

        /// <summary>
        /// 归档位置
        /// </summary>
        public string pk00814 { get; set; }

        [JsonIgnore]
        public virtual ICollection<sdpk007> sdpk007s { get; set; }
        public sdpk008()
        {
            this.sdpk007s = new List<sdpk007>();
        }

    }
}
