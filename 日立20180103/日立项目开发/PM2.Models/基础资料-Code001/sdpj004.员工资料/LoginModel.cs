using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Gmail.DDD.Config;
using Newtonsoft.Json;
using PM2.Code;
using Gmail.DDD.Entity;

namespace PM2.Models.Code001
{
    public enum LoginType
    {
        [Description("网站登录")]
        Web,
        [Description("手机登录")]
        App
    }

    [Serializable]
    public class LoginModel : IEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [EasyTextbox]
        public string LoginCode { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [EasyPasswordbox]
        public string PassWord { get; set; }

        /// <summary>
        /// 记住我7天免登录
        /// </summary>
        [EasySwitchbutton]
        public bool RememBerMe { get; set; }

        /// <summary>
        /// 登录账套
        /// </summary>
        private string _account = null;

        [EasyCombobox("/AreasCode001/sdey001/GetList")]
        public string Account {
            get { return this._account ?? PM2Config.Instance.DataConfig.EFConfig.DefaultAccid; }
            set { this._account = value; } 
        }

        /// <summary>
        /// SSO分站回调Url
        /// </summary>
        [JsonIgnore]
        public string BackUrl { get; set; }

        /// <summary>
        /// 登录类型
        /// </summary>
        [JsonIgnore]
        [EasyCombobox]
        public LoginType LoginType { get; set; }

    }
}
