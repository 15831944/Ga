using Gmail.DDD.AOP;
using Gmail.DDD.IOC;
using Gmail.DDD.JsonConvert;
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
    public abstract class EasyTreeBaseAsync : IEasyTreeAsync
    {
        protected IEasyTreeExtensions TreeExtensions
        {
            get { return this._extensions; }
        }
        #region 扩展设置
        private IEasyTreeExtensions _extensions;

        public void SetExtensions(IEasyTreeExtensions treeExtensions)
        {
            this._extensions = treeExtensions;
        }
        #endregion
        public abstract Task<IOperateResult> TreeLoadAsync(IRequestGetter rGetter = null);


    }
}
