using Gmail.DDD.Entity;
using PM2.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030
{
    public partial class szrl019 : Enttity
    {
        #region Model
        /// <summary>
        /// 版本ID
        /// </summary>        
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string rl01901 { get; set; }
        /// <summary>
        /// 营业合同ID
        /// </summary>        
        [EasyTextbox]
        public string rl01902 { get; set; }
        /// <summary>
        /// 合同名称
        /// </summary>        
        [EasyTextbox]
        public string rl01903 { get; set; }
        /// <summary>
        /// 合同序列号 自动生成,S+年末后两位+4位流水号
        /// </summary>        
        [EasyTextbox]
        public string rl01904 { get; set; }
        /// <summary>
        /// 顾客名称
        /// </summary>        
        [EasyTextbox]
        public string rl01905 { get; set; }
        /// <summary>
        /// 作番
        /// </summary>        
        [EasyTextbox]
        public string rl01906 { get; set; }
        /// <summary>
        /// 合同初始金额(不含税)
        /// </summary>        
        [EasyTextbox]
        public decimal rl01907 { get; set; }
        /// <summary>
        /// 税率
        /// </summary>        
        [EasyTextbox]
        public decimal rl01908 { get; set; }
        /// <summary>
        /// 合同初始金额(含税)
        /// </summary>        
        [EasyTextbox]
        public decimal rl01909 { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>        
        [EasyTextbox]
        public string rl01910 { get; set; }
        /// <summary>
        /// 合同书编号
        /// </summary>        
        [EasyTextbox]
        public string rl01911 { get; set; }
        /// <summary>
        /// 合同书版本
        /// </summary>        
        [EasyTextbox]
        public string rl01912 { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary>        
        [EasyTextbox]
        public string rl01913 { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary>        
        [EasyTextbox]
        public string rl01914 { get; set; }
        /// <summary>
        /// 实际开始日期
        /// </summary>        
        [EasyTextbox]
        public string rl01915 { get; set; }
        /// <summary>
        /// 实际完工日期
        /// </summary>        
        [EasyTextbox]
        public string rl01916 { get; set; }
        /// <summary>
        /// 契約書入手日
        /// </summary>        
        [EasyTextbox]
        public string rl01917 { get; set; }
        /// <summary>
        /// 工程担当
        /// </summary>        
        [EasyTextbox]
        public string rl01918 { get; set; }
        /// <summary>
        /// 支付条件
        /// </summary>        
        [EasyTextbox]
        public string rl01919 { get; set; }
        /// <summary>
        /// 建筑
        /// </summary>        
        [EasyTextbox]
        public byte rl01920 { get; set; }
        /// <summary>
        /// 建筑金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01921 { get; set; }
        /// <summary>
        /// 建筑占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01922 { get; set; }
        /// <summary>
        /// 机械
        /// </summary>        
        [EasyTextbox]
        public byte rl01923 { get; set; }
        /// <summary>
        /// 机械费用
        /// </summary>        
        [EasyTextbox]
        public decimal rl01924 { get; set; }
        /// <summary>
        /// 机械占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01925 { get; set; }
        /// <summary>
        /// 电气
        /// </summary>        
        [EasyTextbox]
        public byte rl01926 { get; set; }
        /// <summary>
        /// 电气金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01927 { get; set; }
        /// <summary>
        /// 电气占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01928 { get; set; }
        /// <summary>
        /// 成套
        /// </summary>        
        [EasyTextbox]
        public byte rl01929 { get; set; }
        /// <summary>
        /// 成套金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01930 { get; set; }
        /// <summary>
        /// 成套占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01931 { get; set; }
        /// <summary>
        /// 专业一
        /// </summary>        
        [EasyTextbox]
        public byte rl01932 { get; set; }
        /// <summary>
        /// 专业一金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01933 { get; set; }
        /// <summary>
        /// 专业一占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01934 { get; set; }
        /// <summary>
        /// 专业二
        /// </summary>        
        [EasyTextbox]
        public byte rl01935 { get; set; }
        /// <summary>
        /// 专业二金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01936 { get; set; }
        /// <summary>
        /// 专业二占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01937 { get; set; }
        /// <summary>
        /// 专业三
        /// </summary>        
        [EasyTextbox]
        public byte rl01938 { get; set; }
        /// <summary>
        /// 专业三金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01939 { get; set; }
        /// <summary>
        /// 专业三占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01940 { get; set; }
        /// <summary>
        /// 专业四
        /// </summary>        
        [EasyTextbox]
        public byte rl01941 { get; set; }
        /// <summary>
        /// 专业四金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01942 { get; set; }
        /// <summary>
        /// 专业四占比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01943 { get; set; }
        /// <summary>
        /// 物价变动允许范围
        /// </summary>        
        [EasyTextbox]
        public decimal rl01944 { get; set; }
        /// <summary>
        /// 工期延误赔偿金
        /// </summary>        
        [EasyTextbox]
        public byte rl01945 { get; set; }
        /// <summary>
        /// 损失赔偿
        /// </summary>        
        [EasyTextbox]
        public byte rl01946 { get; set; }
        /// <summary>
        /// 受注发行状况
        /// </summary>        
        [EasyTextbox]
        public byte rl01947 { get; set; }
        /// <summary>
        /// 作番精算月
        /// </summary>        
        [EasyTextbox]
        public string rl01948 { get; set; }
        /// <summary>
        /// 工程完工证明取得日
        /// </summary>        
        [EasyTextbox]
        public string rl01949 { get; set; }
        /// <summary>
        /// 累计变更金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01950 { get; set; }
        /// <summary>
        /// 变更后金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01951 { get; set; }
        /// <summary>
        /// 累计实际收款金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01952 { get; set; }
        /// <summary>
        /// 累计开具发票金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01953 { get; set; }
        /// <summary>
        /// 质保期限
        /// </summary>        
        [EasyTextbox]
        public string rl01954 { get; set; }
        /// <summary>
        /// 质保金百分比
        /// </summary>        
        [EasyTextbox]
        public decimal rl01955 { get; set; }
        /// <summary>
        /// 质保金额
        /// </summary>        
        [EasyTextbox]
        public decimal rl01956 { get; set; }
        /// <summary>
        /// 银行质保函
        /// </summary>        
        [EasyTextbox]
        public byte rl01957 { get; set; }
        /// <summary>
        /// 保函有效期截止日
        /// </summary>        
        [EasyTextbox]
        public string rl01958 { get; set; }
        /// <summary>
        /// 保函收回日期
        /// </summary>        
        [EasyTextbox]
        public string rl01959 { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>        
        [EasyTextbox]
        public int rl01960 { get; set; }
        /// <summary>
        /// 调整序列
        /// </summary>        
        [EasyTextbox]
        public string rl01961 { get; set; }
        /// <summary>
        /// 调整时间
        /// </summary>        
        [EasyTextbox]
        public string rl01962 { get; set; }
        /// <summary>
        /// 更新原因
        /// </summary>        
        [EasyTextbox]
        public string rl01963 { get; set; }
        /// <summary>
        /// 是否正式版
        /// </summary>        
        [EasyTextbox]
        public byte rl01964 { get; set; }
        /// <summary>
        /// 预留6
        /// </summary>        
        [EasyTextbox]
        public byte rl01965 { get; set; }
        /// <summary>
        /// 预留7
        /// </summary>        
        [EasyTextbox]
        public decimal rl01966 { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>        
        [EasyTextbox]
        public string rl01967 { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary>        
        [EasyTextbox]
        public string rl01968 { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>        
        [EasyTextbox]
        public string rl01969 { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>        
        [EasyTextbox]
        public string rl01970 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>        
        [EasyTextbox]
        public int rl01971 { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>        
        [EasyTextbox]
        public string rl01972 { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>        
        [EasyTextbox]
        public string rl01973 { get; set; }
        #endregion
    }
}
