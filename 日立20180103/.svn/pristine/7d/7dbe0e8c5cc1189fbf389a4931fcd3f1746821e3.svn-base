using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM2.Code
{
    public abstract class ControlsAttribute : Attribute, IMetadataAware
    {
        /// <summary>
        /// 显示标签
        /// </summary>
        public string Lable { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        protected abstract string TemplateHint { get; }
        public virtual void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = this.TemplateHint;
            metadata.DisplayName = this.Lable;
        }
    }
}
