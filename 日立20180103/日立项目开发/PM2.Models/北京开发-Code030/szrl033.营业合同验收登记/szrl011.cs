using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code030
{
    //szrl011
    public class szrl011 : Enttity
    {

        /// <summary>
        /// 项目ID
        /// </summary> 
        [EasyTextbox]
        public string rl01101 { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary> 
        [EasyTextbox]
        public string rl01102 { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary> 
        [EasyTextbox]
        public string rl01103 { get; set; }
        /// <summary>
        /// 项目地址
        /// </summary> 
        [EasyTextbox]
        public string rl01104 { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary> 
        [EasyTextbox]
        public string rl01105 { get; set; }
        /// <summary>
        /// 项目保固期
        /// </summary> 
        [EasyTextbox]
        public string rl01106 { get; set; }
        /// <summary>
        /// 预计规模
        /// </summary> 
        [EasyTextbox]
        public decimal rl01107 { get; set; }
        /// <summary>
        /// 项目信息来源
        /// </summary> 
        [EasyTextbox]
        public string rl01108 { get; set; }
        /// <summary>
        /// 项目阶段
        /// </summary> 
        [EasyTextbox]
        public byte rl01109 { get; set; }
        /// <summary>
        /// 是否发行
        /// </summary> 
        [EasyTextbox]
        public byte rl01110 { get; set; }
        /// <summary>
        /// 使用的资质
        /// </summary> 
        [EasyTextbox]
        public string rl01111 { get; set; }
        /// <summary>
        /// 设计
        /// </summary> 
        [EasyTextbox]
        public byte rl01112 { get; set; }
        /// <summary>
        /// 施工
        /// </summary> 
        [EasyTextbox]
        public byte rl01113 { get; set; }
        /// <summary>
        /// 采购
        /// </summary> 
        [EasyTextbox]
        public byte rl01114 { get; set; }
        /// <summary>
        /// 管理/咨询
        /// </summary> 
        [EasyTextbox]
        public byte rl01115 { get; set; }
        /// <summary>
        /// 作番号
        /// </summary> 
        [EasyTextbox]
        public string rl01116 { get; set; }
        /// <summary>
        /// 受注合计金额
        /// </summary> 
        [EasyTextbox]
        public decimal rl01117 { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary> 
        [EasyTextbox]
        public string rl01118 { get; set; }
        /// <summary>
        /// 计划完工日期
        /// </summary> 
        [EasyTextbox]
        public string rl01119 { get; set; }
        /// <summary>
        /// 建筑
        /// </summary> 
        [EasyTextbox]
        public byte rl01120 { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary> 
        [EasyTextbox]
        public decimal rl01121 { get; set; }
        /// <summary>
        /// 内装
        /// </summary> 
        [EasyTextbox]
        public byte rl01122 { get; set; }
        /// <summary>
        /// 内装面积
        /// </summary> 
        [EasyTextbox]
        public decimal rl01123 { get; set; }
        /// <summary>
        /// 洁净室
        /// </summary> 
        [EasyTextbox]
        public byte rl01124 { get; set; }
        /// <summary>
        /// 洁净室面积
        /// </summary> 
        [EasyTextbox]
        public decimal rl01125 { get; set; }
        /// <summary>
        /// 洁净度
        /// </summary> 
        [EasyTextbox]
        public string rl01126 { get; set; }
        /// <summary>
        /// 机械
        /// </summary> 
        [EasyTextbox]
        public byte rl01127 { get; set; }
        /// <summary>
        /// 电气
        /// </summary> 
        [EasyTextbox]
        public byte rl01128 { get; set; }
        /// <summary>
        /// 动力
        /// </summary> 
        [EasyTextbox]
        public byte rl01129 { get; set; }
        /// <summary>
        /// 生产设备
        /// </summary> 
        [EasyTextbox]
        public byte rl01130 { get; set; }
        /// <summary>
        /// 环保
        /// </summary> 
        [EasyTextbox]
        public byte rl01131 { get; set; }
        /// <summary>
        /// 环保说明
        /// </summary> 
        [EasyTextbox]
        public string rl01132 { get; set; }
        /// <summary>
        /// 施工许可证
        /// </summary> 
        [EasyTextbox]
        public byte rl01133 { get; set; }
        /// <summary>
        /// 业主办理
        /// </summary> 
        [EasyTextbox]
        public byte rl01134 { get; set; }
        /// <summary>
        /// SHPC代理
        /// </summary> 
        [EasyTextbox]
        public byte rl01135 { get; set; }
        /// <summary>
        /// 项目说明
        /// </summary> 
        [EasyTextbox]
        public string rl01136 { get; set; }
        /// <summary>
        /// 战略
        /// </summary> 
        [EasyTextbox]
        public string rl01137 { get; set; }
        /// <summary>
        /// 营业
        /// </summary> 
        [EasyTextbox]
        public string rl01138 { get; set; }
        /// <summary>
        /// 设计
        /// </summary> 
        [EasyTextbox]
        public string rl01139 { get; set; }
        /// <summary>
        /// 项目负责人
        /// </summary> 
        [EasyTextbox]
        public string rl01140 { get; set; }
        /// <summary>
        /// 顾客项目负责人
        /// </summary> 
        [EasyTextbox]
        public string rl01141 { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary> 
        [EasyTextbox]
        public string rl01142 { get; set; }
        /// <summary>
        /// 防火等级
        /// </summary> 
        [EasyTextbox]
        public string rl01143 { get; set; }
        /// <summary>
        /// 防爆等级
        /// </summary> 
        [EasyTextbox]
        public string rl01144 { get; set; }
        /// <summary>
        /// 危险品仓库
        /// </summary> 
        [EasyTextbox]
        public byte rl01145 { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary> 
        [EasyTextbox]
        public decimal rl01146 { get; set; }
        /// <summary>
        /// 制单人
        /// </summary> 
        [EasyTextbox]
        public string rl01147 { get; set; }
        /// <summary>
        /// 制单日期
        /// </summary> 
        [EasyTextbox]
        public string rl01148 { get; set; }
        /// <summary>
        /// 审核人
        /// </summary> 
        [EasyTextbox]
        public string rl01149 { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary> 
        [EasyTextbox]
        public string rl01150 { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary> 
        [EasyTextbox]
        public int rl01151 { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary> 
        [EasyTextbox]
        public string rl01152 { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary> 
        [EasyTextbox]
        public string rl01153 { get; set; }
        /// <summary>
        /// 预留字段1
        /// </summary> 
        [EasyTextbox]
        public string rl01154 { get; set; }
        /// <summary>
        /// 预留字段2
        /// </summary> 
        [EasyTextbox]
        public string rl01155 { get; set; }
        /// <summary>
        /// 预留字段3
        /// </summary> 
        [EasyTextbox]
        public string rl01156 { get; set; }
        /// <summary>
        /// 预留字段4
        /// </summary> 
        [EasyTextbox]
        public byte rl01157 { get; set; }
        /// <summary>
        /// 预留字段5
        /// </summary> 
        [EasyTextbox]
        public byte rl01158 { get; set; }
        /// <summary>
        /// 预留字段6
        /// </summary> 
        [EasyTextbox]
        public byte rl01159 { get; set; }
        /// <summary>
        /// 预留7
        /// </summary> 
        [EasyTextbox]
        public decimal rl01160 { get; set; }
        /// <summary>
        /// 预留8
        /// </summary> 
        [EasyTextbox]
        public decimal rl01161 { get; set; }

    }
}

