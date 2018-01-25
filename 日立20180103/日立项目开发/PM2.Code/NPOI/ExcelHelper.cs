using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Extensions;
using Gmail.DDD.Entity;

namespace PM2.Code.NPOI
{
    public class ExcelHelper
    {
        #region 获取模型下标注特性
        /// <summary>
        /// 获取模型下标注特性
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="_eContext"></param>
        /// <returns></returns>
        public static IEnumerable<ExcelAttribute> GetAttributes(Type modelType)
        {
            //获取模型[表头集合]特性
            return from x in EntityMetadataProviders.Instance.GetMetadataForType(modelType, null).Properties
                        from y in x.GetAttributes<ExcelAttribute>()
                        select y; 
        }
        #endregion
    }
}
