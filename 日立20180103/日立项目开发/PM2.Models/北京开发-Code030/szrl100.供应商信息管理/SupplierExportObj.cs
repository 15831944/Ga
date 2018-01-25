using PM2.Models.Code030.szrl111Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Models.Code030.szrl100Model
{
    [ExcelCol(Name = "供应商信息")]
    public class SupplierExportObj
    {
        [ExcelCol(Index = 0, Name = "企业编码")]
        public string rl10002 { get; set; }

        [ExcelCol(Index = 1, Name = "G&G代码")]
        public string rl10041 { get; set; }

        [ExcelCol(Index = 2, Name = "企业名")]
        public string rl10003 { get; set; }

        [ExcelCol(Index = 3, Name = "曾用名")]
        public string rl10005 { get; set; }

        [ExcelCol(Index = 4, Name = "企业类型")]
        public string rl10006 { get; set; }

        [ExcelCol(Index = 5, Name = "种别分类")]
        public string rl10007 { get; set; }


        [ExcelCol(Index = 6, Name = "产品类型")]
        public string rl10008 { get; set; }

        [ExcelCol(Index = 7, Name = "联系地址")]
        public string rl10009 { get; set; }

        [ExcelCol(Index = 8, Name = "联系人")]
        public string ContactPerson1 { get; set; }

        [ExcelCol(Index = 9, Name = "联系电话")]
        public string ContactPhone1 { get; set; }

        [ExcelCol(Index = 10, Name = "电子邮箱")]
        public string Email1 { get; set; }

        [ExcelCol(Index = 11, Name = "建筑业企业资质")]
        public string rl10015 { get; set; }

        [ExcelCol(Index = 12, Name = "安全生产许可证")]
        public string rl10016 { get; set; }

        [ExcelCol(Index = 13, Name = "安全生产许可证有效期")]
        public string rl10017 { get; set; }

        [ExcelCol(Index = 14, Name = "特别资质")]
        public string rl10018 { get; set; }

        [ExcelCol(Index = 15, Name = "质量认证")]
        public string rl10019 { get; set; }

        [ExcelCol(Index = 16, Name = "质量认证有效期")]
        public string rl10020 { get; set; }

        [ExcelCol(Index = 17, Name = "可否采用")]
        public string rl10026 { get; set; }

        [ExcelCol(Index = 18, Name = "黑名单")]
        public string rl10027 { get; set; }
    }
}
