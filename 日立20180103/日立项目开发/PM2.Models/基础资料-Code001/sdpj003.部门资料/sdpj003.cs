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
        /// ��������
        /// </summary>
        [Column(Index = 2)]
        public string pj00302 { get; set; }
        /// <summary>
        /// �ϼ�ID
        /// </summary>
        [Column(Index = 3)]
        public string pj00303 { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [Column(Index = 4)]
        public string pj00304 { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [Column(Index = 5)]
        public string pj00305 { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        [Column(Index = 6)]
        public string pj00306 { get; set; }
        /// <summary>
        /// �칫�ص�
        /// </summary>
        [Column(Index = 7)]
        public string pj00307 { get; set; }
        /// <summary>
        /// ��ע˵��
        /// </summary>
        [Column(Index = 8)]
        public string pj00308 { get; set; }
        /// <summary>
        /// ���ű���
        /// </summary>
        [Column(Index = 9)]
        public string pj00309 { get; set; }
        /// <summary>
        /// ��֯����
        /// </summary>
        [Column(Index = 10)]
        public byte pj00310 { get; set; }
        /// <summary>
        /// ������˾
        /// </summary>
        [Column(Index = 11)]
        public string pj00311 { get; set; }
        /// <summary>
        /// ���ŷֹ��쵼
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
