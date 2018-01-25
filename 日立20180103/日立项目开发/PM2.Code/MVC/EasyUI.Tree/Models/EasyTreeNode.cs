using Gmail.DDD.Utility;
using Gmail.DDD.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.JsonConvert;

namespace Gmail.DDD.Service
{
    public class EasyTreeNode : IEasyTreeNode
    {
        /// <summary>
        /// Node_ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        /// <summary>
        /// Node_信息
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Node_上级ID
        /// </summary>
        [JsonIgnore]
        public string ParentId { get; set; }
        
        /// <summary>
        /// Node_排序
        /// </summary>
        [JsonIgnore]
        public string OrderBy { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        [JsonProperty(PropertyName = "qtip")]
        public string Qtip { get; set; }

        /// <summary>
        /// Node_图标
        /// </summary>
        [JsonProperty(PropertyName = "iconCls")]
        public string IconCls { get; set; }

        /// <summary>
        /// Node_复选框
        /// </summary>
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }

        /// <summary>
        /// Node_附加信息
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public object Params { get; set; }

        private bool _state = false;
        /// <summary>
        /// Node_下面的[子节点是否全部展开]
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        [JsonConverter(typeof(BoolJsonConverter), "open,closed")]
        public bool Expanded { 
            get {
                if (this.ChildNodes.IsNullOrEmpty())
                    return true;
                else
                    return this._state; 
            } 
            set { this._state = value; } }

        /// <summary>
        /// 由分发自动设置
        /// </summary>
        [JsonProperty(PropertyName = "children", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<ITreeModel> ChildNodes { get; set; }

        public EasyTreeNode()
        {
        }
    }

}
