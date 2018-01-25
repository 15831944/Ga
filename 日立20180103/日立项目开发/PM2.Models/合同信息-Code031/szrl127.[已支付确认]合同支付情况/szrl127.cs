using Gmail.DDD.Entity;
using Newtonsoft.Json;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code031
{
    /// <summary>
    /// ��֧ͬ�����[��֧��ȷ��]
    /// </summary>
    [Table(Name = "szrl127")]
    public partial class szrl127 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
         [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl12701 { get; set; }

        /// <summary>
        /// ����ID szrl125.rl12501
        /// </summary>
        public string rl12702 { get; set; }

        /// <summary>
        /// ��ʼ��Դ
        /// </summary>
        public int rl12703 { get; set; }

        /// <summary>
        /// ��ԴID  
        /// </summary>
        public string rl12704 { get; set; }

        /// <summary>
        /// ֧������
        /// </summary>
        public string rl12705 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl12706 { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public decimal rl12707 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string rl12708 { get; set; }

        /// <summary>
        /// ֧������
        /// </summary>
        public string rl12709 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl12710 { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public decimal rl12711 { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public string rl12712 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int rl12713 { get; set; }

        /// <summary>
        /// Ԥ����ۿ���
        /// </summary>
        public decimal rl12714 { get; set; }

        /// <summary>
        /// Ԥ����ۿ�ռ��ͬ%
        /// </summary>
        public decimal rl12715 { get; set; }

        /// <summary>
        /// ����ʵ��֧�����(��˰)
        /// </summary>
        public decimal rl12716 { get; set; }

        /// <summary>
        /// ����ʵ��֧�����(����˰)
        /// </summary>
        public decimal rl12717 { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string rl12718 { get; set; }

        /// <summary>
        /// ״̬ 0: ���ϼ�, 1: AP�ѷ���
        /// </summary>
        public int rl12719 { get; set; }

        /// <summary>
        /// AP���
        /// </summary>
        public string rl12720 { get; set; }

        /// <summary>
        /// ������ sdpj004.pj00401
        /// </summary>
        public string rl12721 { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int rl12722 { get; set; }

        /// <summary>
        /// ��֧ͬ�����
        /// </summary>
        [JsonIgnore]
        public virtual szrl125 szrl125 { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [JsonIgnore]
        public virtual sdpj004 sdpj004 { get; set; }

    }
}
