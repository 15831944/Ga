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
using PM2.Models.Code030.szrl111Model;
using System.Web.Mvc;
using System.IO;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030.szrl111Service
{
    public interface Iszrl111Server : IService, ICmDataService<szrl111>
    {
        /// <summary>
        /// 保存材料信息
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        IOperateResult SaveMaterial(szrl111 newItem, string attachFileId);


        /// <summary>
        /// 删除材料
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult RemoveMaterial(szrl111 item);

        /// <summary>
        /// 修改材料的材料目录
        /// </summary>
        /// <param name="id">材料ID</param>
        /// <param name="dirId">材料目录ID</param>
        /// <returns></returns>
        IOperateResult ChangeMaterialDir(string id, string dirId);

        /// <summary>
        /// 取全部计量单位
        /// </summary>
        /// <returns></returns>
        IEnumerable<sdpa013> GetMeasureUnits();

        /// <summary>
        /// EXCEL导入数据
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        IOperateResult ImportDataByExcel(MaterialExcel excel);

        /// <summary>
        /// 查询材料
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<VMaterialObj> Search_szrl111(PagerInfo info, string key, string dirId);

        PagerResult SearchForPager_szrl111(PagerInfo info, string key, string dirId);

        /// <summary>
        /// 取材料编码
        /// </summary>
        /// <param name="materialDirId"></param>
        /// <returns></returns>
        string CreateMaterialCode(string materialDirId);

        /// <summary>
        /// 取材料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        VMaterialObj Get_szrl111(string id);


        MemoryStream ExportExcel_szrl111(string key, string dirId, int pageNum, int pageSize);
    }
}
