using Gmail.DDD.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PM2.Models.Code001
{
    [Table(Name = "sdpj004")]
    public partial class sdpj004 : Enttity
    {
        /// <summary>
        /// 员工ID号
        /// </summary>
        [Column(ColumnType = ColumnType.PrimaryKey)]
        public string pj00401 { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        [Column(Index = 2)]
        public string pj00402 { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column(Index = 3)]
        public byte pj00403 { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        [Column(Index = 4)]
        public string pj00404 { get; set; }
        /// <summary>
        /// 家庭电话1
        /// </summary>
        [Column(Index = 5)]
        public string pj00405 { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(Index = 6)]
        public string pj00406 { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        [Column(Index = 7)]
        public string pj00407 { get; set; }
        /// <summary>
        /// 毕业学校
        /// </summary>
        [Column(Index = 8)]
        public string pj00408 { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        [Column(Index = 9)]
        public string pj00409 { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [Column(Index = 10)]
        public string pj00410 { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        [Column(Index = 11)]
        public string pj00411 { get; set; }
        /// <summary>
        /// 员工状态
        /// </summary>
        [Column(Index = 12)]
        public byte pj00412 { get; set; }
        /// <summary>
        /// 离职日期
        /// </summary>
        [Column(Index = 13)]
        public string pj00413 { get; set; }
        /// <summary>
        /// 离职原因
        /// </summary>
        [Column(Index = 14)]
        public string pj00414 { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Column(Index = 15)]
        public string pj00415 { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Column(Index = 16)]
        public string pj00416 { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        [Column(Index = 17)]
        public string pj00417 { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        [Column(Index = 18)]
        public decimal pj00418 { get; set; }
        /// <summary>
        /// 业务属性
        ///     0-无定义，1-销售人员，2-销售主管，3-采购人员，4-采购主管，5-销售和采购人员，6-销售和采购主管。
        /// </summary>
        [Column(Index = 19)]
        public byte pj00419 { get; set; }
        /// <summary>
        /// 移动电话
        /// </summary>
        [Column(Index = 20)]
        public string pj00420 { get; set; }
        /// <summary>
        /// 员工编码
        /// </summary>
        [Column(Index = 21)]    
        public string pj00421 { get; set; }
        /// <summary>
        /// 代理人(OA审批代理人)
        /// </summary>
        [Column(Index = 22)]
        public string pj00422 { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Column(Index = 23)]
        public string pj00423 { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>
        [Column(Index = 24)]
        public string pj00424 { get; set; }
        /// <summary>
        /// 合同到期日期
        /// </summary>
        [Column(Index = 25)]
        public string pj00425 { get; set; }
        /// <summary>
        /// 是否有档案
        /// </summary>
        [Column(Index = 26)]
        public byte pj00426 { get; set; }
        /// <summary>
        /// 档案编号
        /// </summary>
        [Column(Index = 27)]
        public string pj00427 { get; set; }
        /// <summary>
        /// 是否挂户口
        /// </summary>
        [Column(Index = 28)]
        public byte pj00428 { get; set; }
        /// <summary>
        /// 是否有养老保险
        /// </summary>
        [Column(Index = 29)]
        public byte pj00429 { get; set; }
        /// <summary>
        /// 养老保险时间
        /// </summary>
        [Column(Index = 30)]
        public string pj00430 { get; set; }
        /// <summary>
        /// 是否有住房公积金
        /// </summary>
        [Column(Index = 31)]
        public byte pj00431 { get; set; }
        /// <summary>
        /// 公积金起缴时间
        /// </summary>
        [Column(Index = 32)]
        public string pj00432 { get; set; }
        /// <summary>
        /// 公积金帐号
        /// </summary>
        [Column(Index = 33)]
        public string pj00433 { get; set; }
        /// <summary>
        /// 职称
        /// </summary>
        [Column(Index = 34)]
        public string pj00434 { get; set; }
        /// <summary>
        /// 居住住址
        /// </summary>
        [Column(Index = 35)]
        public string pj00435 { get; set; }
        /// <summary>
        /// 毕业时间
        /// </summary>
        [Column(Index = 36)]
        public string pj00436 { get; set; }
        /// <summary>
        /// 人员类别
        /// </summary>
        [Column(Index = 37)]
        public string pj00437 { get; set; }
        /// <summary>
        /// 政治面貌
        /// </summary>
        [Column(Index = 38)]
        public string pj00438 { get; set; }
        /// <summary>
        /// 岗位等级
        /// </summary>
        [Column(Index = 39)]
        public string pj00439 { get; set; }
        /// <summary>
        /// 是否有小孩
        /// </summary>
        [Column(Index = 40)]
        public byte pj00440 { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Column(Index = 41)]
        public string pj00441 { get; set; }
        /// <summary>
        /// 家庭电话2
        /// </summary>
        [Column(Index = 42)]
        public string pj00442 { get; set; }
        /// <summary>
        /// 养老保险号码
        /// </summary>
        [Column(Index = 43)]
        public string pj00443 { get; set; }
        /// <summary>
        /// 综合保险号码
        /// </summary>
        [Column(Index = 44)]
        public string pj00444 { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        [Column(Index = 45)]
        public string pj00445 { get; set; }
        /// <summary>
        /// 工资银行卡号
        /// </summary>
        [Column(Index = 46)]
        public string pj00446 { get; set; }
        /// <summary>
        /// 是否转正
        /// </summary>
        [Column(Index = 47)]
        public byte pj00447 { get; set; }
        /// <summary>
        /// 是否资源管理
        /// </summary>
        [Column(Index = 48)]
        public byte pj00448 { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        [Column(Index = 49)]
        public string pj00449 { get; set; }
        /// <summary>
        /// 婚姻
        /// </summary>
        [Column(Index = 50)]
        public string pj00450 { get; set; }

        [JsonIgnore]
        public virtual sdpj003 sdpj003 { get; set; }

        [JsonIgnore]
        public virtual sdey003 sdey003 { get; set; }

    }
}
