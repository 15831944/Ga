using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030
{
    public class szrl111CBN
    {
        /// <summary>
        /// 一级目录
        /// </summary>
        public string cbn_01 { get; set; }
        /// <summary>
        /// 二级目录
        /// </summary>
        public string cbn_02 { get; set; }
        /// <summary>
        /// 材料编码
        /// </summary>
        public string cbn_03 { get; set; }
        /// <summary>
        /// 件品名及摘要
        /// </summary>
        public string cbn_04 { get; set; }
        /// <summary>
        /// 报价名称
        /// </summary>
        public string cbn_05 { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string cbn_06 { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string cbn_07 { get; set; }
        /// <summary>
        /// 税込金額——単価(税込）
        /// </summary>
        public string cbn_08 { get; set; }
        /// <summary>
        /// 税込金額——小計（税込）
        /// </summary>
        public string cbn_09 { get; set; }
        /// <summary>
        /// 税込金額——計（税込）
        /// </summary>
        public string cbn_10 { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public string cbn_11 { get; set; }
        /// <summary>
        /// 税抜金額——単価(税抜）
        /// </summary>
        public string cbn_12 { get; set; }
        /// <summary>
        /// 税抜金額——小計（税抜）
        /// </summary>
        public string cbn_13 { get; set; }
        /// <summary>
        /// 税抜金額——計（税抜）
        /// </summary>
        public string cbn_14 { get; set; }
        /// <summary>
        /// 本页総合計
        /// </summary>
        public string cbn_15 { get; set; }
    }
}
