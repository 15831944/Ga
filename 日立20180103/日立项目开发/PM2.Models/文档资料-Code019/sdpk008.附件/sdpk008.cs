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
        /// ��������
        /// </summary>
        public string pk00802 { get; set; }

        /// <summary>
        /// ԭ�ļ���
        /// </summary>
        public string pk00803 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public byte[] pk00804 { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column(ColumnType = ColumnType.CreateDateTime)]
        public string pk00805 { get; set; }

        /// <summary>
        /// ����޸�ʱ��
        /// </summary>
        [Column(ColumnType = ColumnType.UpdateDateTime)]
        public string pk00806 { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        public string pk00807 { get; set; }

        /// <summary>
        /// �����޸���
        /// </summary>
        public string pk00808 { get; set; }

        /// <summary>
        /// ���ݷ���Ȩ��
        /// </summary>
        public string pk00809 { get; set; }

        /// <summary>
        /// ���λ��
        /// </summary>
        public FileType pk00810 { get; set; }

        /// <summary>
        /// �ĵ���
        /// </summary>
        public string pk00811 { get; set; }

        /// <summary>
        /// �汾��
        /// </summary>
        public string pk00812 { get; set; }

        /// <summary>
        /// �޸�ԭ��
        /// </summary>
        public string pk00813 { get; set; }

        /// <summary>
        /// �鵵λ��
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
