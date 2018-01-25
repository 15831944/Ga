using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using System.Linq.Expressions;
using System.Data.Entity.SqlServer;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl033Model;
using Gmail.DDD.Service;
using PM2.Service.Code030.Szrl105Service;
using Newtonsoft.Json;
using PM2.Models.Code030;
using PM2.Models.Code030.szrl111Model;
using PM2.Models.Code001;
using PM2.Repository.Code019;
using System.IO;
using System.Data;
using PM2.Service.Code030.szrl111Service;
using System.Collections;

namespace PM2.Service.Code030.szrl033Service
{
    /// <summary>
    /// 营业合同登记
    /// </summary>
    public class szrl033Server : CmDataService<szrl033>, Iszrl033Server
    {
        #region ================= 属性等 ==================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl033> _szrl033Repository;
        private IEFRepository<szrl001> _szrl001Repository;
        private IEFRepository<szrl004> _szrl004Repository;
        private IEFRepository<szrl018> _szrl018Repository;
        private IEFRepository<szrl019> _szrl019Repository;
        private IEFRepository<szrl022> _szrl022Repository;
        private IEFRepository<szrl023> _szrl023Repository;
        private IEFRepository<szrl024> _szrl024Repositoty;
        private IEFRepository<szrl034> _szrl034Repository;
        private Isdpk007Repository_Facade _sdpj004Repository;
        private IEFRepository<rlvw_ConTree> _rlvw_ConTreeRepository;
        private IExcelService _excelService;
        public szrl033Server(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<szrl033> szrl033Repository,
            IEFRepository<szrl001> szrl001Repository,
            IEFRepository<szrl004> szrl004Repository,
            IEFRepository<szrl018> szrl018Repository,
            IEFRepository<szrl019> szrl019Repository,
            IEFRepository<szrl022> szrl022Repositoty,
            IEFRepository<szrl023> szrl023Repositoty,
            IEFRepository<szrl024> szrl024Repository,
            IEFRepository<szrl034> szrl034Repository,
            Isdpk007Repository_Facade sdpj004Repository,
            IEFRepository<rlvw_ConTree> rlvw_ConTreeRepositoty,
            IExcelService excelService
        ) : base(scopeFactory, szrl033Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl033Repository = szrl033Repository;
            this._szrl001Repository = szrl001Repository;
            this._szrl004Repository = szrl004Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl019Repository = szrl019Repository;
            this._szrl022Repository = szrl022Repositoty;
            this._szrl023Repository = szrl023Repositoty;
            this._szrl024Repositoty = szrl024Repository;
            this._szrl034Repository = szrl034Repository;
            this._sdpj004Repository = sdpj004Repository;
            this._rlvw_ConTreeRepository = rlvw_ConTreeRepositoty;
            this._excelService = excelService;
        }

        #endregion


