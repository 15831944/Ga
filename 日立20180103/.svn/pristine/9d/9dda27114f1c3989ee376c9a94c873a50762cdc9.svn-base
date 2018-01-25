using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;

namespace PM2.Service.Code030.szrl111Service
{
    public interface Iszrl112Server : IService, ICmDataService<szrl112>
    {
        /// <summary>
        /// 保存材料目录
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        IOperateResult SaveMaterialDir(szrl112 newItem);

        /// <summary>
        /// 获取材料目录信息
        /// </summary>
        /// <returns></returns>
        List<TreeNodeInfo> GetMaterialDirs(string key, bool allFlag);

        /// <summary>
        /// 删除材料目录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult RemoveMaterialDir(string id);
    }
}
