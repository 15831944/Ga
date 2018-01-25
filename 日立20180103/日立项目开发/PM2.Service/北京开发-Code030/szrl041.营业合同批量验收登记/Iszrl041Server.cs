using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030.szrl041Service
{
    public interface Iszrl041Server : IService, ICmDataService<szrl041>
    {
        /// <summary>
        /// ȡ����������ϸ��Ϣ
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        PagerResult Get_szrl042(PagerInfo info);


        /// <summary>
        /// ȡ����������Ϣ
        /// �Ȱ���������IDȡ����������������ȡ
        /// </summary>
        /// <param name="id">��������ID</param>
        /// <param name="zno">������</param>
        /// <returns></returns>
        szrl041 Get_szrl041(string id, string zno);
    }
}
