using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;
using PM2.Models.Code030.szrl033Model;
using PM2.Models.Code030;
using System.IO;

namespace PM2.Service.Code030.szrl033Service
{
    public interface Iszrl033Server : IService, ICmDataService<szrl033>
    {
        /// <summary>
        /// 保存营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult Save_szrl033(szrl033 item);

        /// <summary>
        /// 保存营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult Save_szrl033(List<VAcceptancePlanObj> itemList, szrl033 szrl033Item);

        /// <summary>
        /// 删除营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult Delete_szrl033(szrl033 item);

        /// <summary>
        /// 查询营业合同登记
        /// </summary>
        /// <returns></returns>
        IEnumerable<szrl033> Search_szrl033(string key);

        /// <summary>
        /// 分页查询营业合同登记
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        PagerResult SearchPager_szrl033(string key, PagerInfo pager);

        /// <summary>
        /// 获取某个ID的营业合同登记的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        szrl033 Get_szrl033(string id);


        /// <summary>
        /// 获取营业合同目录信息
        /// </summary>
        /// <returns></returns>
        List<TreeNodeInfo> GetContractDirs(string key, string multi);

        /// <summary>
        /// 获取营业合同目录信息
        /// </summary>
        /// <returns></returns>
        List<TreeNodeInfo> GetContractDirs2(string id, string key, string multi);

        /// <summary>
        /// 取验收计划明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<VAcceptancePlanObj> Get_szrl024(string id);

        /// <summary>
        /// 取附件数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int GetAttachFileCount_szrl033(string key);


        /// <summary>
        /// 取验收计划对应的正式版合同的信息
        /// </summary>
        /// <returns></returns>
        string GetContractInfo_szrl033(string contractId);


        /// <summary>
        /// 承认
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        IOperateResult Admit_szrl034(List<VAcceptancePlanObj> objs);


        /// <summary>
        /// 取未验收状态的验收计划明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PagerResult Get_index_szrl024(PagerInfo info, string key, string id);


        /// <summary>
        /// 取未验收状态的验收计划明细对应的合同分类信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<VAcceptancePlanObj> GetContractType_index_szrl024(string key);


        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dirId"></param>
        MemoryStream ExportExcel_szrl033(string key, string id, int pageNum, int pageSize);
    }
}
