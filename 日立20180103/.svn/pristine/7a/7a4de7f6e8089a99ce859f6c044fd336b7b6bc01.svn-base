using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.Extensions;
using PM2.Models.Code030;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using PM2.Models.Code001;
using Gmail.DDD.JsonConvert;
using PM2.Code;
using Gmail.DDD.Mvc;
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030
{
    public class szrl001Tree : EasyTreeBase
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl001> _szrl001Repository;
        private IEFRepository<szrl004> _szrl004Repository;
        private IEFRepository<szrl018> _szrl018Repository;
        private IEFRepository<szrl025> _szrl025Repository;
        private IEFRepository<szrl019> _szrl019Repository;
        private IEFRepository<szrl022> _szrl022Repository;
        public szrl001Tree(
            IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl001> szrl001Repository,
             IEFRepository<szrl004> szrl004Repository,
             IEFRepository<szrl018> szrl018Repository,
              IEFRepository<szrl025> szrl025Repository,
              IEFRepository<szrl019> szrl019Repository,
              IEFRepository<szrl022> szrl022Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._szrl001Repository = szrl001Repository;
            this._szrl004Repository = szrl004Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl025Repository = szrl025Repository;
            this._szrl019Repository = szrl019Repository;
            this._szrl022Repository = szrl022Repository;
        }
        /// <summary>
        /// 获取作番树形结构图数据(区域-客户-作番(立项))
        /// select * from szrl001--区域
        ///select* from szrl004--客户
        ///select* from szrl018--作番
        /// </summary>
        /// <returns></returns>
        public override IOperateResult TreeLoad(IRequestGetter rGetter = null)
        {
            
            string _forsome = rGetter.GetValue<string>("forsome");
            Forsome fs = new Forsome();
            int[] rl01827s = _forsome == "0" ? fs.Executed : _forsome == "1" ? fs.ExternalActuarial : fs.Whole;
            IEnumerable <IEasyTreeNode> szrl001 = null;
            IEnumerable<IEasyTreeNode> szrl004 = null;
            IEnumerable<IEasyTreeNode> szrl018 = null;
            int _budgetimple = rGetter.GetValue<int>("budgetimple");//是否实行预算 :0 否 ; 1 是
            int _IsGuoLvChengRen = rGetter.GetValue<int>("IsGuoLvChengRen"); //是否过滤承认数据， 0: 否； 1:是；
            #region 获取区域
            using (IDbContextReadOnlyScope scope=this._scopeFactory.CreateReadOnlyScope())
            {
                string[] rl01801s = null;
                string[] rl01802s = null;
                switch (_budgetimple)
                {
                    case 0:
                        rl01801s = this._szrl018Repository.GetModels(x => x.rl01832.Equals(1)).Select(x => x.rl01801).ToArray();
                        rl01802s = this._szrl018Repository.GetModels(x => x.rl01832.Equals(1) && rl01827s.Contains(x.rl01827) && rl01801s.Contains(x.rl01801)).Select(x => x.rl01802).ToArray();
                        break;
                    case 1://实行预算时查询存在受注传票的作番
                        rl01801s = this._szrl025Repository.GetModels(x => x.rl02532.Equals(1) && x.rl02503.Equals("0")).Select(x => x.rl02501).ToArray();//查询承认的初回受注传票的作番id
                        rl01802s = this._szrl018Repository.GetModels(x => x.rl01832.Equals(1) && rl01827s.Contains(x.rl01827) && rl01801s.Contains(x.rl01801)).Select(x => x.rl01802).ToArray();
                        break;
                }
                string[] rl00416s = this._szrl004Repository.GetModels(x => x.rl00445.Equals(1) && x.rl00454.Equals(1) && rl01802s.Contains(x.rl00401)).Select(x => x.rl00416).ToArray();
                szrl001 = this._szrl001Repository.GetModels(x => rl00416s.Contains(x.rl00101)).Select(
                    x => new EasyTreeNode {
                        ID = x.rl00101,
                        Text = x.rl00103,
                        ParentId = null,
                        OrderBy=x.rl00102,
                        Params=new { nodeType="szrl001" }
                    }
                 ).GroupBy(x => x.Text).Select(t => t.FirstOrDefault()).ToArray();
            string[] rl00101 = szrl001.Select(x => x.ID).ToArray();
            #endregion
            #region 获取客户信息
                szrl004 = this._szrl004Repository.GetModels(x => rl00101.Contains(x.rl00416)
                && x.rl00445.Equals(1) 
                && x.rl00454.Equals(1)
                && rl01802s.Contains(x.rl00401)).Select(
                    x => new EasyTreeNode
                    {
                        ID = x.rl00401,
                        Text = x.rl00403,
                        ParentId = string.IsNullOrEmpty(x.rl00416) ? x.rl00401:x.rl00416,
                        OrderBy = x.rl00402,
                        Params = new { nodeType = "szrl004" }
                    }
                 ).GroupBy(x=>x.Text).Select(t => t.FirstOrDefault()).ToArray();
                string[] rl00401 = szrl004.Select(x => x.ID).ToArray();
                #endregion
                #region 获取作番信息
                switch (_IsGuoLvChengRen)
                {
                    case 0:
                        szrl018 = this._szrl018Repository.GetModels(x => rl01801s.Contains(x.rl01801) && rl01802s.Contains(x.rl01802) && rl00401.Contains(x.rl01802) && x.rl01832.Equals(1) && rl01827s.Contains(x.rl01827)).Select(
                                    x => new EasyTreeNode
                                    {
                                        ID = x.rl01801,
                                        Text = x.rl01807,
                                        ParentId = string.IsNullOrEmpty(x.rl01802) ? x.rl01801 : x.rl01802,
                                        OrderBy = x.rl01806,
                                        Params = new { nodeType = x.rl01801 }
                                    }
                                 ).GroupBy(x => x.Text).Select(t => t.FirstOrDefault()).ToArray();
                        break;
                    case 1:
                        szrl018 = (from a in this._szrl018Repository.GetModels(x => rl01801s.Contains(x.rl01801) && rl01802s.Contains(x.rl01802) && rl00401.Contains(x.rl01802) && x.rl01832.Equals(1) && rl01827s.Contains(x.rl01827))
                                  join b in this._szrl019Repository.GetModels(b => b.rl01971 == 1 && b.rl01964 == 1)
                                  on a.rl01801 equals b.rl01906
                                  join c in this._szrl022Repository.GetModels(c => c.rl02208 == 1 && c.rl02213 == 1)
                                  on b.rl01902 equals c.rl02202
                                  select new EasyTreeNode
                                  {
                                      ID = a.rl01801,
                                      Text = a.rl01807,
                                      ParentId = string.IsNullOrEmpty(a.rl01802) ? a.rl01801 : a.rl01802,
                                      OrderBy = a.rl01806,
                                      Params = new { nodeType = a.rl01801 }
                                  }).GroupBy(a=>a.Text).Select(t => t.FirstOrDefault()).ToArray();
                        break;
                }
               
            }
            #endregion
            IEnumerable<IEasyTreeNode> EasyTreeNodes = szrl001.Concat(szrl004).Concat(szrl018);
            if (this.TreeExtensions != null)
                EasyTreeNodes = this.TreeExtensions.Addition(EasyTreeNodes);
            return OperateResultFactory.TreeOperateResult(EasyTreeNodes, "作番导航");
        }

    }
}
