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
        /// �������Ŀ¼
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        IOperateResult SaveMaterialDir(szrl112 newItem);

        /// <summary>
        /// ��ȡ����Ŀ¼��Ϣ
        /// </summary>
        /// <returns></returns>
        List<TreeNodeInfo> GetMaterialDirs(string key, bool allFlag);

        /// <summary>
        /// ɾ������Ŀ¼
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult RemoveMaterialDir(string id);
    }
}