        /// <summary>
        /// 保存营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult Save_szrl033(szrl033 item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                if (item != null)
                {
                    if (string.IsNullOrWhiteSpace(item.rl03301)) // 新增
                    {
                        ModifyAddInfo_szrl033(item);
                        if (item.szrl034List != null)
                        {
                            foreach (var subItem in item.szrl034List)
                            {
                                var existFlag = _szrl034Repository.GetModels().Where(x => x.rl03401 == subItem.rl03401).Count() == 1;
                                if (!existFlag) // 明细项不存在
                                {
                                    subItem.rl03402 = item.rl03301;
                                    _szrl034Repository.Add(subItem);
                                }
                            }
                        }
                        _szrl033Repository.Add(item);
                    }
                    else // 修改
                    {
                        var model = _szrl033Repository.GetModels(x => x.rl03301 == item.rl03301).FirstOrDefault();
                        ModifyUpdateInfo_szrl033(item, model);
                        _szrl033Repository.Update(item);
                        if (item.szrl034List != null)
                        {
                            foreach (var subItem in item.szrl034List)
                            {
                                var existFlag = _szrl034Repository.GetModels().Where(x => x.rl03401 == subItem.rl03401).Count() == 1;
                                if (existFlag) // 明细项存在
                                {
                                    _szrl034Repository.Update(subItem);
                                }
                            }
                        }
                    }
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, item.rl03301);
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, null);
            }
        }

        /// <summary>
        /// 保存营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult Save_szrl033(List<VAcceptancePlanObj> itemList, szrl033 szrl033Item)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                if (szrl033Item != null)
                {
                    try
                    {
                        if (itemList != null)
                        {
                            if (szrl033Item.szrl034List == null)
                            {
                                szrl033Item.szrl034List = new List<szrl034>();
                            }
                            foreach (var item in itemList)
                            {
                                szrl034 newSzrl034 = ConvertToSzrl034(item);
                                szrl033Item.szrl034List.Add(newSzrl034);
                            }
                        }
                        if (string.IsNullOrWhiteSpace(szrl033Item.rl03301)) // 新增
                        {
                            szrl033Item.rl03309 = GlobalService.GetLoginUserId();
                            szrl033Item.rl03310 = DateTime.Now.ToString("yyyy-MM-dd");
                            ModifyAddInfo_szrl033(szrl033Item);
                            if (szrl033Item.szrl034List != null)
                            {
                                foreach (var subItem in szrl033Item.szrl034List)
                                {
                                    var existFlag = _szrl034Repository.GetModels().Where(x => x.rl03401 == subItem.rl03401).Count() == 1;
                                    if (!existFlag) // 明细项不存在
                                    {
                                        subItem.rl03402 = szrl033Item.rl03301;
                                        //subItem.rl03412 = 1;
                                        _szrl034Repository.Add(subItem);
                                    }
                                }
                            }
                            _szrl033Repository.Add(szrl033Item);
                        }
                        else // 修改
                        {
                            // 检查该合同下，是否存在已保存未审核的验收登记项
                            var count = _szrl034Repository.GetModels(x => x.rl03402 == szrl033Item.rl03301 && x.rl03412 != 1).Count();
                            if (count > 0)
                            {
                                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "存在未承认的验收登记项，无法保存！");
                            }

                            var model = _szrl033Repository.GetModels(x => x.rl03301 == szrl033Item.rl03301).FirstOrDefault();
                            ModifyUpdateInfo_szrl033(szrl033Item, model);
                            _szrl033Repository.Update(szrl033Item);
                            if (szrl033Item.szrl034List != null)
                            {
                                foreach (var subItem in szrl033Item.szrl034List)
                                {
                                    var existFlag = _szrl034Repository.GetModels().Where(x => x.rl03401 == subItem.rl03401).Count() == 1;
                                    if (existFlag) // 明细项存在
                                    {
                                        _szrl034Repository.Update(subItem);
                                    }
                                    else
                                    {
                                        subItem.rl03402 = szrl033Item.rl03301;
                                        // subItem.rl03412 = 1;
                                        _szrl034Repository.Add(subItem);
                                    }
                                }
                            }
                        }
                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, szrl033Item.rl03301);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "保存失败！");
            }
        }

        /// <summary>
        /// 承认
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public IOperateResult Admit_szrl034(List<VAcceptancePlanObj> objs)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                if (objs != null)
                {
                    try
                    {
                        // 验收登记明细ID，取未验收的，验收日期、验收证明取得日不为空的ID
                        List<string> idList = objs.Where(x => x.rl03412 != 1 && !string.IsNullOrWhiteSpace(x.rl03408) && !string.IsNullOrWhiteSpace(x.rl03410)).Select(x => x.rl03401).ToList();
                        // 验收登记ID
                        List<string> list = objs.Select(x => x.rl03402).Distinct().ToList();
                        // 未验收的明细
                        var unAcceptModels = _szrl034Repository.GetModels().Where(x => idList.Contains(x.rl03401) && x.rl03412 != 1).ToArray();
                        // 更新合同验收登记明细的验收状态
                        foreach (var model in unAcceptModels)
                        {
                            model.rl03412 = 1;
                            _szrl034Repository.Update(model);
                        }

                        // 验收登记的审核状态
                        foreach (var id in list)
                        {
                            var szrl033Model = _szrl033Repository.GetModels().Where(x => x.rl03301.Equals(id)).FirstOrDefault();
                            if (szrl033Model != null)
                            {
                                int unAcceptCount = unAcceptModels.Length;
                                // 看该验收登记下的明细是否已全部验收（未验收数量为上面正在验收的数量）
                                var flag = _szrl034Repository.GetModels().Where(x => x.rl03412 != 1).Count() == unAcceptCount;
                                if (flag) // 明细已全部验收，则修改验收登记审核状态
                                {
                                    // 修改为已审核
                                    szrl033Model.rl03311 = GlobalService.GetLoginUserId();
                                    szrl033Model.rl03312 = DateTime.Now.ToString("yyyy-MM-dd");
                                    szrl033Model.rl03313 = 1;
                                    _szrl033Repository.Update(szrl033Model);

                                    // 工程完工证明取得日、实际完工日期
                                    var contractId = szrl033Model.rl03302;
                                    var szrl019Model = _szrl019Repository.GetModels().Where(x => x.rl01902.Equals(contractId) && x.rl01964 == 1).FirstOrDefault();
                                    if (szrl019Model != null)
                                    {
                                        szrl019Model.rl01949 = szrl033Model.rl03307;
                                        szrl019Model.rl01916 = szrl033Model.rl03308;
                                        _szrl019Repository.Update(szrl019Model);
                                    }

                                    // 验收/收款计划的验收状态
                                    List<string> szrl024IdList = objs.Where(x => x.rl03412 != 1 && !string.IsNullOrWhiteSpace(x.rl03408) && !string.IsNullOrWhiteSpace(x.rl03410)).Select(x => x.rl02401).ToList();
                                    foreach (var szrl1024Id in szrl024IdList)
                                    {
                                        var szrl024Model = _szrl024Repositoty.GetModels().Where(x => x.rl02401.Equals(szrl1024Id)).FirstOrDefault();
                                        if (szrl024Model != null)
                                        {
                                            szrl024Model.rl02408 = 1;
                                            _szrl024Repositoty.Update(szrl024Model);
                                        }
                                    }
                                }

                            }
                        }

                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, null);
            }
        }

        private szrl034 ConvertToSzrl034(VAcceptancePlanObj obj)
        {
            szrl034 newIteobj = new szrl034();
            newIteobj.rl03401 = obj.rl03401;
            newIteobj.rl03402 = obj.rl03402;
            newIteobj.rl03403 = obj.rl03403;
            newIteobj.rl03404 = obj.rl03404;
            newIteobj.rl03405 = obj.rl03405 ?? 0;
            newIteobj.rl03406 = obj.rl03406 ?? 0;
            newIteobj.rl03407 = obj.rl03407;
            newIteobj.rl03408 = obj.rl03408;
            newIteobj.rl03409 = obj.rl03409 ?? 0;
            newIteobj.rl03410 = obj.rl03410;
            newIteobj.rl03411 = obj.rl03411 ?? 1;
            newIteobj.rl03412 = obj.rl03412 ?? 0;
            newIteobj.rl03413 = obj.rl03413;
            return newIteobj;
        }


        /// <summary>
        /// 删除营业合同登记
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult Delete_szrl033(szrl033 item)
        {
            return Delete(item);
        }


        /// <summary>
        /// 查询营业合同登记
        /// </summary>
        /// <returns></returns>
        public IEnumerable<szrl033> Search_szrl033(string key)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                if (!string.IsNullOrWhiteSpace(key))
                {
                    var condition = GetCondition(key);
                    return _szrl033Repository.GetModels(condition).ToArray();
                }
                else
                {
                    return _szrl033Repository.GetModels().ToArray();
                }
            }
        }

        private Expression<Func<szrl033, bool>> GetCondition(string key)
        {
            return x => x.rl03303.Contains(key);
        }

        /// <summary>
        /// 分页查询营业合同登记
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        public PagerResult SearchPager_szrl033(string key, PagerInfo pager)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                int skipNum = pager.rows * (pager.page - 1);
                int takeNum = pager.rows;
                var result = new PagerResult();
                var list = Search_szrl033(key);
                result.total = list.Count();
                result.rows = list.Skip(skipNum).Take(takeNum).ToArray();
                return result;
            }
        }


        /// <summary>
        /// 获取某个ID的营业合同登记的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public szrl033 Get_szrl033(string id)
        {
            return Find(x => x.rl03301.Equals(id)).FirstOrDefault();
        }


        /// <summary>
        /// 修改要添加的信息
        /// </summary>
        /// <param name="item"></param>
        private void ModifyAddInfo_szrl033(szrl033 item)
        {
            item.rl03301 = GlobalService.NewGuid();
            item.rl03311 = "";
            item.rl03312 = "";
            item.rl03314 = GlobalService.GetLoginUserId();
            item.rl03315 = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrWhiteSpace(item.rl03307))
            {
                item.rl03307 = "";
            }
            if (string.IsNullOrWhiteSpace(item.rl03308))
            {
                item.rl03308 = "";
            }
        }

        /// <summary>
        /// 修改要更新的信息
        /// </summary>
        /// <param name="item"></param>
        private void ModifyUpdateInfo_szrl033(szrl033 item, szrl033 model)
        {
            item.rl03309 = model.rl03309;
            item.rl03310 = model.rl03310;
            item.rl03311 = model.rl03311;
            item.rl03312 = model.rl03312;
            item.rl03313 = model.rl03313;
            item.rl03314 = GlobalService.GetLoginUserId();
            item.rl03315 = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrWhiteSpace(item.rl03307))
            {
                item.rl03307 = "";
            }
            if (string.IsNullOrWhiteSpace(item.rl03308))
            {
                item.rl03308 = "";
            }
        }


        /// <summary>
        /// 取未验收状态的验收计划明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<VAcceptancePlanObj> Get_szrl024(string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                //var items = _szrl024Repositoty.GetModels().Where(x => x.rl02402.Equals(id) && x.rl02408 == 0).ToList();
                var items = (from h in _szrl022Repository.GetModels()
                             join m in _szrl024Repositoty.GetModels()
                             on h.rl02201 equals m.rl02402
                             join c in _szrl023Repository.GetModels()
                             on m.rl02403 equals c.rl02301
                             join e in _szrl023Repository.GetModels()
                             on m.rl02403 equals e.rl02301
                             join n in _szrl034Repository.GetModels()
                             on m.rl02401 equals n.rl03403 into mn
                             where ((id != "" && h.rl02202 == id) || (id == "" || id == null))
                                //&& (e.rl02302 != "预付款" && e.rl02302 != "质保款")
                             from mns in mn.DefaultIfEmpty()
                             select new VAcceptancePlanObj
                             {
                                 rl02401 = m.rl02401,
                                 rl02402 = m.rl02402,
                                 rl02403 = c.rl02302,
                                 rl02404 = m.rl02404,
                                 rl02405 = m.rl02405,
                                 rl02406 = m.rl02406,
                                 rl02407 = m.rl02407,
                                 rl02408 = m.rl02408,
                                 rl03401 = mns.rl03401,
                                 rl03402 = mns.rl03402,
                                 rl03403 = mns.rl03403,
                                 rl03404 = mns.rl03404,
                                 rl03405 = mns.rl03405,
                                 rl03406 = mns.rl03406,
                                 rl03407 = mns.rl03407,
                                 rl03408 = mns.rl03408,
                                 rl03409 = mns.rl03409,
                                 rl03410 = mns.rl03410,
                                 rl03411 = mns.rl03411,
                                 rl03412 = mns.rl03412,
                                 rl03413 = mns.rl03413,
                                 rl02303 = c.rl02303,
                             }).ToList();
                foreach (var item in items)
                {
                    if (string.IsNullOrWhiteSpace(item.rl03401))
                    {
                        item.rl03401 = GlobalService.NewGuid();
                        item.rl03403 = item.rl02401;
                        item.rl03404 = item.rl02403;
                        item.rl03405 = item.rl02404;
                        item.rl03406 = item.rl02405;
                        item.rl03407 = item.rl02406;
                        item.rl03409 = item.rl02405;
                        item.rl03413 = GlobalService.NewGuid();
                        item.IsChanged = false;
                        item.AttachFileCount = _sdpj004Repository.GetFileCount(item.rl03413);
                    }
                    else
                    {
                        item.AttachFileCount = _sdpj004Repository.GetFileCount(item.rl03413);
                    }
                }

                return items;

            }
        }


        /// <summary>
        /// 取未验收状态的验收计划明细对应的合同分类信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<VAcceptancePlanObj> GetContractType_index_szrl024(string key)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                bool keyFlag = string.IsNullOrWhiteSpace(key);
                var items = (from m in _szrl024Repositoty.GetModels()
                             join h in _szrl022Repository.GetModels()
                             on m.rl02402 equals h.rl02201
                             join a in _szrl019Repository.GetModels()
                             on h.rl02202 equals a.rl01902
                             join b in _szrl018Repository.GetModels()
                             on a.rl01906 equals b.rl01801
                             join c in _szrl004Repository.GetModels()
                             on a.rl01905 equals c.rl00401
                             join d in _szrl001Repository.GetModels()
                             on c.rl00416 equals d.rl00101
                             join n in _szrl034Repository.GetModels()
                             on m.rl02401 equals n.rl03403 into mn
                             where c.rl00454 == 1 && a.rl01964 == 1
                                && (keyFlag || (!keyFlag && (c.rl00403.Contains(key) || b.rl01807.Contains(key) || a.rl01903.Contains(key))))
                             from mns in mn.DefaultIfEmpty()
                             select new VAcceptancePlanObj
                             {
                                 rl00101 = d.rl00101,
                                 rl00103 = d.rl00103,
                                 rl00401 = c.rl00401,
                                 rl00403 = c.rl00403,
                                 rl01801 = b.rl01801,
                                 rl01807 = b.rl01807,
                                 rl01902 = a.rl01902,
                                 rl01903 = a.rl01903
                             }).Distinct().OrderBy(x => x.rl00101).ThenBy(x => x.rl00401).ThenBy(x => x.rl01801).ThenBy(x => x.rl01902).ToList();
                return items;
            }
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<VAcceptancePlanObj> Search_Get_index_szrl024(string key, string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                bool keyFlag = string.IsNullOrWhiteSpace(key), idFlag = string.IsNullOrWhiteSpace(id);
                var items = (from m in _szrl024Repositoty.GetModels()
                             join h in _szrl022Repository.GetModels()
                             on m.rl02402 equals h.rl02201
                             join e in _szrl023Repository.GetModels()
                             on m.rl02403 equals e.rl02301
                             join a in _szrl019Repository.GetModels()
                             on h.rl02202 equals a.rl01902
                             join b in _szrl018Repository.GetModels()
                             on a.rl01906 equals b.rl01801
                             join c in _szrl004Repository.GetModels()
                             on a.rl01905 equals c.rl00401
                             join d in _szrl001Repository.GetModels()
                             on c.rl00416 equals d.rl00101
                             join n in _szrl034Repository.GetModels()
                             on m.rl02401 equals n.rl03403 into mn
                             from mns in mn.DefaultIfEmpty()
                             where c.rl00454 == 1 && a.rl01964 == 1 && mns.rl03412 == 1
                                //&& (e.rl02302 != "预付款" && e.rl02302 != "质保款")
                                && (idFlag || (!idFlag && (d.rl00101 == id || c.rl00401 == id || b.rl01801 == id || a.rl01902 == id)))
                                && (keyFlag || (!keyFlag && (c.rl00403.Contains(key) || b.rl01807.Contains(key) || a.rl01903.Contains(key))))
                             select new VAcceptancePlanObj
                             {
                                 rl00101 = d.rl00101,
                                 rl00103 = d.rl00103,
                                 rl00401 = c.rl00401,
                                 rl00403 = c.rl00403,
                                 rl01801 = b.rl01801,
                                 rl01807 = b.rl01807,
                                 rl01902 = a.rl01902,
                                 rl01903 = a.rl01903,
                                 rl01951 = a.rl01951,
                                 rl02401 = m.rl02401,
                                 rl02402 = m.rl02402,
                                 rl02403 = e.rl02302,
                                 rl02404 = m.rl02404,
                                 rl02405 = m.rl02405,
                                 rl02406 = m.rl02406,
                                 rl02407 = m.rl02407,
                                 rl02408 = m.rl02408,
                                 rl03401 = mns.rl03401,
                                 rl03402 = mns.rl03402,
                                 rl03403 = mns.rl03403,
                                 rl03404 = mns.rl03404,
                                 rl03405 = mns.rl03405,
                                 rl03406 = mns.rl03406,
                                 rl03407 = mns.rl03407,
                                 rl03408 = mns.rl03408,
                                 rl03409 = mns.rl03409,
                                 rl03410 = mns.rl03410,
                                 rl03411 = mns.rl03411,
                                 rl03412 = mns.rl03412,
                                 rl03413 = mns.rl03413,
                             }).OrderBy(x => x.rl00101).ThenBy(x => x.rl00401).ThenBy(x => x.rl01801).ThenBy(x => x.rl01902).ToList();
                foreach (var item in items)
                {
                    if (string.IsNullOrWhiteSpace(item.rl03401))
                    {
                        item.rl03401 = GlobalService.NewGuid();
                        item.rl03403 = item.rl02401;
                        item.rl03404 = item.rl02403;
                        item.rl03405 = item.rl02404;
                        item.rl03406 = item.rl02405;
                        item.rl03407 = item.rl02406;
                        item.rl03409 = item.rl02405;
                        item.rl03413 = GlobalService.NewGuid();
                        item.IsChanged = false;
                        item.AttachFileCount = _sdpj004Repository.GetFileCount(item.rl03413);
                    }
                    else
                    {
                        item.AttachFileCount = _sdpj004Repository.GetFileCount(item.rl03413);
                    }
                }
                return items;
            }
        }

        /// <summary>
        /// 取未验收状态的验收计划明细
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public PagerResult Get_index_szrl024(PagerInfo info, string key, string id)
        {
            var items = Search_Get_index_szrl024(key, id);

            var pagerResult = new PagerResult();
            var list = items.Skip((info.page - 1) * info.rows).Take(info.rows);
            pagerResult.rows = list;
            pagerResult.total = items.Count;
            pagerResult.footer = new ArrayList() { new { rl02404 = items.Sum(x => x.rl02404), rl02405 = items.Sum(x => x.rl02405), rl03409 = items.Sum(x => x.rl03409) } };
            return pagerResult;

        }


        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dirId"></param>
        public MemoryStream ExportExcel_szrl033(string key, string id, int pageNum, int pageSize)
        {
            IEnumerable<VAcceptancePlanObj> objList = Search_Get_index_szrl024(key, id);
            if (pageNum > 0 && pageSize > 0)
            {
                objList = objList.Skip((pageNum - 1) * pageSize).Take(pageSize);
            }
            List<AcceptanceExportObj> meObjList = new List<AcceptanceExportObj>();
            foreach (var obj in objList)
            {
                if (obj != null)
                {
                    meObjList.Add(ConvertAcceptanceExcelObj_szrl033(obj));
                }
            }
            DataTable dt = GlobalService.ToDataTable(meObjList, "验收登记");

            return _excelService.ExportToExcel(dt);
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="obj"></param>
        private AcceptanceExportObj ConvertAcceptanceExcelObj_szrl033(VAcceptancePlanObj obj)
        {
            AcceptanceExportObj exportObj = new AcceptanceExportObj();
            exportObj.rl03404 = obj.rl02403;
            exportObj.rl03405 = Convert.ToString(obj.rl03405);
            exportObj.rl03406 = Convert.ToString(obj.rl03406);
            exportObj.rl03407 = obj.rl03407;
            exportObj.rl03408 = obj.rl03408;
            exportObj.rl03409 = Convert.ToString(obj.rl03409);
            exportObj.rl03410 = obj.rl03410;
            exportObj.rl03411 = obj.rl03411 == 1 ? "外部" : "内部";
            exportObj.rl03412 = obj.rl03412 == 1 ? "已验收" : "未验收";
            exportObj.rl00403 = obj.rl00403;
            exportObj.rl01807 = obj.rl01807;
            exportObj.rl01903 = obj.rl01903;
            exportObj.rl01951 = Convert.ToString(obj.rl01951);
            return exportObj;
        }



        /// <summary>
        /// 取附件数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetAttachFileCount_szrl033(string key)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                return _sdpj004Repository.GetFileCount(key);
            }
        }



        /// <summary>
        /// 获取营业合同目录信息
        /// </summary>
        /// <returns></returns>
        public List<TreeNodeInfo> GetContractDirs(string key, string multi)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                bool isMulti = multi == "1";
                List<TreeNodeInfo> nodeList = new List<TreeNodeInfo>();
                var items = from m in _szrl019Repository.GetModels()
                            join n in _szrl018Repository.GetModels()
                            on m.rl01906 equals n.rl01801
                            join k in _szrl004Repository.GetModels()
                            on n.rl01802 equals k.rl00401
                            join h in _szrl001Repository.GetModels()
                            on k.rl00416 equals h.rl00101
                            join c in _szrl022Repository.GetModels()
                            on m.rl01902 equals c.rl02202
                            join d in _szrl024Repositoty.GetModels()
                            on c.rl02201 equals d.rl02402
                            where k.rl00454 == 1 && k.rl00448 == 1 && k.rl00445 == 1
                                && m.rl01964 == 1 && m.rl01971 == 1
                            select new
                            {
                                F001_id = h.rl00101,
                                F001_name = h.rl00103,
                                F004_id = k.rl00401,
                                F004_name = k.rl00403,
                                F018_id = n.rl01801,
                                F018_name = n.rl01807,
                                F019_id = m.rl01902,
                                F019_name = m.rl01903
                            };

                //var items = from m in _szrl001Repository.GetModels()
                //            join n in _szrl004Repository.GetModels()
                //            on m.rl00101 equals n.rl00416 into mn
                //            from mns in mn.DefaultIfEmpty()
                //            join k in _szrl018Repository.GetModels()
                //            on mns.rl00401 equals k.rl01802 into mnk
                //            from mnks in mnk.DefaultIfEmpty()
                //            join h in _szrl019Repository.GetModels()
                //            on mnks.rl01801 equals h.rl01906 into mnkh
                //            from mnkhs in mnkh.DefaultIfEmpty()
                //            select new
                //            {
                //                F001_id = m.rl00101,
                //                F001_name = m.rl00103,
                //                F004_id = mns.rl00401,
                //                F004_name = mns.rl00403,
                //                F018_id = mnks.rl01801,
                //                F018_name = mnks.rl01803,
                //                F019_id = mnkhs.rl01901,
                //                F019_name = mnkhs.rl01903
                //            };

                var list = items.ToList();

                var item001List = list.Select(x => new { x.F001_id, x.F001_name }).Distinct().OrderBy(x => x.F001_name).ToList();
                TreeNodeInfo newNode;
                foreach (var item001 in item001List) // 区域
                {
                    List<TreeNodeInfo> node004List = new List<TreeNodeInfo>();
                    var item004List = list.Where(x => x.F001_id == item001.F001_id).Select(x => new { x.F004_id, x.F004_name }).Distinct().OrderBy(x => x.F004_name).ToList();
                    foreach (var item004 in item004List) // 顾客
                    {
                        List<TreeNodeInfo> node018List = new List<TreeNodeInfo>();
                        var item018List = list.Where(x => x.F001_id == item001.F001_id && x.F004_id == item004.F004_id).Select(x => new { x.F018_id, x.F018_name }).Distinct().OrderBy(x => x.F018_name).ToList();
                        foreach (var item018 in item018List) // 作番
                        {
                            if (isMulti) // 批量验收登记，只取到作番
                            {
                                newNode = new TreeNodeInfo() { id = item018.F018_id, text = item018.F018_name, children = null, state = "closed", IsLeaf = true };
                            }
                            else // 验收登记，取到合同
                            {
                                List<TreeNodeInfo> node019List = new List<TreeNodeInfo>();
                                var item019List = list.Where(x => x.F001_id == item001.F001_id && x.F004_id == item004.F004_id && x.F018_id == item018.F018_id).Select(x => new { x.F019_id, x.F019_name }).Distinct().OrderBy(x => x.F019_name).ToList();
                                foreach (var item019 in item019List) // 营业合同
                                {
                                    newNode = new TreeNodeInfo() { id = item019.F019_id, text = item019.F019_name, IsLeaf = true, level = 4 };
                                    node019List.Add(newNode);
                                }
                                newNode = new TreeNodeInfo() { id = item018.F018_id, text = item018.F018_name, children = node019List, state = "closed", level = 3 };
                            }
                            node018List.Add(newNode);
                        }
                        newNode = new TreeNodeInfo() { id = item004.F004_id, text = item004.F004_name, children = node018List, state = "closed", level = 2 };
                        node004List.Add(newNode);
                    }

                    newNode = new TreeNodeInfo() { id = item001.F001_id, text = item001.F001_name, children = node004List, state = "closed", level = 1 };
                    nodeList.Add(newNode);
                }

                var topNodeList = new List<TreeNodeInfo>();
                topNodeList.Add(new TreeNodeInfo() { id = "", text = "导航", children = nodeList, level = 0 });

                if (!string.IsNullOrWhiteSpace(key))
                {
                    GlobalService.SearchByKey(topNodeList, key);
                }

                return topNodeList;
            }
        }


        /// <summary>
        /// 取验收计划对应的正式版合同的信息
        /// </summary>
        /// <returns></returns>
        public string GetContractInfo_szrl033(string contractId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                string result = string.Empty;
                var item = _szrl033Repository.GetModels().Where(x => x.rl03302 == contractId).FirstOrDefault();
                if (item == null)
                {
                    var item2 = (from m in _szrl022Repository.GetModels()
                                 join n in _szrl019Repository.GetModels()
                                 on m.rl02202 equals n.rl01902
                                 where n.rl01964 == 1 && m.rl02202 == contractId // 正式版
                                 select n).FirstOrDefault();
                    result = JsonConvert.SerializeObject(item2);
                }
                else
                {
                    result = JsonConvert.SerializeObject(item);
                }
                return result;
            }
        }


        /// <summary>
        /// 获取营业合同目录信息
        /// </summary>
        /// <returns></returns>
        public List<TreeNodeInfo> GetContractDirs2(string id, string key, string multi)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                List<TreeNodeInfo> nodeList = new List<TreeNodeInfo>();
                bool keyFlag = string.IsNullOrWhiteSpace(key);
                bool multiFlag = multi == "1";
                if (string.IsNullOrWhiteSpace(id))
                {
                    List<rlvw_ConTree> list = null;
                    if (multiFlag) // 批量验收，只取到作番
                    {
                        list = _rlvw_ConTreeRepository.GetModels(x => x.iLever < 4).ToList();
                    }
                    else // 非批量验收，取到合同
                    {
                        list = _rlvw_ConTreeRepository.GetModels().ToList();
                    }

                    if (!keyFlag)
                    {
                        var keyIdList = list.Where(x => x.Name != null && x.Name.Contains(key)).Select(x => x.ID).ToArray();
                        List<string> childIdList = new List<string>(), parentIdList = new List<string>();
                        foreach (var keyId in keyIdList)
                        {
                            SearchTreeParent_szrl033(list, keyId, parentIdList, 50);
                            SearchTreeChildren_szrl033(list, keyId, childIdList, 50);
                        }
                        List<string> treeList = keyIdList.Concat(parentIdList).Concat(childIdList).Distinct().ToList();
                        list = list.Where(x => treeList.Contains(x.ID)).ToList();
                    }

                    IEnumerable<rlvw_ConTree> topNodes = list.Where(x => string.IsNullOrWhiteSpace(x.HLever));
                    foreach (var item in topNodes)
                    {
                        var newNode = new TreeNodeInfo() { id = item.ID, text = item.Name };
                        nodeList.Add(newNode);
                        SearchMaterialDir(list, newNode, 50);
                    }
                }
                else
                {
                    var item = _rlvw_ConTreeRepository.GetModels().Where(x => x.ID == id).FirstOrDefault();
                    var newNode = new TreeNodeInfo() { id = item.ID, text = item.Name };
                    nodeList.Add(SearchParentDir_szrl033(item.HLever, newNode, 50));
                }
                var topNodeList = new List<TreeNodeInfo>();
                topNodeList.Add(new TreeNodeInfo() { id = "", text = "导航", children = nodeList });

                return topNodeList;
            }
        }



        /// <summary>
        /// 向树的父节点搜索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="idList"></param>
        /// <param name="count"></param>
        private void SearchTreeParent_szrl033(List<rlvw_ConTree> list, string id, List<string> idList, int count)
        {
            if (count > 0)
            {
                var item = list.Where(x => x.ID == id).FirstOrDefault();
                if (item != null)
                {
                    var parentItem = list.Where(x => x.ID == item.HLever).FirstOrDefault();
                    if (parentItem != null && !idList.Contains(parentItem.ID))
                    {
                        idList.Add(parentItem.ID);
                        SearchTreeParent_szrl033(list, parentItem.ID, idList, count - 1);
                    }
                }
            }
        }

        /// <summary>
        /// 向子节点搜索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <param name="idList"></param>
        /// <param name="count"></param>
        private void SearchTreeChildren_szrl033(List<rlvw_ConTree> list, string id, List<string> idList, int count)
        {
            if (count > 0)
            {
                var childItems = list.Where(x => x.HLever == id).ToArray();
                if (childItems != null)
                {
                    foreach (var childItem in childItems)
                    {
                        if (!idList.Contains(childItem.ID))
                        {
                            idList.Add(childItem.ID);
                            SearchTreeChildren_szrl033(list, childItem.ID, idList, count - 1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 搜索父节点
        /// </summary>
        /// <param name="pId"></param>
        /// <param name="node"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private TreeNodeInfo SearchParentDir_szrl033(string pId, TreeNodeInfo node, int count)
        {
            var item = _rlvw_ConTreeRepository.GetModels().Where(x => x.ID == pId).FirstOrDefault();
            if (item != null && count > 0)
            {
                var newNode = new TreeNodeInfo() { id = item.ID, text = item.Name };
                newNode.children = new List<TreeNodeInfo>() { node };
                node = SearchParentDir_szrl033(item.HLever, newNode, count - 1);
            }
            return node;
        }


        /// <summary>
        /// 搜索子目录
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="node"></param>
        private void SearchMaterialDir(IEnumerable<rlvw_ConTree> queryable, TreeNodeInfo node, int count)
        {
            if (count > 0)
            {
                var list = queryable.Where(x => x.HLever.Equals(node.id));
                List<TreeNodeInfo> nodeList = new List<TreeNodeInfo>();
                foreach (var item in list)
                {
                    nodeList.Add(new TreeNodeInfo() { id = item.ID, text = item.Name, state = "closed" });
                }
                node.children = nodeList.OrderBy(x => x.OrderNo).ToList();
                if (nodeList.Count == 0)
                {
                    node.state = "open";
                    node.IsLeaf = true;
                }

                foreach (var cNode in nodeList)
                {
                    SearchMaterialDir(queryable, cNode, count - 1);
                }
            }
        }

    }
}
