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
using Gmail.DDD.Mvc;
using Gmail.DDD.PagedList;

namespace PM2.Service.Code030
{
    public class sdbo001Server : Isdbo001Server
    {
        //select * from  sdpj004 where pj00412=1
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdbo001> _sdbo001Repository;
        private IEFRepository<sdbo002> _sdbo002Repository;
        private IEFRepository<szrl018> _szrl018Repository;
        private IEFRepository<sdpj003> _sdpj003Repository;
        private IEFRepository<sdpj004> _sdpj004Repository;
        private IEFRepository<sdbo004> _sdbo004Repository;
        private IEFRepository<sdbo005> _sdbo005Repository;
        public sdbo001Server(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdbo001> sdbo001Repository,
            IEFRepository<sdbo002> sdbo002Repository,
            IEFRepository<szrl018> szrl018Repository,
            IEFRepository<sdbo004> sdbo004Repository,
            IEFRepository<sdbo005> sdbo005Repository,
            IEFRepository<sdpj003> sdpj003Repository,
            IEFRepository<sdpj004> sdpj004Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._sdbo001Repository = sdbo001Repository;
            this._sdbo002Repository = sdbo002Repository;
            this._szrl018Repository = szrl018Repository;
            this._sdpj003Repository = sdpj003Repository;
            this._sdpj004Repository = sdpj004Repository;
            this._sdbo004Repository = sdbo004Repository;
            this._sdbo005Repository = sdbo005Repository;
        }


