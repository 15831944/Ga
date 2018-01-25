using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.JsonConvert;
using PM2.Models.Code030.szrl100Model;
using PM2.Models.Code030;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Web;
using PM2.Service.Code030.Szrl105Service;
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code001;
using PM2.Models.Code030.szrl033Model;
using System.IO;
using System.Data;
using PM2.Service.Code030.szrl111Service;

namespace PM2.Service.Code030
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class Szrl100Server : Iszrl100Server
    {
        #region ================= 属性等 ==================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl100> _szrl100Repository;
        private IEFRepository<szrl101> _szrl101Repository;
        private IEFRepository<szrl102> _szrl102Repository;
        private IEFRepository<szrl103> _szrl103Repository;
        private IEFRepository<szrl104> _szrl104Repository;
        private IExcelService _excelService;

        public Szrl100Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl100> szrl100Repository,
             IEFRepository<szrl101> szrl101Repository,
             IEFRepository<szrl102> szrl102Repository,
             IEFRepository<szrl103> szrl103Repository,
             IEFRepository<szrl104> szrl104Repository,
             IExcelService excelService
        )
        {
            this._scopeFactory = scopeFactory;
            this._szrl100Repository = szrl100Repository;
            this._szrl101Repository = szrl101Repository;
            this._szrl102Repository = szrl102Repository;
            this._szrl103Repository = szrl103Repository;
            this._szrl104Repository = szrl104Repository;
            this._excelService = excelService;
        }

        #endregion


        #region =========== 供应商 =========== 

        /// <summary>
        /// 保存供应商
        /// </summary>
        /// <param name="item">供应商信息</param>
        /// <param name="buildingIncCert">建筑企业资质</param>
        /// <param name="signedName">授权代表姓名</param>
        /// <param name="remarkList">备注</param>
        /// <returns></returns>
        public IOperateResult SaveSupplier(szrl100 item, string buildingIncCert, string signedName, string remarkList)
        {
            try
            {
                if (item != null)
                {
                    var result = CheckBeforeSave(item);
                    if (result != null)
                    {
                        return result;
                    }

                    UpdateSupplierInfo1(item);

                    DateTime currentDt = DateTime.Now;
                    item.rl10035 = GlobalService.GetLoginUserName();          // 最后维护人
                    item.rl10036 = currentDt;   // 最后维护时间

                    using (IDbContextScope scope = this._scopeFactory.CreateScope())
                    {
                        if (string.IsNullOrWhiteSpace(item.rl10002)) // 新增
                        {
                            item.rl10001 = NewGuid(); // ID使用GUID
                            //item.rl10002 = Guid.NewGuid().ToString().Substring(0, 5); //企业编码
                            item.rl10002 = GetNewSupplierSerialNo();
                            item.rl10042 = 1;           // 新增版本为1
                            item.rl10039 = GlobalService.GetLoginUserName();          // 制单人
                            item.rl10040 = currentDt;   // 制单时间
                            item.rl10043 = false;       // 是否已审核
                            item.rl10044 = true;
                            item.rl10046 = string.Empty;           // 来源供应商ID为0（即不是更新的版本）
                            this._szrl100Repository.Add(item);

                            AddLocalBuildingIncCert(buildingIncCert, item.rl10001);
                            AddLocalSignedName(signedName, item.rl10001);
                            AddLocalRemarks(remarkList, item.rl10001);

                            scope.SaveChanges();
                        }
                        else    // 修改
                        {
                            //var model = this._szrl100Repository.Find(x => x.rl10001.Equals(item.rl10001));
                            var model = this._szrl100Repository.GetModels(x => x.rl10001.Equals(item.rl10001)).FirstOrDefault();
                            if (model != null)
                            {
                                // 如果是已审核的，则财务权限只能保存财务信息
                                if (Szrl100FormStateService.IsFinanceFlag && model.rl10043)
                                {
                                    model.rl10041 = item.rl10041;
                                    model.rl10034 = item.rl10034;
                                    model.rl10004 = item.rl10004;
                                    
                                    _szrl100Repository.Update(model);
                                }
                                else
                                {
                                    // 企业类型为“工事分包商”时
                                    if (!string.IsNullOrWhiteSpace(item.rl10006_1))
                                    {
                                        var buildingCertsCount = _szrl103Repository.GetModels(x => x.rl10302.Equals(model.rl10001)).Count();
                                        if (buildingCertsCount == 0)
                                        {
                                            return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "企业类型为“工事分包商”时，建筑企业资质清单不能为空！", item.rl10001);
                                        }
                                    }

                                    HoldSupplierInfo(item, model);

                                    if (item.rl10042 == 0) // 是临时版本，则保存为最新未审核版本
                                    {
                                        // 先找到最新版本
                                        var newestVersionModel = _szrl100Repository.GetModels(x => x.rl10002.Equals(item.rl10002), o => { o.Desc(x => x.rl10042); }).FirstOrDefault();
                                        if (newestVersionModel != null)
                                        {
                                            if (newestVersionModel.rl10044 && !newestVersionModel.rl10043) // 如果是最新版本且未审核的话，则不能新建新的版本
                                            {
                                                return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "存在未审核的新版本，无法更新！");
                                            }

                                            // 查找最新版本的供应商，修改为false
                                            var oldModels = _szrl100Repository.GetModels(x => x.rl10044 && x.rl10002.Equals(item.rl10002)).ToArray();
                                            foreach (var oldModel in oldModels)
                                            {
                                                oldModel.rl10044 = false; // 不是最新版本
                                            }
                                            item.rl10044 = true;
                                            item.rl10042 = newestVersionModel.rl10042 + 1;
                                        }
                                    }

                                    // 和本次更新版本前的最新版本进行比较
                                    if (item.rl10042 > 1)
                                    {
                                        var newestVersionModel = _szrl100Repository.GetModels(x => x.rl10002.Equals(item.rl10002) && x.rl10042.Equals(item.rl10042 - 1)).FirstOrDefault();
                                        if (newestVersionModel != null)
                                        {
                                            ConvertSupplierInfo(newestVersionModel);
                                            List<string> execptNames = new List<string>() { "rl10041", "rl10034", "rl10004" };
                                            var difference = item.GetDifference<szrl100>(newestVersionModel, execptNames);
                                            item.rl10047 = difference;
                                        }
                                    }

                                    this._szrl100Repository.Update(item);
                                }
                                
                                scope.SaveChanges();
                                
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "保存成功！", item.rl10001);
        }

        /// <summary>
        /// 首次返回新的建筑企业资质
        /// </summary>
        /// <param name="buildingIncCert">建筑企业资质</param>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        private void AddLocalBuildingIncCert(string buildingIncCert, string supplierId)
        {
            szrl103 newSzrl103 = null;
            // 添加建筑企业资质清单
            if (!string.IsNullOrWhiteSpace(buildingIncCert))
            {
                string[] certs = buildingIncCert.Split(';');
                foreach (var cert in certs)
                {
                    newSzrl103 = new szrl103();
                    newSzrl103.rl10301 = NewGuid();
                    newSzrl103.rl10302 = supplierId;
                    newSzrl103.rl10303 = cert;
                    newSzrl103.rl10304 = DateTime.Now;
                    newSzrl103.rl10305 = GlobalService.GetLoginUserName();
                    _szrl103Repository.Add(newSzrl103);
                }
            }
        }

        /// <summary>
        /// 首次添加合同签订授权代表姓名
        /// </summary>
        /// <param name="signedName"></param>
        /// <param name="supplierId"></param>
        private void AddLocalSignedName(string signedName, string supplierId)
        {
            szrl101 item = new szrl101();
            if (!string.IsNullOrWhiteSpace(signedName))
            {
                string[] names = signedName.Split(';');
                foreach (var name in names)
                {
                    item = new szrl101();
                    item.rl10101 = NewGuid();
                    item.rl10102 = supplierId;
                    item.rl10103 = name;
                    item.rl10104 = DateTime.Now;
                    item.rl10105 = GlobalService.GetLoginUserName();
                    _szrl101Repository.Add(item);
                }
            }
        }

        /// <summary>
        /// 首次添加备注
        /// </summary>
        /// <param name="remarkList"></param>
        /// <param name="supplierId"></param>
        private void AddLocalRemarks(string remarkList, string supplierId)
        {
            if (!string.IsNullOrWhiteSpace(remarkList))
            {
                string[] remarks = remarkList.Split(';');
                foreach (var remark in remarks)
                {
                    szrl102 item = new szrl102();
                    item.rl10201 = NewGuid();
                    item.rl10202 = supplierId;
                    item.rl10203 = remark;
                    item.rl10204 = DateTime.Now;
                    item.rl10205 = GlobalService.GetLoginUserName();
                    _szrl102Repository.Add(item);
                }
            }
        }


        /// <summary>
        /// 保存供应商信息时，保留部分属性不修改
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="currentItem"></param>
        private void HoldSupplierInfo(szrl100 newItem, szrl100 currentItem)
        {
            newItem.rl10042 = currentItem.rl10042;
            newItem.rl10043 = currentItem.rl10043;
            newItem.rl10044 = currentItem.rl10044;
            newItem.rl10045 = currentItem.rl10045;
            newItem.rl10046 = currentItem.rl10046;

            /// 如果没有财务权限，则财务信息不能保存
            if (!Szrl100FormStateService.IsFinanceFlag)
            {
                newItem.rl10025 = currentItem.rl10025; // 维护最后日期
                newItem.rl10004 = currentItem.rl10004; // G&G代码企业关联与否
                newItem.rl10041 = currentItem.rl10041; // G&G代码
                newItem.rl10034 = currentItem.rl10034; // 开票信息维护
            }
            else
            {
                newItem.rl10025 = DateTime.Now;
            }
        }


        /// <summary>
        /// 取新的供应商序列号
        /// </summary>
        /// <returns></returns>
        private string GetNewSupplierSerialNo()
        {
            string sql = "EXEC P_szrl100_GetSerialNo";
            int no = (int)SqlHelper.ExecuteScalar(sql);
            return no.ToString().PadLeft(5, '0');
        }

        /// <summary>
        /// 修改信息1
        /// </summary>
        /// <param name="item"></param>
        private void UpdateSupplierInfo1(szrl100 item)
        {
            string[] contactPersons = new string[] { item.ContactPerson1, item.ContactPerson2, item.ContactPerson3, item.ContactPerson4, item.ContactPerson5 };
            string[] contactPhones = new string[] { item.ContactPhone1, item.ContactPhone2, item.ContactPhone3, item.ContactPhone4, item.ContactPhone5 };
            string[] emails = new string[] { item.Email1, item.Email2, item.Email3, item.Email4, item.Email5 };
            string[] specials = new string[] { item.SpecialCertDetail1, item.SpecialCertDetail2, item.SpecialCertDetail3 };
            string[] rl10006s = new string[] { item.rl10006_1, item.rl10006_2 };
            string[] rl10007s = new string[] { item.rl10007_1, item.rl10007_2, item.rl10007_3, item.rl10007_4, item.rl10007_5 };
            string[] rl10022s = new string[] { item.rl10022_1, item.rl10022_2, item.rl10022_3, item.rl10022_4 };

            //item.rl10004 = (int)item.rl10004_list;
            item.rl10012 = contactPersons.JoinToString(";");
            item.rl10013 = contactPhones.JoinToString(";");
            item.rl10014 = emails.JoinToString(";");
            item.rl10021 = specials.JoinToString(";");
            item.rl10006 = rl10006s.JoinToString(";");
            item.rl10007 = rl10007s.JoinToString(";");
            item.rl10022 = rl10022s.JoinToString(";");

        }


        /// <summary>
        /// 保存供应商信息的临时新版本
        /// 临时版本
        /// </summary>
        /// <param name="item">旧版本供应商信息</param>
        /// <returns></returns>
        public IOperateResult SaveTempNewVersionSupplier(szrl100 item)
        {
            if (item != null)
            {
                var result = CheckBeforeSave(item);
                if (result != null)
                {
                    return result;
                }

                DateTime currentDt = DateTime.Now;
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    // 更新版本只是从原有版本复制内容，修改版本号等部分信息
                    var currentVersionModel = _szrl100Repository.GetModels(x => x.rl10001.Equals(item.rl10001)).FirstOrDefault();
                    if (currentVersionModel != null)
                    {
                        // 复制当前版本内容
                        //item = currentVersionModel.Mapper<szrl100, szrl100>(currentVersionModel);
                        item = IGlobalExtensions.Mapper<szrl100, szrl100>(currentVersionModel);

                        item.rl10035 = GlobalService.GetLoginUserName();          // 最后维护人
                        item.rl10036 = currentDt;   // 最后维护时间
                        item.rl10039 = GlobalService.GetLoginUserName();          // 制单人
                        item.rl10040 = currentDt;   // 制单时间
                        item.rl10043 = false;       // 是否已审核

                        string oldId = item.rl10001;

                        // 修改版本号
                        // 先找到是否存在临时版本
                        // 不需要检测是否存在临时版本，可存在多个临时版本，但要保存成正式最新版本的，最能有一个
                        //var tempVersionModel = _szrl100Repository.GetModels(x => x.rl10002.Equals(item.rl10002) && x.rl10042.Equals(0)).FirstOrDefault();
                        //if (tempVersionModel != null) // 如果是最新版本且未审核的话，则不能新建新的版本
                        //{
                        //    return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "存在未审核的新版本，无法更新！");
                        //}

                        // 临时版本不需更新版本号
                        item.rl10042 = 0;
                        //item.rl10042 = newestVersionModel.rl10042 + 1; // 更新版本号为最新版本加1
                        item.rl10046 = item.rl10001;                    // 更新版本的来源供应商ID

                        // 修改为最新版本标识（临时版本不需要）
                        item.rl10044 = false;
                        //item.rl10044 = true;
                        // 查找最新版本的供应商，修改为false（临时版本无需修改其他版本信息）
                        //var oldModels = _szrl100Repository.GetModels(x => x.rl10044 && x.rl10002.Equals(item.rl10002)).ToArray();
                        //foreach (var model in oldModels)
                        //{
                        //    model.rl10044 = false; // 不是最新版本
                        //}


                        item.rl10045 = false;
                        item.rl10001 = NewGuid();   // 新版本供应商信息的ID是新的
                        this._szrl100Repository.Add(item);


                        var itemList101 = _szrl101Repository.GetModels(x => x.rl10102.Equals(oldId)).ToArray();
                        List<szrl101> szrl101List = new List<szrl101>();
                        foreach (var model in itemList101)
                        {
                            AddLocalSignedName(model.rl10103, item.rl10001);
                        }
                        var itemList102 = _szrl102Repository.GetModels(x => x.rl10202.Equals(oldId)).ToArray();
                        List<szrl102> szrl102List = new List<szrl102>();
                        foreach (var model in itemList102)
                        {
                            AddLocalRemarks(model.rl10203, item.rl10001);
                        }
                        var itemList103 = _szrl103Repository.GetModels(x => x.rl10302.Equals(oldId)).ToArray();
                        List<szrl103> szrl103List = new List<szrl103>();
                        foreach (var model in itemList103)
                        {
                            AddLocalBuildingIncCert(model.rl10303, item.rl10001);
                        }

                        scope.SaveChanges();
                    }
                }
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl10001);
        }



        /// <summary>
        /// 保存供应商信息的新版本
        /// </summary>
        /// <param name="item">旧版本供应商信息</param>
        /// <returns></returns>
        public IOperateResult SaveNewVersionSupplier(szrl100 item)
        {
            if (item != null)
            {
                var result = CheckBeforeSave(item);
                if (result != null)
                {
                    return result;
                }

                //UpdateSupplierInfo1(item);

                DateTime currentDt = DateTime.Now;
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    // 更新版本只是从原有版本复制内容，修改版本号等部分信息
                    var currentVersionModel = _szrl100Repository.GetModels(x => x.rl10001.Equals(item.rl10001)).FirstOrDefault();
                    if (currentVersionModel != null)
                    {
                        // 复制当前版本内容
                        //item = currentVersionModel.Mapper<szrl100, szrl100>(currentVersionModel);
                        item = IGlobalExtensions.Mapper<szrl100, szrl100>(currentVersionModel);

                        item.rl10035 = GlobalService.GetLoginUserName();          // 最后维护人
                        item.rl10036 = currentDt;   // 最后维护时间
                        item.rl10039 = GlobalService.GetLoginUserName();          // 制单人
                        item.rl10040 = currentDt;   // 制单时间
                        item.rl10043 = false;       // 是否已审核

                        string oldId = item.rl10001;

                        // 修改版本号
                        // 先找到最新版本
                        var newestVersionModel = _szrl100Repository.GetModels(x => x.rl10002.Equals(item.rl10002), o => { o.Desc(x => x.rl10042); }).FirstOrDefault();
                        if (newestVersionModel.rl10044 && !newestVersionModel.rl10043) // 如果是最新版本且未审核的话，则不能新建新的版本
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "存在未审核的新版本，无法更新！");
                        }
                        item.rl10042 = newestVersionModel.rl10042 + 1; // 更新版本号为最新版本加1
                        item.rl10046 = item.rl10001;                    // 更新版本的来源供应商ID

                        // 修改为最新版本标识
                        item.rl10044 = true;
                        // 查找最新版本的供应商，修改为false
                        var oldModels = _szrl100Repository.GetModels(x => x.rl10044 && x.rl10002.Equals(item.rl10002)).ToArray();
                        foreach (var model in oldModels)
                        {
                            model.rl10044 = false; // 不是最新版本
                        }


                        item.rl10001 = NewGuid();   // 新版本供应商信息的ID是新的
                        this._szrl100Repository.Add(item);


                        var itemList101 = _szrl101Repository.GetModels(x => x.rl10102.Equals(oldId)).ToArray();
                        List<szrl101> szrl101List = new List<szrl101>();
                        foreach (var model in itemList101)
                        {
                            AddLocalSignedName(model.rl10103, item.rl10001);
                        }
                        var itemList102 = _szrl102Repository.GetModels(x => x.rl10202.Equals(oldId)).ToArray();
                        List<szrl102> szrl102List = new List<szrl102>();
                        foreach (var model in itemList102)
                        {
                            AddLocalRemarks(model.rl10203, item.rl10001);
                        }
                        var itemList103 = _szrl103Repository.GetModels(x => x.rl10302.Equals(oldId)).ToArray();
                        List<szrl103> szrl103List = new List<szrl103>();
                        foreach (var model in itemList103)
                        {
                            AddLocalBuildingIncCert(model.rl10303, item.rl10001);
                        }

                        scope.SaveChanges();
                    }
                }
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl10001);
        }

        /// <summary>
        /// 取供应商代码对应的供应商的所有版本
        /// </summary>
        /// <param name="supplierCode">供应商编码</param>
        /// <returns></returns>
        public IEnumerable<szrl100_SupplierVersion> GetSupplierVersions(string supplierCode)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                // 版本号不能为0
                var versions = _szrl100Repository.GetModels(x => x.rl10002.Equals(supplierCode) && !x.rl10042.Equals(0)).Select(x => new szrl100_SupplierVersion() { Id = x.rl10001, Code = x.rl10002, Version = x.rl10042 }).ToArray();
                foreach (var item in versions)
                {
                    item.VersionDesc = string.Format("版本{0}", item.Version.ToString().PadLeft(3, '0'));
                }
                return versions;
            }
        }


        /// <summary>
        /// 审核（承认）供应商的新版本信息
        /// 修改为已审核，当前版本
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        public IOperateResult AdmitSupplierVersion(string supplierId, string supplierCode, bool rl10026)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var model = _szrl100Repository.GetModels(x => x.rl10001.Equals(supplierId)).FirstOrDefault();
                if (model != null)
                {
                    if (model.rl10043)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "该版本已完成审核，无法再次审核！");
                    }
                    if (model.rl10042 == 0) // 临时版本，不能审核
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "该版本未进行保存更新，无法审核！");
                    }

                    model.rl10026 = rl10026;    // 可否采用
                    model.rl10043 = true; // 修改为已审核状态
                    model.rl10045 = true; // 修改为当前版本标识
                    model.rl10037 = GlobalService.GetLoginUserName();           // 审核人
                    model.rl10038 = DateTime.Now; // 审核时间

                    // 查找同一供应商且ID不是supplierId且已审核且是当前版本的供应商，把他们的当前版本标识修改为false
                    var oldModels = _szrl100Repository.GetModels(x => x.rl10002.Equals(supplierCode) && x.rl10043 && x.rl10045 && !x.rl10001.Equals(supplierId)).ToArray();
                    foreach (var item in oldModels)
                    {
                        item.rl10045 = false; // 不是当前版本
                    }
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "审核成功");
            }
        }


        /// <summary>
        /// 删除供应商编码对应的供应商，即删除该供应商所有的版本
        /// </summary>
        /// <param name="code">供应商编码</param>
        /// <returns></returns>
        public IOperateResult RemoveSupplier(string code)
        {
            using (var scope = this._scopeFactory.CreateScope())
            {
                var list = _szrl100Repository.GetModels(x => x.rl10002.Equals(code)).ToArray();
                if (list.Length > 0)
                {
                    foreach (var item in list)
                    {
                        if (item.rl10043 && item.rl10045)
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "该供应商存在已审核的版本，不能删除！");
                        }
                    }
                    foreach (var item in list)
                    {
                        var itemList101 = _szrl101Repository.GetModels(x => x.rl10102.Equals(item.rl10001)).ToArray();
                        var itemList102 = _szrl102Repository.GetModels(x => x.rl10202.Equals(item.rl10001)).ToArray();
                        var itemList103 = _szrl103Repository.GetModels(x => x.rl10302.Equals(item.rl10001)).ToArray();

                        _szrl101Repository.RemoveRange(itemList101);
                        _szrl102Repository.RemoveRange(itemList102);
                        _szrl103Repository.RemoveRange(itemList103);
                        _szrl100Repository.Remove(item);
                    }
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
            }
        }


        /// <summary>
        /// 删除供应商ID对应的供应商版本
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        public IOperateResult RemoveSupplierVersionById(string supplierId)
        {
            using (var scope = this._scopeFactory.CreateScope())
            {
                var item = _szrl100Repository.GetModels(x => x.rl10001.Equals(supplierId)).FirstOrDefault();
                if (item != null)
                {
                    if (item.rl10043 && item.rl10045)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "该版本为已审核的当前版本，不能删除！");
                    }

                    var itemList101 = _szrl101Repository.GetModels(x => x.rl10102.Equals(supplierId)).ToArray();
                    var itemList102 = _szrl102Repository.GetModels(x => x.rl10202.Equals(supplierId)).ToArray();
                    var itemList103 = _szrl103Repository.GetModels(x => x.rl10302.Equals(supplierId)).ToArray();

                    _szrl101Repository.RemoveRange(itemList101);
                    _szrl102Repository.RemoveRange(itemList102);
                    _szrl103Repository.RemoveRange(itemList103);
                    _szrl100Repository.Remove(item);

                    if (item.rl10044) // 如果删除的是最新的版本，则更新该供应商的最新版本
                    {
                        // 先找到最新版本
                        var newestVersionModel = _szrl100Repository.GetModels(x => x.rl10002.Equals(item.rl10002), o => { o.Desc(x => x.rl10042); }).Skip(1).Take(1).FirstOrDefault();
                        if (newestVersionModel != null)
                        {
                            newestVersionModel.rl10044 = true; // 修改为最新版本
                        }
                    }

                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
            }
        }

        /// <summary>
        /// 保存（新增、修改等）检查
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private IOperateResult CheckBeforeSave(szrl100 item)
        {
            bool validFlag = true;
            string message = string.Empty;
            DateTime currentDt = DateTime.Now;

            // 安全生产许可证有效期
            if (item.rl10017 != null && item.rl10017.Value.CompareTo(currentDt) < 0)
            {
                validFlag = false;
                message = "\"安全生产许可证有效期\"已过期！";

            }
            else if (item.rl10019 && item.rl10020 != null && item.rl10020.Value.CompareTo(currentDt) < 0)
            {
                validFlag = false;
                message = "\"质量认证有效期\"已过期！";
            }

            if (!validFlag)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, message);
            }
            return null;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="black">黑名单</param>
        /// <returns></returns>
        private List<szrl100> Search_szrl100(string key, string black)
        {
            using (var scope = this._scopeFactory.CreateScope())
            {
                if (string.IsNullOrWhiteSpace(black))
                {
                    black = "2";
                }

                List<szrl100> list = null;
                bool allFlag = black.Equals("2"), blackFlag = black.Equals("1");

                if (string.IsNullOrWhiteSpace(key))
                {
                    list = this._szrl100Repository.GetModels(
                        x => x.rl10044 && (allFlag || (x.rl10027 == null && !blackFlag) || (x.rl10027 != null && x.rl10027.Value.Equals(blackFlag))),
                        o =>
                        {
                            o.Desc(x => x.rl10002);
                        }).ToList();
                }
                else
                {
                    list = this._szrl100Repository.GetModels(
                    GetSupplierSeachFuzzyCondition(key, allFlag, blackFlag),
                    o => { o.Desc(x => x.rl10002); }).ToList();
                }

                foreach (var item in list)
                {
                    ConvertSupplierInfo(item);
                }

                return list;
            }
        }


        /// <summary>
        /// 查询最新版本的供应商信息列表
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="black">是否黑名单，1是黑名单，0不是，2全部</param>
        /// <returns></returns>
        public PagerResult SearchSupplierList(string key, string black, PagerInfo info)
        {
            var list = Search_szrl100(key, black);
            var result = new PagerResult() { total = list.Count, rows = list.Skip((info.page - 1) * info.rows).Take(info.rows) };

            return result;
        }


        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="black">黑名单</param>
        /// <param name="info">分页</param>
        /// <returns></returns>
        public MemoryStream ExportExcel_szrl100(string key, string black, PagerInfo info)
        {
            var objList = Search_szrl100(key, black);
            if (info.page > 0 && info.rows > 0)
            {
                objList = objList.Skip((info.page - 1) * info.rows).Take(info.rows).ToList();
            }
            List<SupplierExportObj> meObjList = new List<SupplierExportObj>();
            foreach (var obj in objList)
            {
                if (obj != null)
                {
                    meObjList.Add(ConvertExportObj(obj));
                }
            }
            DataTable dt = GlobalService.ToDataTable(meObjList, "供应商信息");

            return _excelService.ExportToExcel(dt);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private SupplierExportObj ConvertExportObj(szrl100 item)
        {
            SupplierExportObj obj = new SupplierExportObj();
            obj.ContactPerson1 = GetExportText(item.rl10012);
            obj.ContactPhone1 = GetExportText(item.rl10013);
            obj.Email1 = GetExportText(item.rl10014);
            obj.rl10002 = item.rl10002;
            obj.rl10003 = item.rl10003;
            obj.rl10005 = item.rl10005;
            obj.rl10006 = GetExportText(item.rl10006);
            obj.rl10007 = GetExportText(item.rl10007);
            obj.rl10008 = item.rl10008;
            obj.rl10009 = item.rl10009;
            obj.rl10015 = item.rl10015 ? "有" : "无";
            obj.rl10016 = item.rl10016 ? "有" : "无";
            obj.rl10017 = item.rl10017 != null ? item.rl10017.Value.ToString("yyyy-MM-dd") : "";
            obj.rl10018 = item.rl10018 ? "有" : "无";
            obj.rl10019 = item.rl10019 ? "有" : "无";
            obj.rl10020 = item.rl10020 != null ? item.rl10020.Value.ToString("yyyy-MM-dd") : "";
            obj.rl10026 = item.rl10026 != null ? item.rl10026.Value ? "可用" : "不可用" : "";
            obj.rl10027 = item.rl10027 != null ? item.rl10027.Value ? "是" : "否" : "否";
            obj.rl10041 = item.rl10041;
            return obj;
        }

        /// <summary>
        /// 取导出文本
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string GetExportText(string text)
        {
            string result = string.Empty;
            if (text.Contains(";"))
            {
                StringBuilder sb = new StringBuilder();
                string[] arr = text.Split(';');
                foreach (var item in arr)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        sb.Append(item);
                        sb.Append(";");
                    }
                }
                sb.Remove(sb.Length - 1, 1);
                result = sb.ToString();
            }
            return result;
        }


        /// <summary>
        /// 供应商模糊查询条件
        /// </summary>
        /// <param name="key">查询关键词</param>
        /// <returns></returns>
        private Expression<Func<szrl100, bool>> GetSupplierSeachFuzzyCondition(string key, bool allFlag, bool blackFlag)
        {
            bool dtFlag = false, decimalFlag = false, yesFlag = false;
            DateTime dt;
            decimal money;
            dtFlag = DateTime.TryParse(key, out dt);
            string dtString = dtFlag ? dt.ToString("yyyy-MM-dd") : string.Empty;
            decimalFlag = decimal.TryParse(key, out money);
            bool judgeFlag = new string[] { "是", "有", "可用", "否", "无", "不可用" }.Contains(key);
            yesFlag = key.Equals("是") || key.Equals("有") || key.Equals("可用");
            int ggCode = key.Equals("一般") ? 1 : key.Equals("关联公司") ? 2 : key.Equals("母公司") ? 3 : -1;

            return x => x.rl10044 && // 最新版本
                    (x.rl10002.Contains(key)                // 供应商（企业）编码
                    && (allFlag || (x.rl10027 == null && !blackFlag) || (x.rl10027 != null && x.rl10027.Value.Equals(blackFlag)))
                    || x.rl10041.Contains(key)              // G&G代码
                    || (x.rl10004 != null && x.rl10004.Value == ggCode)             // G&G代码企业关联与否
                    || x.rl10003.Contains(key)              // 企业名
                    || x.rl10005.Contains(key)              // 曾用名
                    || x.rl10006.Contains(key)              // 企业类型
                    || x.rl10007.Contains(key)              // 种类分别
                    || x.rl10008.Contains(key)              // 产品类型
                    || x.rl10009.Contains(key)              // 联系地址
                    || x.rl10012.Contains(key)              // 联系人
                    || x.rl10013.Contains(key)              // 联系电话
                    || x.rl10014.Contains(key)              // 电子邮箱
                    || (judgeFlag && x.rl10015.Equals(yesFlag))            // rl10015建筑企业资质
                    || (judgeFlag && x.rl10016.Equals(yesFlag))            // rl10016安全生产许可证
                    || (dtFlag && SqlFunctions.DateDiff("day", x.rl10017, dtString) == 0)
                    // 安全生产许可证有效期
                    || (judgeFlag && x.rl10018.Equals(yesFlag))            // rl10018特别资质
                    || (judgeFlag && x.rl10019.Equals(yesFlag))            // rl10019质量认证
                    || (dtFlag && x.rl10020 != null && SqlFunctions.DateDiff("day", x.rl10020.Value, dtString) == 0)
                    // 质量认证有效期
                    || x.rl10022.Contains(key)              // 质量认证明细
                    || (judgeFlag && x.rl10026 != null && x.rl10026.Value.Equals(yesFlag))            //|| x.rl10026.Contains(key)              // 可否采用
                    || (judgeFlag && x.rl10027 != null && x.rl10027.Value.Equals(yesFlag))            //|| x.rl10027.Contains(key)              // 是否黑名单
                    || (dtFlag && SqlFunctions.DateDiff("day", x.rl10029, dtString) == 0)
                    // 成立日期
                    || (decimalFlag && x.rl10030 == money)              // 注册资本（万元）
                    || x.rl10031.Contains(key)              // 公司注册地址
                    || x.rl10032.Contains(key)              // 法人代表姓名
                    || x.rl10033.Contains(key)              // 产品编号
                    );
        }




        /// <summary>
        /// 根据供应商编码取对应供应商信息
        /// </summary>
        /// <param name="id">供应商ID</param>
        /// <returns></returns>
        public szrl100 GetSupplierById(string supplierId)
        {
            using (var scope = this._scopeFactory.CreateScope())
            {
                var model = this._szrl100Repository.GetModels(x => x.rl10001.Equals(supplierId)).FirstOrDefault();
                if (model != null)
                {
                    ConvertSupplierInfo(model);
                }
                return model;
            }
        }






        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="item"></param>
        private void ConvertSupplierInfo(szrl100 item)
        {
            string[] persons = item.rl10012.Split(new char[] { ';' });
            string[] phones = item.rl10013.Split(new char[] { ';' });
            string[] emails = item.rl10014.Split(new char[] { ';' });
            string[] specials = item.rl10021.Split(new char[] { ';' });
            string[] rl10006s = item.rl10006.Split(new char[] { ';' });
            string[] rl10007s = item.rl10007.Split(new char[] { ';' });
            string[] rl10022s = new string[] { };
            if (!string.IsNullOrWhiteSpace(item.rl10022))
            {
                rl10022s = item.rl10022.Split(';');
            }

            item.SupplierCode = item.rl10002;
            if (item.rl10004 != null && item.rl10004.Value != 0)
            {
                item.rl10004_list = (GGCodeType)item.rl10004;
            }
            if (persons.Length == 5 && phones.Length == 5 && emails.Length == 5)
            {
                item.ContactPerson1 = persons[0];
                item.ContactPerson2 = persons[1];
                item.ContactPerson3 = persons[2];
                item.ContactPerson4 = persons[3];
                item.ContactPerson5 = persons[4];

                item.ContactPhone1 = phones[0];
                item.ContactPhone2 = phones[1];
                item.ContactPhone3 = phones[2];
                item.ContactPhone4 = phones[3];
                item.ContactPhone5 = phones[4];

                item.Email1 = emails[0];
                item.Email2 = emails[1];
                item.Email3 = emails[2];
                item.Email4 = emails[3];
                item.Email5 = emails[4];

                item.rl10007_1 = rl10007s[0];
                item.rl10007_2 = rl10007s[1];
                item.rl10007_3 = rl10007s[2];
                item.rl10007_4 = rl10007s[3];
                item.rl10007_5 = rl10007s[4];
            }
            if (specials.Length == 3)
            {
                item.SpecialCertDetail1 = specials[0];
                item.SpecialCertDetail2 = specials[1];
                item.SpecialCertDetail3 = specials[2];
            }
            if (rl10006s.Length == 2)
            {
                item.rl10006_1 = rl10006s[0];
                item.rl10006_2 = rl10006s[1];
            }
            if (rl10022s.Length == 4)
            {
                item.rl10022_1 = rl10022s[0];
                item.rl10022_2 = rl10022s[1];
                item.rl10022_3 = rl10022s[2];
                item.rl10022_4 = rl10022s[3];
            }
            item.rl10004_list = item.rl10004 == null ? 0 : (GGCodeType)item.rl10004;
        }


        /// <summary>
        /// 维护财务数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult SaveFinanceData(szrl100 item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var model = _szrl100Repository.GetModels(x => x.rl10001.Equals(item.rl10001)).FirstOrDefault();
                if (model != null)
                {
                    model.rl10025 = DateTime.Now; // 维护最后日期
                    model.rl10004 = item.rl10004; // G&G代码企业关联与否
                    model.rl10041 = item.rl10041; // G&G代码
                    model.rl10034 = item.rl10034; // 开票信息维护
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl10001);
            }
        }


        #endregion



        #region ========== 合同签订授权代表姓名 ==========

        /// <summary>
        /// 取合同签订授权代表姓名信息列表
        /// </summary>
        /// <param name="gysCode">供应商代码</param>
        /// <returns></returns>
        public List<SignedNameObj> GetSignedNameList(string supplierId)
        {
            List<SignedNameObj> list = null;
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    var modelList = this._szrl101Repository.GetModels(m => m.rl10102.Equals(supplierId)).OrderBy(x => x.rl10104).ToList();
                    list = modelList.Select((p, idx) => new SignedNameObj() { ID = p.rl10101, RowNo = idx + 1, Name = p.rl10103 }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }


        /// <summary>
        /// 添加合同签订授权代表姓名
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult AddSignedName(szrl101 item)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    var count = this._szrl101Repository.GetModels(x => x.rl10102.Equals(item.rl10102)).Count();
                    if (count >= 10)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.ValidError, "最多只能添加10个合同签订授权代表姓名！");
                    }
                    item.rl10101 = NewGuid();
                    item.rl10104 = DateTime.Now;
                    item.rl10105 = GlobalService.GetLoginUserName();
                    this._szrl101Repository.Add(item);
                    scope.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }


        /// <summary>
        /// 删除合同签订授权代表姓名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IOperateResult DeleteSignedName(string id)
        {
            using (var scope = this._scopeFactory.CreateScope())
            {
                var model = _szrl101Repository.GetModels(x => x.rl10101.Equals(id)).FirstOrDefault();
                if (model != null)
                {
                    this._szrl101Repository.Remove(model);
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
            }
        }




        #endregion


        #region ============= 建筑企业资质清单 =================


        /// <summary>
        /// 取建筑企业资质清单列表
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        public List<BuildingIncCertObj> SearchBuildingIncCertList(string supplierId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var modelList = _szrl103Repository.GetModels(x => x.rl10302.Equals(supplierId)).OrderBy(x => x.rl10304).ToList();
                var list = modelList.Select((p, idx) => new BuildingIncCertObj() { ID = p.rl10301, RowNo = idx + 1, Info = p.rl10303 }).ToList();
                return list;
            }
        }


        /// <summary>
        /// 添加建筑企业资质
        /// </summary>
        /// <param name="item"></param>
        public IOperateResult AddBuildingIncCert(szrl103 item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                item.rl10301 = NewGuid();
                item.rl10304 = DateTime.Now;
                item.rl10305 = GlobalService.GetLoginUserName();
                _szrl103Repository.Add(item);
                scope.SaveChanges();
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl10301);
        }


        /// <summary>
        /// 删除建筑企业资质
        /// </summary>
        /// <param name="id"></param>
        public IOperateResult DeleteBuildingIncCert(string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var item = _szrl103Repository.GetModels(x => x.rl10301.Equals(id)).FirstOrDefault();
                if (item != null)
                {
                    _szrl103Repository.Remove(item);
                    scope.SaveChanges();
                }
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }

        public IOperateResult SaveBuilding(szrl104 item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var model = _szrl104Repository.GetModels(x => x.rl10401.Equals(item.rl10401)).FirstOrDefault();
                if (model != null)
                {
                    _szrl104Repository.Update(item);
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
            }
        }


        #endregion




        #region ================ 备注 ====================

        /// <summary>
        /// 取对应供应商的备注列表
        /// </summary>
        /// <param name="supplierId">供应商ID</param>
        /// <returns></returns>
        public List<szrl100_RemarkObj> SearchRemarkList(string supplierId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var modelList = _szrl102Repository.GetModels(x => x.rl10202.Equals(supplierId)).OrderBy(x => x.rl10204).ToList();
                var list = modelList.Select((p, idx) => new szrl100_RemarkObj() { ID = p.rl10201, RowNo = idx + 1, Remark = p.rl10203 }).ToList();
                return list;
            }
        }


        /// <summary>
        /// 添加备注
        /// </summary>
        /// <param name="item"></param>
        public IOperateResult AddRemark(szrl102 item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                item.rl10201 = NewGuid();
                item.rl10204 = DateTime.Now;
                item.rl10205 = GlobalService.GetLoginUserName();
                _szrl102Repository.Add(item);
                scope.SaveChanges();
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl10201);
        }


        /// <summary>
        /// 删除备注
        /// </summary>
        /// <param name="id"></param>
        public IOperateResult DeleteRemark(string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var item = _szrl102Repository.GetModels(x => x.rl10201.Equals(id)).FirstOrDefault();
                if (item != null)
                {
                    _szrl102Repository.Remove(item);
                    scope.SaveChanges();
                }
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }

        #endregion


        /// <summary>
        /// 取新的GUID
        /// </summary>
        /// <returns></returns>
        private string NewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }


        
    }
}
