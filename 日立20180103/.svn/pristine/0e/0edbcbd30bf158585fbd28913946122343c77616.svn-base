using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.Mvc;
using Gmail.DDD.Service;
using PM2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.DDD.Service
{
    /// <summary>
    /// Tree
    /// </summary>
    public interface IEasyTree : IService
    {
        IOperateResult TreeLoad(IRequestGetter rGetter = null);

        /// <summary>
        /// 设置扩展
        /// </summary>
        /// <param name="treeExtensions"></param>
        void SetTreeExtensions(IEasyTreeExtensions extensions);

    }
}
