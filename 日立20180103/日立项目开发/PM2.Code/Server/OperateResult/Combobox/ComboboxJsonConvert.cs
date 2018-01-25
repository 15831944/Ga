using Gmail.DDD.Helper;
using Gmail.DDD.JsonConvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM2.Code
{
    [Serializable]
    public class ComboboxJsonConvert : JsonConvert, IEnumerable<ComboboxItem>
    {
        private List<ComboboxItem> _data;
        public ComboboxJsonConvert(List<ComboboxItem> data)
        {
            this._data = data;
        }

        public override string ToJsonString()
        {
            return SerializeMemoryHelper.SerializeToJson(this, base.DefaultSettings);
        }

        #region IEnumerable
        public IEnumerator<ComboboxItem> GetEnumerator()
        {
            return this._data.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
        
    }
}
