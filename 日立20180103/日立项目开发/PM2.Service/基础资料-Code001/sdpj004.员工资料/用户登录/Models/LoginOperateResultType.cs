using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code001
{
    public enum LoginOperateResultType
    {
        /// <summary>
        /// 登录异常
        /// </summary>
        [Description("登录异常")]
        Error,

        /// <summary>
        /// 登录成功
        /// </summary>
        [Description("登录成功")]
        Success,

        /// <summary>
        /// 用户名密码错误
        /// </summary>
        [Description("用户名密码错误")]
        ValidError
    }
}
