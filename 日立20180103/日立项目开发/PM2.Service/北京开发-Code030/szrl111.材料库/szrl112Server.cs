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
using PM2.Service.Code030.CM;
using PM2.Models.Code030.szrl111Model;
using PM2.Service.Code030.Szrl105Service;

namespace PM2.Service.Code030.szrl111Service
{
    /// <summary>
    /// 供应商信息管理
    /// </summary>
    public class szrl112Server : CmDataService<szrl112>, Iszrl112Server
    {
        #region ================= 属性等 ==================
        private object _lockObj = new object();
        private IDbContextScopeFactory _scopeFactory;
        IEFRepository<szrl112> _szrl112Repository;

        public szrl112Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl112> szrl112Repository
        ) : base(scopeFactory, szrl112Repository)
        {
            this._scopeFactory = scopeFactory;
            this._szrl112Repository = szrl112Repository;
        }

        #endregion


        /// <summary>
        /// 保存材料目录
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public IOperateResult SaveMaterialDir(szrl112 newItem)
        {
            IOperateResult result = null;

            using (var scope = _scopeFactory.CreateScope())
            {
                var limitResult = LimitLevel1And2(newItem);
                if (limitResult != null)
                {
                    return limitResult;
                }

                if (string.IsNullOrWhiteSpace(newItem.rl11201)) // 新增
                {
                    newItem.rl11201 = GlobalService.NewGuid();
                    newItem.rl11211 = GetNewMaterialNo(newItem);
                    newItem.rl11207 = DateTime.Now;
                    newItem.rl11208 = GlobalService.GetLoginUserName();
                    newItem.rl11212 = 0;
                    if (string.IsNullOrWhiteSpace(newItem.rl11214))
                    {
                        var modelList = _szrl112Repository.GetModels(x => x.rl11214 == null).ToArray();
                        if (modelList.Length > 1)
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "材料目录出现多个顶级目录！");
                        }
                        else if (modelList.Length == 0)
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "材料目录未能找到顶级目录！");
                        }
                        else
                        {
                            newItem.rl11214 = modelList[0].rl11201;
                            newItem.rl11202 = modelList[0].rl11204;
                            //result = OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                        }

                    }
                    var parentModel = _szrl112Repository.GetModels().Where(x => x.rl11201 == newItem.rl11214).FirstOrDefault();
                    if (parentModel != null)
                    {
                        newItem.rl11213 = parentModel.rl11213 + parentModel.rl11203;
                        newItem.rl11215 = parentModel.rl11215 + 1;
                    }
                    else
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
                    }

                    //result = Insert(newItem);
                    _szrl112Repository.Add(newItem);
                    scope.SaveChanges();
                }
                else // 修改
                {
                    if (newItem.rl11201 == newItem.rl11214) // 目录的上级目录不能是自己
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "上级目录不能选择自身！");
                    }
                    if (string.IsNullOrWhiteSpace(newItem.rl11213))
                    {
                        newItem.rl11213 = "";
                    }
                    var currentModel = _szrl112Repository.GetModels(x => x.rl11201.Equals(newItem.rl11201)).FirstOrDefault();
                    if (currentModel != null) // 查找当前目录信息
                    {
                        // 已经修改了目录编码， 则更新子节点的上级目录编码（全）
                        if (currentModel.rl11203 != newItem.rl11203)
                        {
                            UpdateParentAllCode(newItem, 50);
                        }
                        // 已经修改了上级目录ID，则更新自己及其子节点的编码
                        if (!currentModel.rl11214.Equals(newItem.rl11214))
                        {
                            UpdateChildMaterial(newItem, 50);
                        }
                        else
                        {
                            _szrl112Repository.Update(newItem);
                        }
                        scope.SaveChanges();
                        result = OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                    }
                }
                //result = Update(newItem);
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null).AddParamsToOperateResult(newItem.rl11201);
        }

        /// <summary>
        /// 限制对一级和二级目录的修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private IOperateResult LimitLevel1And2(szrl112 item)
        {
            if (!string.IsNullOrWhiteSpace(item.rl11201) && item.rl11215 == 0)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "不能编辑“所有分类”目录！");
            }
            // 不再需要限制了
            //bool flag = true;
            //if (!string.IsNullOrWhiteSpace(item.rl11201) && item.rl11215 < 3)
            //{
            //    flag = false;
            //}
            //if (flag)
            //{
            //    var pItem = _szrl112Repository.GetModels(x => x.rl11201 == item.rl11214).FirstOrDefault();
            //    if (pItem != null)
            //    {
            //        if (pItem.rl11215 <= 1)
            //        {
            //            flag = false;
            //        }
            //    }
            //}
            //if (!flag)
            //{
            //    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "无法编辑一二级目录，或上级目录不能选择“所有分类”及一级目录！");
            //}

            return null;
        }

        /// <summary>
        /// 更新下面子节点的编码
        /// </summary>
        /// <param name="item"></param>
        /// <param name="count"></param>
        private void UpdateChildMaterial(szrl112 item, int count)
        {
            if (count > 0)
            {
                // 父节点
                var parentItem = _szrl112Repository.GetModels(x => x.rl11201 == item.rl11214).FirstOrDefault();
                item.rl11215 = parentItem.rl11215 + 1; // 更新目录级别

                // 修改上级目录编码（全）
                item.rl11213 = parentItem.rl11213 + parentItem.rl11203;

                // 不使用内部编码了
                var no = GetNewMaterialNo(item);
                string oldNo = item.rl11211;
                item.rl11211 = no;
                _szrl112Repository.Update(item);

                var childItems = _szrl112Repository.GetModels(x => x.rl11214.Equals(item.rl11201)).ToArray();
                foreach (var childItem in childItems)
                {
                    UpdateChildMaterial(childItem, count - 1);
                }
            }
        }


        /// <summary>
        /// 更新子目录的“上级目录编码（全）”
        /// </summary>
        /// <param name="item"></param>
        private void UpdateParentAllCode(szrl112 parentItem, int count)
        {
            if (count > 0)
            {
                // 子目录
                var models = _szrl112Repository.GetModels(x => x.rl11214 == parentItem.rl11201).ToArray();
                foreach (var model in models)
                {
                    model.rl11213 = parentItem.rl11213 + parentItem.rl11203;
                    _szrl112Repository.Update(model);

                    UpdateParentAllCode(model, count - 1);
                }
            }
        }



        /// <summary>
        /// 取程序内部的目录编码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetNewMaterialNo(szrl112 item)
        {
            string pNo = string.IsNullOrWhiteSpace(item.rl11209) || item.rl11209 == NO_NODE_BASE ? NO_NODE_BASE : item.rl11209;
            int no = GetChildMaxId(pNo) + 1;
            return string.Format("{0}{1}", item == null || pNo == NO_NODE_BASE ? string.Empty : item.rl11209, string.Format("{0}", no).PadLeft(LEN_NO_MAX, '0'));
        }
        /// <summary>
        /// 节点编码长度
        /// </summary>
        private const int LEN_NO_MAX = 5;
        /// <summary>
        /// 节点所有分类的编码
        /// </summary>
        private const string NO_NODE_BASE = "0";


        /// <summary>
        /// 返回当前节点的子节点的最大ID
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        private int GetChildMaxId(string parentCode)
        {
            int maxId = 0;
            lock (_lockObj)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var model = _szrl112Repository.GetModels(x => x.rl11211.Equals(parentCode)).FirstOrDefault();
                    if (model != null)
                    {
                        maxId = model.rl11210;
                        model.rl11210 += 1;
                        _szrl112Repository.Update(model);
                        scope.SaveChanges();
                    }
                }
            }
            return maxId;
        }

        /// <summary>
        /// 插入顶层节点
        /// </summary>
        /// <returns></returns>
        private szrl112 InsertMaterialDirBaseNode(IDbContextScope scope)
        {
            lock (_lockObj)
            {
                szrl112 newItem = new szrl112();
                newItem.rl11201 = GlobalService.NewGuid();
                newItem.rl11203 = "";
                newItem.rl11204 = "所有分类";
                newItem.rl11205 = "";
                newItem.rl11206 = 0;
                newItem.rl11207 = DateTime.Now;
                newItem.rl11208 = GlobalService.GetLoginUserName();
                newItem.rl11210 = 0;
                newItem.rl11211 = NO_NODE_BASE;
                newItem.rl11212 = 0;
                newItem.rl11213 = "";
                newItem.rl11214 = "";
                newItem.rl11215 = 0;
                _szrl112Repository.Add(newItem);
                scope.SaveChanges();
                return newItem;
            }
        }


        /// <summary>
        /// 删除材料目录
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IOperateResult RemoveMaterialDir(string id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var item = _szrl112Repository.GetModels(x => x.rl11201.Equals(id)).FirstOrDefault();
                if (item != null)
                {
                    var limitResult = LimitLevel1And2(item);
                    if (limitResult != null)
                    {
                        return limitResult;
                    }

                    RemoveChildMaterialDir(item.rl11201);
                    _szrl112Repository.Remove(item);
                    scope.SaveChanges();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
            }
        }

        /// <summary>
        /// 删除子项
        /// </summary>
        /// <param name="id"></param>
        private void RemoveChildMaterialDir(string id)
        {
            var items = _szrl112Repository.GetModels(x => x.rl11214.Equals(id)).ToArray();
            foreach (var item in items)
            {
                RemoveMaterialDir(item.rl11201);
                _szrl112Repository.Remove(item);
            }
        }


        /// <summary>
        /// 获取材料目录信息
        /// </summary>
        /// <returns></returns>
        public List<TreeNodeInfo> GetMaterialDirs(string key, bool allFlag)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                List<TreeNodeInfo> nodeList = new List<TreeNodeInfo>();
                var list = _szrl112Repository.GetModels().ToList();
                szrl112 topItem = null;
                if (!allFlag)
                {
                    topItem = list.Where(x => x.rl11215 == 0 && x.rl11204 == "所有分类").FirstOrDefault();
                    if (topItem != null)
                    {
                        list.Remove(topItem);
                    }
                }
                if (list.Count == 0)
                {
                    var item = InsertMaterialDirBaseNode(scope);
                    list.Add(item);
                }

                #region 原有的搜索机制，使用内部编码，不再使用
                //var searchList = list;
                //if (!string.IsNullOrWhiteSpace(key)) // 查找带关键字的节点
                //{
                //    var codeList = list.Where(x => x.rl11203.Contains(key) || x.rl11204.Contains(key)).Select(x => x.rl11211).ToList();
                //    var tempList = new List<string>();
                //    foreach (var code in codeList)
                //    {
                //        // 向上查找
                //        string tempCode = code;
                //        while (tempCode.Length - LEN_NO_MAX > 0)
                //        {
                //            tempCode = tempCode.Substring(0, tempCode.Length - LEN_NO_MAX);
                //            if (!codeList.Contains(tempCode))
                //            {
                //                tempList.Add(tempCode);
                //            }
                //        }
                //    }
                //    codeList = codeList.Concat(tempList).ToList();
                //    tempList = new List<string>();
                //    // （叶子节点）向下查找
                //    foreach (var code in codeList)
                //    {
                //        var count = codeList.Where(x => x.StartsWith(code)).Count();
                //        if (count == 1)
                //        {
                //            var childCodeList = list.Where(x => x.rl11211.StartsWith(code)).Select(x => x.rl11211).ToArray();
                //            foreach (var childCode in childCodeList)
                //            {
                //                if (!codeList.Contains(childCode) && !tempList.Contains(childCode))
                //                {
                //                    tempList.Add(childCode);
                //                }
                //            }
                //        }
                //    }
                //    codeList = codeList.Concat(tempList).ToList();
                //    searchList = list.Where(x => codeList.Contains(x.rl11211)).ToList();
                //}
                #endregion

                IEnumerable<szrl112> topNodes = null;
                if (!allFlag && topItem != null)
                {
                    topNodes = list.Where(x => x.rl11214 == topItem.rl11201);
                }
                else
                {
                    //topNodes = list.Where(x => string.IsNullOrWhiteSpace(x.rl11209));
                    topNodes = list.Where(x => string.IsNullOrWhiteSpace(x.rl11214) && x.rl11215 == 0);
                }
                topNodes = topNodes.OrderBy(x => x.rl11206);
                foreach (var item in topNodes)
                {
                    var newNode = new TreeNodeInfo() { id = item.rl11201, pid = item.rl11214, text = item.rl11204, code = item.rl11211, OrderNo = item.rl11206 };
                    nodeList.Add(newNode);
                    SearchMaterialDir(list, newNode, 50);
                }

                // 搜索树
                if (!string.IsNullOrWhiteSpace(key))
                {
                    GlobalService.SearchByKey(nodeList, key);
                }

                //TreeNodeInfo topNode = new TreeNodeInfo() { id = "", text = "所有分类", children = nodeList.OrderBy(x => x.OrderNo).ToList() };
                //nodeList = new List<TreeNodeInfo>();
                //nodeList.Add(topNode);

                return nodeList;
            }
        }


        /// <summary>
        /// 搜索子目录
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="node"></param>
        private void SearchMaterialDir(IEnumerable<szrl112> queryable, TreeNodeInfo node, int count)
        {
            if (count > 0)
            {
                var list = queryable.Where(x => x.rl11214 == node.id);
                List<TreeNodeInfo> nodeList = new List<TreeNodeInfo>();
                foreach (var item in list)
                {
                    nodeList.Add(new TreeNodeInfo() { id = item.rl11201, pid = item.rl11214, text = item.rl11204, code = item.rl11211, state = "closed", OrderNo = item.rl11206 });
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
