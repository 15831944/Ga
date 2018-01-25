using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl033Model;
using System.IO;

namespace PM2.Service.Code030
{
    public interface Iszrl100Server : IService
    {
        #region 分类A
        /// <summary>
        /// 保存供应商
        /// </summary>
        /// <returns></returns>
        IOperateResult SaveSupplier(szrl100 item, string buildingIncCert, string signedName, string remarkList);

        /// <summary>
        /// 审核（承认）供应商的新版本信息
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        IOperateResult AdmitSupplierVersion(string supplierId, string supplierCode, bool rl10026);

        /// <summary>
        /// 保存供应商信息的新版本
        /// </summary>
        /// <param name="item">旧版本供应商信息</param>
        /// <returns></returns>
        IOperateResult SaveNewVersionSupplier(szrl100 item);
        #endregion
        #region MyRegion
        /// <summary>
        /// 保存供应商信息的临时新版本
        /// 临时版本
        /// </summary>
        /// <param name="item">旧版本供应商信息</param>
        /// <returns></returns>
        IOperateResult SaveTempNewVersionSupplier(szrl100 item);


        /// <summary>
        /// 取供应商代码对应的供应商的所有版本
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        IEnumerable<szrl100_SupplierVersion> GetSupplierVersions(string supplierCode);


        /// <summary>
        /// 取合同签订授权代表姓名信息列表
        /// </summary>
        /// <param name="glyCode"></param>
        /// <returns></returns>
        List<SignedNameObj> GetSignedNameList(string supplierId);


        /// <summary>
        /// 添加合同签订授权代表姓名
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult AddSignedName(szrl101 item);
        #endregion
        #region MyRegion
        /// <summary>
        /// 删除合同签订授权代表姓名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IOperateResult DeleteSignedName(string id);

        /// <summary>
        /// 查询供应商信息列表
        /// </summary>
        /// <returns></returns>
        PagerResult SearchSupplierList(string key, string black, PagerInfo info);

        MemoryStream ExportExcel_szrl100(string key, string black, PagerInfo info);


        /// <summary>
        /// 取建筑企业资质清单列表
        /// </summary>
        /// <returns></returns>
        List<BuildingIncCertObj> SearchBuildingIncCertList(string supplierId);

        /// <summary>
        /// 添加建筑企业资质
        /// </summary>
        /// <param name="item"></param>
        IOperateResult AddBuildingIncCert(szrl103 item);


        /// <summary>
        /// 删除建筑企业资质
        /// </summary>
        /// <param name="id"></param>
        IOperateResult DeleteBuildingIncCert(string id);


        /// <summary>
        /// 取对应供应商的备注列表
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        List<szrl100_RemarkObj> SearchRemarkList(string supplierId);

        /// <summary>
        /// 添加备注
        /// </summary>
        /// <param name="item"></param>
        IOperateResult AddRemark(szrl102 item);

        /// <summary>
        /// 删除备注
        /// </summary>
        /// <param name="id"></param>
        IOperateResult DeleteRemark(string id);


        /// <summary>
        /// 根据供应商编码取对应供应商信息
        /// </summary>
        /// <param name="id">供应商ID</param>
        /// <returns></returns>
        szrl100 GetSupplierById(string supplierId);
        #endregion
        #region 供应商编码对应的供应商
        /// <summary>
        /// 删除供应商编码对应的供应商，即删除该供应商所有的版本
        /// </summary>
        /// <param name="code">供应商编码</param>
        /// <returns></returns>
        IOperateResult RemoveSupplier(string code);

        /// <summary>
        /// 删除供应商ID对应的供应商版本
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        IOperateResult RemoveSupplierVersionById(string supplierId);
        #endregion
        #region 维护财务数据
        /// <summary>
        /// 维护财务数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult SaveFinanceData(szrl100 item);

        /// <summary>
        /// 维护财务数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IOperateResult SaveBuilding(szrl104 item);
        #endregion
    }
}
