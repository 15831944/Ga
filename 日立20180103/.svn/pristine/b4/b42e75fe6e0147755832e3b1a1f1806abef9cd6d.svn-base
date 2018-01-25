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
using PM2.Models.Code030.Szrl105Model;
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code030.Szrl105Service;
using System.Data;
using System.IO;
using System.Web.Mvc;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030.szrl111Service
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class szrl111Server : CmDataService<szrl111>, Iszrl111Server
    {
        #region ================= 属性等 ==================
        private object _lockObj = new object();
        private IDbContextScopeFactory _scopeFactory;
        IEFRepository<szrl111> _szrl111Repository;
        IEFRepository<szrl112> _szrl112Repository;
        IEFRepository<sdpa013> _sdpa013Repository;
        IExcelService _excelService;
        public szrl111Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl111> szrl111Repository,
             IEFRepository<szrl112> szrl112Repository,
        IEFRepository<sdpa013> sdpa013Repository,
             IExcelService excelService
        ) : base(scopeFactory, szrl111Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl111Repository = szrl111Repository;
            this._szrl112Repository = szrl112Repository;
            this._sdpa013Repository = sdpa013Repository;
            this._excelService = excelService;
        }

        #endregion


        /// <summary>
        /// 保存材料信息
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public IOperateResult SaveMaterial(szrl111 newItem, string attachFileId)
        {
            if (newItem != null)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    if (string.IsNullOrWhiteSpace(newItem.rl11101)) // 新增材料信息
                    {
                        if (!string.IsNullOrWhiteSpace(attachFileId)) // 使用附件ID做材料ID
                        {
                            newItem.rl11101 = attachFileId;
                        }
                        if (string.IsNullOrWhiteSpace(newItem.rl11103)) // 材料编码为空，则按规则生成
                        {
                            newItem.rl11103 = CreateMaterialCode(newItem.rl11102);
                        }
                        var count = _szrl111Repository.GetModels(x => x.rl11103.Equals(newItem.rl11103)).Count();
                        if (count == 0)
                        {
                            newItem.rl11111 = DateTime.Now;
                            newItem.rl11112 = GlobalService.GetLoginUserName();

                            _szrl111Repository.Add(newItem);
                        }
                        else // 材料编码唯一
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, string.Format("材料编码“{0}”已存在，无法添加！", newItem.rl11103), newItem.rl11103);
                        }
                    }
                    else // 修改材料信息
                    {
                        if (string.IsNullOrWhiteSpace(newItem.rl11103)) // 材料编码为空，则按规则生成
                        {
                            newItem.rl11103 = CreateMaterialCode(newItem.rl11102);
                        }
                        _szrl111Repository.Update(newItem);
                    }
                    scope.SaveChanges();
                }
                var newItemJson = Newtonsoft.Json.JsonConvert.SerializeObject(newItem);
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "", newItemJson);
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
        }



        /// <summary>
        /// 删除材料
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult RemoveMaterial(szrl111 item)
        {
            return Delete(item);
        }


        /// <summary>
        /// 修改材料的材料目录
        /// </summary>
        /// <param name="id">材料ID</param>
        /// <param name="dirId">材料目录ID</param>
        /// <returns></returns>
        public IOperateResult ChangeMaterialDir(string id, string dirId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var model = _szrl111Repository.GetModels(x => x.rl11101.Equals(id)).FirstOrDefault();
                if (model != null)
                {
                    model.rl11102 = dirId;
                    _szrl111Repository.Update(model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }


        /// <summary>
        /// 取全部计量单位
        /// </summary>
        /// <returns></returns>
        public IEnumerable<sdpa013> GetMeasureUnits()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var list = _sdpa013Repository.GetModels().ToArray();
                return list;
            }
        }

        /// <summary>
        /// EXCEL导入数据
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        public IOperateResult ImportDataByExcel(MaterialExcel excel)
        {
            if (excel != null)
            {
                try
                {
                    ImportExcelInfo info = new ImportExcelInfo() { ExcelFilePath = excel.ExcelFilePath, DataRange = excel.DataRange, SheetName = excel.ExcelWookSheet };
                    DataTable dt = _excelService.ImportData(info);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var currentDt = DateTime.Now;
                            var name = GlobalService.GetLoginUserName();

                            // 添加到数据库
                            List<szrl111> itemList = new List<szrl111>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                var item = new szrl111();
                                item.rl11101 = GlobalService.NewGuid();
                                item.rl11102 = Convert.ToString(dr[excel.rl11102]).Trim();
                                item.rl11103 = Convert.ToString(dr[excel.rl11103]).Trim();
                                item.rl11104 = Convert.ToString(dr[excel.rl11104]);
                                item.rl11105 = Convert.ToString(dr[excel.rl11105]);
                                item.rl11106 = Convert.ToString(dr[excel.rl11106]);
                                item.rl11107 = Convert.ToString(dr[excel.rl11107]);
                                item.rl11108 = Convert.ToString(dr[excel.rl11108]);
                                item.rl11109 = Convert.ToString(dr[excel.rl11109]).Trim();
                                item.rl11111 = currentDt;
                                item.rl11112 = name;

                                if (string.IsNullOrWhiteSpace(item.rl11104) || string.IsNullOrWhiteSpace(item.rl11109))
                                {
                                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "材料名称和计量单位不能为空！");
                                }
                                var count = itemList.Where(x => x.rl11103.Equals(item.rl11103)).Count();
                                if (count > 0)
                                {
                                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, string.Format("EXCEL中材料编码“{0}”存在多个，无法添加！", item.rl11103), item.rl11103);
                                }
                                if (string.IsNullOrWhiteSpace(item.rl11102) || string.IsNullOrWhiteSpace(item.rl11103))
                                {
                                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "EXCEL中材料分类或材料编码不能为空，无法添加！");
                                }
                                itemList.Add(item);
                            }

                            // 材料目录是否存在
                            List<string> existCodeList = new List<string>();
                            List<string> materialDirCodeList = itemList.Select(x => x.rl11102).Distinct().ToList();
                            foreach (var dirCode in materialDirCodeList)
                            {
                                //var model = _szrl112Repository.GetModels(x => (x.rl11213 + x.rl11203) == dirCode).FirstOrDefault();
                                var model = _szrl112Repository.GetModels(x => x.rl11203.Equals(dirCode)).FirstOrDefault();
                                if (model == null) // 材料分类编码不存在
                                {
                                    existCodeList.Add(dirCode);
                                }
                                else // 材料分类存在，则修改为材料分类ID
                                {
                                    var models = itemList.Where(x => x.rl11102.Equals(dirCode));
                                    foreach (var model2 in models)
                                    {
                                        model2.rl11102 = model.rl11201;
                                    }
                                }
                            }
                            if (existCodeList.Count > 0)
                            {
                                string codes = existCodeList.JoinToString("、");
                                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, string.Format("材料分类编码“{0}”不存在，无法添加！", codes), codes);
                            }

                            // 检测材料编码是否存在
                            existCodeList = new List<string>();
                            string code = string.Empty;
                            foreach (var item in itemList)
                            {
                                // 材料编码是否存在
                                code = item.rl11103;
                                int count = _szrl111Repository.GetModels(x => x.rl11103.Equals(code)).Count();
                                if (count > 0) // 材料编码已存在
                                {
                                    existCodeList.Add(code);
                                }
                            }
                            if (existCodeList.Count > 0)
                            {
                                string codes = existCodeList.JoinToString("、");
                                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, string.Format("材料编码“{0}”已存在，无法添加！", codes), codes);
                            }

                            // 计量单位名称是否存在
                            existCodeList = new List<string>();
                            List<string> unitNameList = itemList.Select(x => x.rl11109).Distinct().ToList();
                            foreach (var unitName in unitNameList)
                            {
                                var model = _sdpa013Repository.GetModels(x => x.pa01302.Equals(unitName)).FirstOrDefault();
                                if (model == null) // 不存在该计量单位
                                {
                                    existCodeList.Add(unitName);
                                }
                                else // 计量单位名称存在，则修改为计量单位编码
                                {
                                    var models = itemList.Where(x => x.rl11109.Equals(unitName));
                                    foreach (var model2 in models)
                                    {
                                        model2.rl11109 = model.pa01301;
                                    }
                                }
                            }
                            if (existCodeList.Count > 0)
                            {
                                string codes = existCodeList.JoinToString("、");
                                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, string.Format("计量单位“{0}”不存在，无法添加！", codes), codes);
                            }

                            foreach (var item in itemList)
                            {
                                _szrl111Repository.Add(item);
                                var models = _szrl112Repository.GetModels(x => x.rl11203 == item.rl11102).ToArray();
                                foreach (var model in models)
                                {
                                    model.rl11212 += 1;
                                    _szrl112Repository.Update(model);
                                }
                            }
                            scope.SaveChanges();

                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                        }
                    }
                    else
                    {
                        OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "未在EXCEL中找到相应的数据导入！");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "导入失败");
        }

        /// <summary>
        /// 查询材料
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<VMaterialObj> Search_szrl111(PagerInfo info, string key, string dirId)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                string code = string.Empty;
                bool nullDirFlag = string.IsNullOrWhiteSpace(dirId);
                List<string> dirIds = new List<string>();
                if (!nullDirFlag)
                {
                    code = _szrl112Repository.GetModels().Where(x => x.rl11201.Equals(dirId)).Select(x => x.rl11211).FirstOrDefault();
                    dirIds = _szrl112Repository.GetModels().Where(x => x.rl11211.StartsWith(code)).Select(x => x.rl11201).ToList();
                }
                if (string.IsNullOrWhiteSpace(key))
                {
                    //var items =  _szrl111Repository.GetModels().Where(x => (!nullDirFlag && dirIds.Contains(x.rl11102)) || nullDirFlag).ToArray();
                    var items = (from m in _szrl111Repository.GetModels()
                                 join n in _szrl112Repository.GetModels()
                                 on m.rl11102 equals n.rl11201
                                 join h in _sdpa013Repository.GetModels()
                                 on m.rl11109 equals h.pa01301
                                 where (!nullDirFlag && dirIds.Contains(m.rl11102)) || nullDirFlag
                                 select new VMaterialObj
                                 {
                                     rl11101 = m.rl11101,
                                     rl11102 = m.rl11102,
                                     rl11103 = m.rl11103,
                                     rl11104 = m.rl11104,
                                     rl11105 = m.rl11105,
                                     rl11106 = m.rl11106,
                                     rl11107 = m.rl11107,
                                     rl11108 = m.rl11108,
                                     rl11109 = m.rl11109,
                                     rl11110 = m.rl11110,
                                     rl11111 = m.rl11111,
                                     rl11112 = m.rl11112,
                                     MaterialDirName = n.rl11204,
                                     MeasureUnitName = h.pa01302
                                 }).OrderByDescending(x => x.rl11111).ToList();
                    return items;
                }
                else
                {
                    var items = (from m in _szrl111Repository.GetModels()
                                 join n in _szrl112Repository.GetModels()
                                 on m.rl11102 equals n.rl11201
                                 join h in _sdpa013Repository.GetModels()
                                 on m.rl11109 equals h.pa01301
                                 where (((!nullDirFlag && dirIds.Contains(m.rl11102)) || nullDirFlag) && (m.rl11103.Contains(key) || m.rl11104.Contains(key)
                                        || (m.rl11105 != null && m.rl11105.Contains(key)) || (m.rl11106 != null && m.rl11106.Contains(key))
                                        || (m.rl11107 != null && m.rl11107.Contains(key)) || (m.rl11108 != null && m.rl11108.Contains(key))
                                        || m.rl11109.Contains(key) || (m.rl11110 != null) && m.rl11110.Contains(key)))
                                 select new VMaterialObj
                                 {
                                     rl11101 = m.rl11101,
                                     rl11102 = m.rl11102,
                                     rl11103 = m.rl11103,
                                     rl11104 = m.rl11104,
                                     rl11105 = m.rl11105,
                                     rl11106 = m.rl11106,
                                     rl11107 = m.rl11107,
                                     rl11108 = m.rl11108,
                                     rl11109 = m.rl11109,
                                     rl11110 = m.rl11110,
                                     rl11111 = m.rl11111,
                                     rl11112 = m.rl11112,
                                     MaterialDirName = n.rl11204,
                                     MeasureUnitName = h.pa01302
                                 }).ToList();
                    //var list = _szrl111Repository.GetModels(x => (((!nullDirFlag && dirIds.Contains(x.rl11102)) || nullDirFlag) && (x.rl11103.Contains(key) || x.rl11104.Contains(key)
                    //                    || (x.rl11105 != null && x.rl11105.Contains(key)) || (x.rl11106 != null && x.rl11106.Contains(key))
                    //                    || (x.rl11107 != null && x.rl11107.Contains(key)) || (x.rl11108 != null && x.rl11108.Contains(key))
                    //                    || x.rl11109.Contains(key) || (x.rl11110 != null) && x.rl11110.Contains(key)))).ToArray();
                    return items;
                }
            }
        }

        /// <summary>
        /// 取材料信息
        /// </summary>
        /// <param name="info">分页</param>
        /// <param name="key">关键字</param>
        /// <param name="dirId">目录ID</param>
        /// <returns></returns>
        public PagerResult SearchForPager_szrl111(PagerInfo info, string key, string dirId)
        {
            List<VMaterialObj> items = Search_szrl111(info, key, dirId);
            PagerResult result = new PagerResult();
            result.total = items.Count;
            result.rows = items.Skip((info.page - 1) * info.rows).Take(info.rows);
            return result;
        }

        private VMaterialObj Convert_szrl111(szrl111 item)
        {
            VMaterialObj obj = new VMaterialObj();
            obj.rl11101 = item.rl11101;
            obj.rl11102 = item.rl11102;
            obj.rl11103 = item.rl11103;
            obj.rl11104 = item.rl11104;
            obj.rl11105 = item.rl11105;
            obj.rl11106 = item.rl11106;
            obj.rl11107 = item.rl11107;
            obj.rl11108 = item.rl11108;
            obj.rl11109 = item.rl11109;
            obj.rl11110 = item.rl11110;
            obj.rl11111 = item.rl11111;
            obj.rl11112 = item.rl11112;
            return obj;
        }


        private MaterialExportObj ConvertMaterialExcelObj_szrl111(VMaterialObj obj)
        {
            MaterialExportObj meObj = new MaterialExportObj();
            meObj.MeasureUnitName = obj.MeasureUnitName;
            meObj.rl11103 = obj.rl11103;
            meObj.rl11104 = obj.rl11104;
            meObj.rl11105 = obj.rl11105;
            meObj.rl11106 = obj.rl11106;
            meObj.rl11107 = obj.rl11107;
            meObj.rl11108 = obj.rl11108;
            meObj.rl11110 = obj.rl11110;
            return meObj;
        }

        /// <summary>
        /// 导出到EXCEL
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="dirId">目录ID</param>
        /// <param name="pageNum">当前页码</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        public MemoryStream ExportExcel_szrl111(string key, string dirId, int pageNum, int pageSize)
        {
            IEnumerable<VMaterialObj> objList = Search_szrl111(null, key, dirId);
            if (pageNum > 0 && pageSize > 0)
            {
                objList = objList.Skip((pageNum - 1) * pageSize).Take(pageSize);
            }
            List<MaterialExportObj> meObjList = new List<MaterialExportObj>();
            foreach (var obj in objList)
            {
                if (obj != null)
                {
                    meObjList.Add(ConvertMaterialExcelObj_szrl111(obj));
                }
            }
            DataTable dt = GlobalService.ToDataTable(meObjList, "材料信息");

            return _excelService.ExportToExcel(dt);
        }


        /// <summary>
        /// 取材料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VMaterialObj Get_szrl111(string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var item = (from m in _szrl111Repository.GetModels()
                            join n in _szrl112Repository.GetModels()
                            on m.rl11102 equals n.rl11201
                            where m.rl11101 == id
                            select new VMaterialObj
                            {
                                rl11101 = m.rl11101,
                                rl11102 = m.rl11102,
                                rl11103 = m.rl11103,
                                rl11104 = m.rl11104,
                                rl11105 = m.rl11105,
                                rl11106 = m.rl11106,
                                rl11107 = m.rl11107,
                                rl11108 = m.rl11108,
                                rl11109 = m.rl11109,
                                rl11110 = m.rl11110,
                                rl11111 = m.rl11111,
                                rl11112 = m.rl11112,
                                MaterialDirName = n.rl11204
                            }).FirstOrDefault();

                return item;
            }
        }


        /// <summary>
        /// 取材料编码
        /// </summary>
        /// <param name="materialDirId">材料目录ID</param>
        /// <returns></returns>
        public string CreateMaterialCode(string materialDirId)
        {
            lock (_lockObj)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    string code = GetNewMaterialCode(materialDirId, 1000);
                    scope.SaveChanges();

                    return code;
                }
            }
        }

        /// <summary>
        /// 取新的材料编码
        /// </summary>
        /// <param name="materialDirId"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private string GetNewMaterialCode(string materialDirId, int level)
        {
            string code = string.Empty;
            if (level > 0)
            {
                var dirModel = _szrl112Repository.GetModels(x => x.rl11201.Equals(materialDirId)).FirstOrDefault();
                if (dirModel != null)
                {
                    // 编码规则，上级目录编码（全） + 本级目录编码 + 流水号
                    //code = string.Format("{0}{1}{2}", dirModel.rl11213, dirModel.rl11203, (dirModel.rl11212 + 1).ToString().PadLeft(4, '0'));
                    code = string.Format("{0}{1}", dirModel.rl11203, (dirModel.rl11212 + 1).ToString().PadLeft(4, '0'));
                    dirModel.rl11212 += 1;
                    _szrl112Repository.Update(dirModel);

                    var count = _szrl111Repository.GetModels(x => x.rl11103.Equals(code)).Count();
                    if (count > 0)
                    {
                        code = GetNewMaterialCode(materialDirId, level - 1);
                    }
                }
            }
            return code;
        }

    }
}