        /// <summary>
        /// 查询人员
        /// </summary>
        /// <returns></returns>
        public IOperateResult List_sdpj004(IPageContext context)
        {
            try
            {
                IPagedList pagedList = null;
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IQueryable<sdpj004> query_sdpj004 = this._sdpj004Repository.GetModels(x => x.pj00412.Equals(1)).OrderBy(o=>o.pj00421);
                    pagedList = query_sdpj004.ToPagedList<sdpj004>(context);
                    return OperateResultFactory.GridOperateResult(pagedList);
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.GridOperateResult(new List<sdpj004>());
            }
        }



        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public IOperateResult GetIndexInfo(IRequestGetter context)
        {
            string zuofanid = context.GetValue<string>("zuofanid");
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IEnumerable<sdbo004> query_sdbo004 = this._sdbo004Repository.GetModels(x => x.bo00402.Equals(zuofanid));
                    IEnumerable<sdbo005> query_sdbo005 = this._sdbo005Repository.GetModels(x => x.bo00502.Equals(zuofanid));
                    Staffing_sdbo004 sf = CombinatorialEntity(query_sdbo004, query_sdbo005, zuofanid);
                    sf.bo00102 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(zuofanid)).Select(x => x.rl01806).FirstOrDefault();//作番编号
                    sf.bo00103 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(zuofanid)).Select(x => x.rl01807).FirstOrDefault();//作番名称
                    return OperateResultFactory.FromLoadOperateResult(sf);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 断点赋值
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <param name="zuofanid"></param>
        /// <returns></returns>
        private Staffing_sdbo004 CombinatorialEntity(IEnumerable<sdbo004> _a, IEnumerable<sdbo005> _b, string zuofanid)
        {
            try
            {
                    Staffing_sdbo004 sf = new Staffing_sdbo004();
                    #region 现场 审批
                    sf.bo00104 = _a.Where(x => x.bo00405.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00105 = _a.Where(x => x.bo00405.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00106 = _a.Where(x => x.bo00405.Equals(2) && x.bo00407.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00107 = _a.Where(x => x.bo00405.Equals(2) && x.bo00407.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00108 = _a.Where(x => x.bo00405.Equals(2) && x.bo00407.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00109 = _a.Where(x => x.bo00405.Equals(2) && x.bo00407.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00110 = _a.Where(x => x.bo00405.Equals(1) && x.bo00407.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00111 = _a.Where(x => x.bo00405.Equals(1) && x.bo00407.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00112 = _a.Where(x => x.bo00405.Equals(1) && x.bo00407.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00113 = _a.Where(x => x.bo00405.Equals(1) && x.bo00407.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00114 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(1) && x.bo00408.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00115 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(1) && x.bo00408.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00116 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(1) && x.bo00408.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00117 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(1) && x.bo00408.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00118 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(1) && x.bo00408.Equals(5)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00119 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(2) && x.bo00408.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00120 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(2) && x.bo00408.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00121 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(2) && x.bo00408.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00122 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(2) && x.bo00408.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00123 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(2) && x.bo00408.Equals(5)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00124 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(3) && x.bo00408.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00125 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(3) && x.bo00408.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00126 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(3) && x.bo00408.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00127 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(3) && x.bo00408.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00128 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(3) && x.bo00408.Equals(5)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00129 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(4) && x.bo00408.Equals(1)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00130 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(4) && x.bo00408.Equals(2)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00131 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(4) && x.bo00408.Equals(3)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00132 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(4) && x.bo00408.Equals(4)).Select(x => x.bo00406).FirstOrDefault();
                    sf.bo00133 = _a.Where(x => x.bo00405.Equals(0) && x.bo00407.Equals(4) && x.bo00408.Equals(5)).Select(x => x.bo00406).FirstOrDefault();
                    #endregion
                    #region 非现场审批
                    sf.bo00134 = _b.Where(x => x.bo00505.Equals(3) && x.bo00507.Equals(0)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00135 = _b.Where(x => x.bo00505.Equals(2) && x.bo00507.Equals(0)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00136 = _b.Where(x => x.bo00505.Equals(1) && x.bo00507.Equals(0)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00137 = _b.Where(x => x.bo00505.Equals(0) && x.bo00507.Equals(0)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00138 = _b.Where(x => x.bo00505.Equals(3) && x.bo00507.Equals(1)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00139 = _b.Where(x => x.bo00505.Equals(2) && x.bo00507.Equals(1)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00140 = _b.Where(x => x.bo00505.Equals(1) && x.bo00507.Equals(1)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00141 = _b.Where(x => x.bo00505.Equals(0) && x.bo00507.Equals(1)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00142 = _b.Where(x => x.bo00505.Equals(3) && x.bo00507.Equals(2)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00143 = _b.Where(x => x.bo00505.Equals(2) && x.bo00507.Equals(2)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00144 = _b.Where(x => x.bo00505.Equals(1) && x.bo00507.Equals(2)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00145 = _b.Where(x => x.bo00505.Equals(0) && x.bo00507.Equals(2)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00146 = _b.Where(x => x.bo00505.Equals(3) && x.bo00507.Equals(3)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00147 = _b.Where(x => x.bo00505.Equals(2) && x.bo00507.Equals(3)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00148 = _b.Where(x => x.bo00505.Equals(1) && x.bo00507.Equals(3)).Select(x => x.bo00506).FirstOrDefault();
                    sf.bo00149 = _b.Where(x => x.bo00505.Equals(0) && x.bo00507.Equals(3)).Select(x => x.bo00506).FirstOrDefault();
                    #endregion
                    return sf;
            }
            catch
            {
                return new Staffing_sdbo004();
            }

        }

        public IOperateResult Add(Staffing_sdbo001 sf,IRequestGetter context)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    string zuofanid = sf.bo00150;
                    List<string> bo00406s = context.GetValue<List<string>>("p1", GetterType.JToken); 
                    List<string> bo00506s = context.GetValue<List<string>>("p2", GetterType.JToken);
                    List<int> bo00405s = new List<int>() {4,3,2,2,2,2,1,1,1,1,0,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    //List<int> bo00407s = new List<int>() {0,0,1,2,3,4,1,2,3,4,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4 };
                    List<int> bo00407s = new List<int>() { 0, 0, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };
                    //List<int> bo00408s = new List<int>() {0,0,0,0,0,0,0,0,0,0,1,2,3,4,5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
                    List<int> bo00408s = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5 };
                    List<int> bo00505s = new List<int>() {3,2,1,0, 2, 1, 0, 3, 2, 1, 0, 3, 2, 1, 0 };
                    List<int> bo00507s = new List<int>() { 0,0,0,0,1,1,1,2,2,2,2,3,3,3,3,};
                    IEnumerable<sdbo004> del_004 = this._sdbo004Repository.GetModels(x => x.bo00402.Equals(zuofanid)).ToList();
                    IEnumerable<sdbo005> del_005 = this._sdbo005Repository.GetModels(x => x.bo00502.Equals(zuofanid)).ToList();
                    this._sdbo004Repository.RemoveRange(del_004);
                    this._sdbo005Repository.RemoveRange(del_005);
                    IEnumerable<sdbo004> query_sdbo004s = bo00405s.Zip(bo00406s, (x, y) => new sdbo004
                    {
                        bo00405 = x,
                        bo00406 = y
                    }).Zip(bo00407s, (x, y) =>
                    {
                        x.bo00407 = y;
                        return x;
                    }).Zip(bo00408s, (x, y) =>
                    {
                        x.bo00408 = y;
                        return x;
                    }).Zip(new string[30],(x,y)=>{
                        x.bo00402 = zuofanid;
                        return x;
                    }).Zip(new string[30], (x, y) => {
                        x.bo00403 = sf.bo00102;
                        return x;
                    }).Zip(new string[30], (x, y) => {
                        x.bo00404 = sf.bo00103;
                        return x;
                    });
                    IEnumerable<sdbo005> query_sdbo005s = new string[15].Zip(new string[15], (x, y) => new sdbo005
                    {
                        bo00502=zuofanid,
                        bo00503=sf.bo00102
                    }).Zip(new string[30], (x, y) => {
                        x.bo00504 = sf.bo00103;
                        return x;
                    }).Zip(bo00505s, (x, y) => {
                        x.bo00505 = y;
                        return x;
                    }).Zip(bo00506s, (x, y) => {
                        x.bo00506 = y;
                        return x;
                    }).Zip(bo00507s, (x, y) => {
                        x.bo00507 =y;
                        return x;
                    });
                    foreach (var item in query_sdbo004s.ToList())
                    {
                        this._sdbo004Repository.Add(item);
                    }
                    foreach (var item in query_sdbo005s.ToList())
                    {
                        this._sdbo005Repository.Add(item);
                    }
                    //this._sdbo004Repository.AddRange(query_sdbo004s.ToList());
                    //this._sdbo004Repository.AddRange(query_sdbo004s.ToList());
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "保存成功");

                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "保存失败");
            }
        }

        public object List_sdpj004_2()
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IQueryable<sdpj004> sql_sdpj004 = this._sdpj004Repository.GetModels(x => x.pj00412.Equals(1));
                    var  pj = from x in sql_sdpj004
                                        select new 
                                        {
                                            pj00421 = x.pj00421,
                                            pj00402 = x.pj00402,
                                            pj00403 = x.pj00403,
                                            pj00420 = x.pj00420,
                                            pj00415 = x.pj00415
                                        };
                    return pj.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IOperateResult List_sdpj004_3(IPageContext context)
        {
            try
            {
                IPagedList pagedList = null;
                string _q = context.GetValue<string>("q")??string.Empty;
                //string[] a = new string[1] { _q };
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IQueryable<sdpj004> query_sdpj004 = this._sdpj004Repository.GetModels(x => x.pj00412.Equals(1) && x.pj00402.Contains(_q) ).OrderBy(o => o.pj00421);
                    var edg = query_sdpj004.ToList();
                    pagedList = query_sdpj004.ToPagedList<sdpj004>(context);
                    return OperateResultFactory.GridOperateResult(pagedList);
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.GridOperateResult(new List<sdpj004>());
            }
        }
    }
}
