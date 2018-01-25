using Gmail.DDD.Entity;
using Gmail.DDD.Extensions;
using Newtonsoft.Json;
using PM2.Models.Code001;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code031
{
    /// <summary>
    /// [��֧��ȷ��]��֧ͬ�����
    /// </summary>
    [Table(Name = "szrl126")]
    public partial class szrl126 : Enttity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl12601 { get; set; }

        /// <summary>
        /// ����ID szrl125.rl12501
        /// </summary>
        public string rl12602 { get; set; }

        /// <summary>
        /// ��ʼ��Դ 0:��֧ͬ���ƻ�, 1:��ͬ���ռƻ�
        /// </summary>
        public int rl12603 { get; set; }

        /// <summary>
        /// ��ԴID  
        /// </summary>
        public string rl12604 { get; set; }

        /// <summary>
        /// ֧����
        /// </summary>
        public int rl12605 { get; set; }

        /// <summary>
        /// ֧������
        /// </summary>
        public string rl12606 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl12607 { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public decimal rl12608 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public string rl12609 { get; set; }

        /// <summary>
        /// ֧������
        /// </summary>
        public string rl12610 { get; set; }

        /// <summary>
        /// %
        /// </summary>
        public decimal rl12611 { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public decimal rl12612 { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        public string rl12613 { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int rl12614 { get; set; }

        /// <summary>
        /// Ԥ����ۿ���
        /// </summary>
        public decimal rl12615 { get; set; }

        /// <summary>
        /// Ԥ����ۿ�ռ��ͬ%
        /// </summary>
        public decimal rl12616 { get; set; }

        /// <summary>
        /// ����ʵ��֧�����(��˰)
        /// </summary>
        public decimal rl12617 { get; set; }

        /// <summary>
        /// ����ʵ��֧�����(����˰)
        /// </summary>
        public decimal rl12618 { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        public string rl12619 { get; set; }

        /// <summary>
        /// ������ sdpj004.pj00401
        /// </summary>
        public string rl12620 { get; set; }

        /// <summary>
        /// �Ƿ���ʽ����
        /// </summary>
        public int rl12621 { get; set; }

        /// <summary>
        /// �������
        /// </summary>
        public int rl12622 { get; set; }

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
