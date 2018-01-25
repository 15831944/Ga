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
using PM2.Service.Code001;
using Gmail.DDD.PagedList;
using Gmail.DDD.Mvc;
using PM2.Repository.Code030;
using System.Data.Entity;
namespace PM2.Service.Code030
{
    public class Szrl025Server : Iszrl025Server
    {
        #region ===================================注入===================================
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl004> _szrl004Repository;
        private IEFRepository<szrl018> _szrl018Repository;
        private IEFRepository<szrl019> _szrl019Repository;
        private Iszrl025Repository_Facade _szrl025Repository;
        private IEFRepository<szrl026> _szrl026Repository;
        private IEFRepository<szrl028> _szrl028Repository;
        private IEFRepository<sdpj004> _sdpj004Repository;

        public Szrl025Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl004> szrl004Repository,
             IEFRepository<szrl018> szrl018Repository,
             IEFRepository<szrl019> szrl019Repository,
             Iszrl025Repository_Facade szrl025Repository_Facade,
             IEFRepository<szrl026> szrl026Repository,
             IEFRepository<szrl028> szrl028Repository,
             IEFRepository<sdpj004> sdpj004Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._szrl004Repository = szrl004Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl019Repository = szrl019Repository;
            this._szrl025Repository = szrl025Repository_Facade;
            this._szrl026Repository = szrl026Repository;
            this._szrl028Repository = szrl028Repository;
            this._sdpj004Repository = sdpj004Repository;

        }
        #endregion


        #region ==================================受注传票=================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szrl025">此处值不会是最新的</param>
        /// <returns></returns>
        public IOperateResult Add(szrl025 szrl025)
        {

            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    /*
                     1.查询作番是否内部精算 是 则 返回  等待实行预算完成
                     2.判断期间作番是否勾选  勾选则不能关联合同,没有勾选必须关联合同 期间作番只有初回才可以
                     3.更具作番和发行回数重新对 szrl025 部分数据赋值
                     4.查询当前版本的受注传票是否存在
                        存在 则 更新查询信息
                        不存在 则为新增
                     */
                    szrl025.rl02503 = szrl025.rl02503 == "初回" ? "0" : szrl025.rl02503;
                    #region 作番是否精算
                    byte rl01827 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(szrl025.rl02501)).Select(x => x.rl01827).FirstOrDefault();
                    if (rl01827.Equals(3))
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "作番已内部精算,不可保存!");
                    }
                    if (rl01827.Equals(4))
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "作番已外部精算,不可保存!");
                    }
                    #endregion
                    #region 期间作番判断
                    IEnumerable<szrl026> l_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(szrl025.rl02501) && x.rl02605.Equals(szrl025.rl02503));
                    if (l_szrl026.IsNullOrEmpty())
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "请关联营业合同!");
                    }
                    //if (szrl025.rl02502)
                    //{
                    //    if (!l_szrl026.IsNullOrEmpty())
                    //    {
                    //        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "期间作番不可管理营业合同!");
                    //    }
                    //}
                    //else
                    //{
                    //    if (l_szrl026.IsNullOrEmpty())
                    //    {
                    //        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "请关联营业合同!");
                    //    }
                    //}
                    #endregion
                    #region 更具作番和发行回数重新对 szrl025 部分数据赋值
                    szrl025.rl02507 = szrl025.rl02507 ?? string.Empty;//中专公司名 非必填
                    //查询受注传票是否存在
                    string Forsomenum = szrl025.rl02501;//作番
                    decimal rl01835 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(Forsomenum)).Select(x => x.rl01835).FirstOrDefault();//作番税率
                    decimal rl01813 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(Forsomenum)).Select(x => x.rl01813).FirstOrDefault();//日元汇率
                    List<szrl019> query_szrl019 = GetBusiness(Forsomenum);//获取该作番下所有的营业合同
                    List<szrl026> query_szrl026_1 = new List<szrl026>();//已通告
                    List<szrl026> query_szrl026_2 = new List<szrl026>();//本次通告
                    List<szrl026> query_szrl026_3 = new List<szrl026>();//本次为止累计通告
                    string rl02535 = szrl025.rl02535;
                    if (string.IsNullOrWhiteSpace(rl02535))
                    {//初回
                        query_szrl026_2 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(Forsomenum) && x.rl02605.Equals("0")).OrderBy(o => o.rl02606).ToList();
                        query_szrl026_3 = query_szrl026_2;
                    }
                    else
                    {
                        IEnumerable<szrl026> query_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(Forsomenum))
                                                   .GroupBy(x => x.rl02606)
                                                   .Select(x => x.OrderBy(o => o.rl02606).FirstOrDefault())
                                                   .ToList();//分组查询作番下最新的合同(过滤掉不用的)
                        string rl02503 = szrl025.rl02503;//获取最新的版本
                        query_szrl026_1 = query_szrl026.Where(x => x.rl02602.Equals(Forsomenum) && !x.rl02605.Equals(rl02503)).OrderBy(o => o.rl02606).ToList();
                        query_szrl026_2 = query_szrl026.Where(x => x.rl02602.Equals(Forsomenum) && x.rl02605.Equals(rl02503)).OrderBy(o => o.rl02606).ToList();
                        query_szrl026_3 = query_szrl026.Where(x => x.rl02602.Equals(Forsomenum)).OrderBy(o => o.rl02606).ToList();
                    }
                    #region 取原合同 已通告 本次 本次为止累计
                    IEnumerable<szrl019> u_019_026_1 = from x in query_szrl019//上次发行
                                                       let pks = (
                                                       from y in query_szrl026_1
                                                       where y.rl02604.Equals(0)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl01901)
                                                       select x;
                    IEnumerable<szrl019> u_019_026_2 = from x in query_szrl019//本次发行
                                                       let pks = (
                                                       from y in query_szrl026_2
                                                       where y.rl02604.Equals(0)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl01901)
                                                       select x;
                    IEnumerable<szrl019> u_019_026_3 = from x in query_szrl019//本次累计(所有)
                                                       let pks = (
                                                       from y in query_szrl026_3
                                                       where y.rl02604.Equals(0)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl01901)
                                                       select x;
                    #endregion
                    #region 取变更合同  已通告 本次 本次为止累计
                    IEnumerable<szrl028> query_szrl028 = this._szrl028Repository.GetModels().ToArray();
                    IEnumerable<szrl028> u_rl02811_1 = from x in query_szrl028//上次发行
                                                       let pks = (
                                                       from y in query_szrl026_1
                                                       where y.rl02604.Equals(1)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl02801)
                                                       select x;
                    IEnumerable<szrl028> u_rl02811_2 = from x in query_szrl028//本次发行
                                                       let pks = (
                                                       from y in query_szrl026_2
                                                       where y.rl02604.Equals(1)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl02801)
                                                       select x;
                    IEnumerable<szrl028> u_rl02811_3 = from x in query_szrl028//本次累计(所有)
                                                       let pks = (
                                                       from y in query_szrl026_3
                                                       where y.rl02604.Equals(1)
                                                       select y.rl02603)
                                                       where pks.Contains(x.rl02801)
                                                       select x;
                    #endregion
                    #region 对szrl025部分数据重新赋值
                    string _rl02802_u2 = u_rl02811_2.Select(s => s.rl02802).FirstOrDefault();
                    string _rl02802_u3 = u_rl02811_3.Select(s => s.rl02802).FirstOrDefault();
                    string _rl00403 = this._szrl004Repository.GetModels(x => x.rl00401.Equals(_rl02802_u2)).Select(x => x.rl00403).FirstOrDefault();
                    string rl01903_u2 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(_rl02802_u2) && x.rl01960.Equals(0)).Select(x => x.rl01903).FirstOrDefault();
                    string rl01903_u3 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(_rl02802_u3) && x.rl01960.Equals(0)).Select(x => x.rl01903).FirstOrDefault();
                    szrl025.rl02504 = szrl025.rl02504 ?? string.Empty;
                    szrl025.rl02512 = u_019_026_1.Where(x => x.rl01902.Equals(query_szrl026_1.OrderBy(o => Convert.ToDateTime(o.rl02606)).Select(o => o.rl02603).FirstOrDefault())).Select(x => x.rl01903).FirstOrDefault() ?? string.Empty;
                    szrl025.rl02513 = u_019_026_2.Where(x => x.rl01902.Equals(query_szrl026_2.OrderBy(o => Convert.ToDateTime(o.rl02606)).Select(o => o.rl02603).FirstOrDefault())).Select(x => x.rl01903).FirstOrDefault() ?? rl01903_u2;
                    szrl025.rl02514 = u_019_026_3.Where(x => x.rl01902.Equals(query_szrl026_3.OrderBy(o => Convert.ToDateTime(o.rl02606)).Select(o => o.rl02603).FirstOrDefault())).Select(x => x.rl01903).FirstOrDefault() ?? rl01903_u3;
                    szrl025.rl02515 = u_019_026_1.Count() + u_rl02811_1.Count();
                    szrl025.rl02516 = u_019_026_2.Count() + u_rl02811_2.Count();
                    szrl025.rl02517 = u_019_026_3.Count() + u_rl02811_3.Count();
                    szrl025.rl02518 = u_019_026_1.Select(s => s.rl01909 + s.rl01950).Sum() + u_rl02811_1.Select(x => x.rl02807).Sum();
                    szrl025.rl02519 = u_019_026_2.Select(s => s.rl01909 + s.rl01950).Sum() + u_rl02811_2.Select(x => x.rl02807).Sum();
                    szrl025.rl02520 = u_019_026_3.Select(s => s.rl01909 + s.rl01950).Sum() + u_rl02811_3.Select(x => x.rl02807).Sum();
                    szrl025.rl02521 = szrl025.rl02518 / (1 + rl01835 / 100);
                    szrl025.rl02522 = szrl025.rl02519 / (1 + rl01835 / 100);
                    szrl025.rl02523 = szrl025.rl02520 / (1 + rl01835 / 100);
                    szrl025.rl02524 = szrl025.rl02518 * rl01813;
                    szrl025.rl02525 = szrl025.rl02519 * rl01813;
                    szrl025.rl02526 = szrl025.rl02520 * rl01813;
                    szrl025.rl02527 = szrl025.rl02527 ?? string.Empty;

                    szrl025.rl02530 = "";
                    szrl025.rl02531 = "";
                    szrl025.rl02532 = 0;
                    szrl025.rl02533 = UserContext.Pj00402;
                    szrl025.rl02534 = DateTime.Now.ToString("yyyy-MM-dd");
                    #endregion
                    #endregion
                    #region 执行保存或者新增操作
                    szrl025 u_szrl025 = this._szrl025Repository.GetModels(x => x.rl02535.Equals(szrl025.rl02535) && x.rl02503.Equals(szrl025.rl02503)).FirstOrDefault();
                    if (u_szrl025 != null)//受注传票存在
                    {
                        szrl025.rl02528 = szrl025.rl02528 ?? UserContext.Pj00402;
                        szrl025.rl02529 = szrl025.rl02529 ?? DateTime.Now.ToString("yyyy-MM-dd");
                        this._szrl025Repository.Update(szrl025);//修改
                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                    }
                    else//受注传票不存在 新增
                    {
                        szrl025.rl02528 = UserContext.Pj00402;
                        szrl025.rl02529 = DateTime.Now.ToString("yyyy-MM-dd");
                        szrl025.rl02535 = null;
                        this._szrl025Repository.Add(szrl025);
                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "保存失败!");
            }
        }

        /// <summary>
        /// 获取作番信息  新增
        /// </summary>
        /// <param name="id">作番Id</param>
        /// <returns></returns>
        public IOperateResult GetForsomeInfo(IRequestGetter context)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    string id= context.GetValue<string>("id");
                    string versionNumber = context.GetValue<string>("versionNumber");
                    szrl018 query_szrl018 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(id)).AsNoTracking().FirstOrDefault();
                    query_szrl018.rl01802 = this._szrl004Repository.GetModels(x => x.rl00401.Equals(query_szrl018.rl01802)).Select(x => x.rl00403).FirstOrDefault();
                    query_szrl018.rl01811 = this._sdpj004Repository.GetModels(x => x.pj00401.Equals(query_szrl018.rl01811)).Select(x => x.pj00402).FirstOrDefault() ?? string.Empty;
                    string Forsomenum = query_szrl018.rl01801;//作番号
                    szrl025 query_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(id)).OrderByDescending(o => o.rl02503).AsNoTracking().FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(versionNumber))
                    {
                        query_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(id) && x.rl02503.Equals(versionNumber)).FirstOrDefault();
                    }
                    Delete_szrl026Array(Forsomenum);
                    if (query_szrl025 != null)
                    {
                        if (query_szrl025.rl02503 == "0")
                        {
                            query_szrl025.rl02503 = "初回";
                        }
                        query_szrl025.rl02527 = query_szrl025.rl02527 ?? " 更新内容/备注:请现场部门在本受注传票发行后两周内提交实行预算书。 ";
                    }
                    else
                    {
                        query_szrl025 = new szrl025();
                        query_szrl025.rl02501 = query_szrl018.rl01801;
                        query_szrl025.rl02503 = "初回";
                        query_szrl025.rl02504 = "";
                        query_szrl025.rl02505 = 0;
                        query_szrl025.rl02508 = DateTime.Now.ToString("d");
                        query_szrl025.rl02509 = query_szrl018.rl01802;
                        query_szrl025.rl02510 = query_szrl018.rl01809;
                        query_szrl025.rl02511 = query_szrl018.rl01812;

                    }
                    scope.SaveChanges();
                    return OperateResultFactory.FromLoadOperateResult(query_szrl025, new
                    {
                        szrl018 = query_szrl018
                    });

                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.FromLoadOperateResult(new szrl025() { rl02503 = string.Empty, rl02508 = string.Empty, rl02511 = string.Empty }, new
                {
                    szrl018 = new szrl018() {
                        rl01806 = string.Empty,
                        rl01811 = string.Empty,
                        rl01802 = string.Empty,
                        rl01807 = string.Empty,
                        rl01835 = 0
                    }
                });
            }
        }
        public void Delete_szrl026Array(string Forsomenum)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl025 query_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(Forsomenum)).OrderByDescending(o => o.rl02503).FirstOrDefault();
                    if (query_szrl025==null)//没有传票
                    {
                        IEnumerable<szrl026> query_szrl026s = this._szrl026Repository.GetModels(x => x.rl02602.Equals(Forsomenum)).ToArray();
                        this._szrl026Repository.RemoveRange(query_szrl026s);
                        scope.SaveChanges();
                    }
                    else//有传票
                    {
                        string rl02605 = (Convert.ToInt32(query_szrl025.rl02503) + 1).ToString().PadLeft(3,'0');
                        IEnumerable<szrl026> query_szrl026s = this._szrl026Repository.GetModels(x => x.rl02602.Equals(Forsomenum) && x.rl02605.Equals(rl02605)).ToArray();
                        this._szrl026Repository.RemoveRange(query_szrl026s);
                        scope.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }







        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public IOperateResult Recognize(szrl025 szrl025)
        {
            if (string.IsNullOrWhiteSpace(szrl025.rl02501))
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "请选择作番");
            }

            try
            {
                szrl025 m_szrl025 = null;
                using (IDbContextReadOnlyScope scope = this._scopeFactory.CreateReadOnlyScope())
                {
                    szrl025.rl02503 = szrl025.rl02503 == "初回" ? "0" : szrl025.rl02503;
                    m_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(szrl025.rl02501) && x.rl02503.Equals(szrl025.rl02503)).FirstOrDefault();
                }
                if (m_szrl025 == null)
                {
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "此受注传票不存在");
                }

                //反填作番精算月 详情看文档
                using (IDbContextScope scope = this._scopeFactory.CreateTransactionScope(System.Data.IsolationLevel.Unspecified))
                {
                    #region ===========linq审核============
                    //审核
                    //m_szrl025.rl02532 = 1;
                    //if (m_szrl025.rl02503 == "0")//初回
                    //{
                    //    m_szrl025.rl02508= DateTime.Now.ToString("yyyy-MM-dd");
                    //}
                    //else//变更
                    //{
                    //    m_szrl025.rl02504 = DateTime.Now.ToString("yyyy-MM-dd");
                    //}
                    //this._szrl025Repository.Update(m_szrl025);
                    ////反填作番下最新的所有合同
                    //IEnumerable<szrl019> l_szrl019 = this._szrl019Repository.GetModels(x => x.rl01906.Equals(szrl025.rl02501) && x.rl01964.Equals(1)).ToArray();//没有变更的最新合同
                    //foreach (var item in l_szrl019)
                    //{
                    //    item.rl01948 = szrl025.rl02511;
                    //}
                    //scope.SaveChanges();
                    #endregion
                    #region =========存储过程审核==========
                    int _szrl025_check = this._szrl025Repository.Szrl025_check(UserContext.Pj00402, m_szrl025.rl02535);
                    if (_szrl025_check < 1)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "审核失败!");
                    }
                    #endregion
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "审核成功!");

                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "审核失败!");
            }
        }

        /// <summary>
        /// 删除传票
        /// </summary>
        /// <param name="Forsomenum">作番id</param>
        /// <returns></returns>
        public IOperateResult Remove(HttpCollection vParams)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    string Forsomenum = vParams.GetValue<string>("Forsomenum");
                    szrl025 query_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(Forsomenum) && x.rl02532.Equals(0)).FirstOrDefault();
                    if (query_szrl025 == null)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "删除失败!");
                    }
                    string rl02503 = query_szrl025.rl02503;
                    IEnumerable<szrl026> query_szrl026s = this._szrl026Repository.GetModels(x => x.rl02602.Equals(Forsomenum) && x.rl02605.Equals(rl02503)).ToArray();
                    this._szrl026Repository.RemoveRange(query_szrl026s);
                    this._szrl025Repository.Remove(query_szrl025);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "删除成功!");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region ==================================传票明细=================================




        /// <summary>
        /// 更具作番id查询与明细有关的合同信息
        /// </summary>
        /// <param name="rl02501">作番id</param>
        /// <returns></returns>
        private IEnumerable<szrl019> GetSzrl019(string rl02501)
        {
            using (IDbContextScope scope = this._scopeFactory.CreateScope())
            {
                IQueryable<szrl019> szrl019s = this._szrl019Repository.GetModels();
                IQueryable<szrl026> szrl026s = this._szrl026Repository.GetModels();
                var query = from x in szrl019s
                            let pks = (
                                from y in szrl026s
                                where y.rl02602.Equals(rl02501)
                                select y.rl02603
                            )
                            where pks.Contains(x.rl01902)
                            select x;
                return query.ToArray();
            }
        }
        /// <summary>
        /// 显示明细网格 PagingContext context
        /// </summary>
        /// <param name="rl02501"></param>
        /// <returns></returns>
        public IOperateResult Selectdg(IPageContext context)
        {
            string rl02501 = context.GetValue<string>("rl02501");
            string versionNumber= context.GetValue<string>("versionNumber");
            versionNumber = versionNumber == "初回" ? "0" : versionNumber;
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    /*
                     查询明细是否有数据 没数据直接返回空
                     查询明细最高版本进行for循环遍历
                     对每一个版本进行分组添加到集合中
                     最后计算所有集合中的数据并添加到集合中
                     */
                    //查询作番税率
                    decimal rl01835 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(rl02501)).Select(x => x.rl01835).FirstOrDefault();


                    //IEnumerable<szrl026> L_szrl026 = this._szrl026Repository.GetModels(
                    //    context,
                    //    x => x.rl02602.Equals(rl02501),
                    //    x => x.Asc(o => o.rl02605)
                    //    .Asc(o => o.rl02606)
                    //);
                    IEnumerable<szrl026> L_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501)).OrderBy(x => x.rl02605).OrderBy(x => x.rl02606);
                    if (versionNumber!="null")
                    {
                        L_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501) && x.rl02605.Equals(versionNumber)).OrderBy(x => x.rl02606);
                    }
                    if (L_szrl026.IsNullOrEmpty())
                    {
                        return OperateResultFactory.GridOperateResult(new List<szrl026CBN>());
                    }
                    var L_szrl019 = this.GetSzrl019(rl02501);//this._szrl019Repository.GetModels(x => items.Contains(x.rl01901)).ToList();
                    List<szrl026CBN> L_szrl026CBN = new List<szrl026CBN>();
                    int max_rl02605 = L_szrl026.Max(x => Convert.ToInt32(x.rl02605)) + 1;
                    decimal count_ContractAmount = 0.0m;
                    decimal count_TaxFreeMoney = 0.0m;
                    int NumberId = 1;
                    for (int i = 0; i < max_rl02605; i++)
                    {
                        var aaount = 0.0m;
                        List<szrl026> list026 = L_szrl026.Where(x => Convert.ToInt32(x.rl02605).Equals(i)).OrderBy(o => Convert.ToDateTime(o.rl02606)).ToList();
                        foreach (var item in list026)
                        {
                            if (item.rl02604.Equals(0))//没有变更的合同
                            {
                                szrl019 m_szrl019 = L_szrl019.Where(x => x.rl01901.Equals(item.rl02603) && !x.rl01971.Equals(0) && x.rl01960.Equals(0)).FirstOrDefault();
                                szrl026CBN _szrl026CBN = new szrl026CBN();
                                _szrl026CBN.NumberId = NumberId.ToString();
                                _szrl026CBN.VoucheId = item.rl02601;
                                _szrl026CBN.IsChange = string.Empty;
                                _szrl026CBN.ContractSerialNum = m_szrl019.rl01904;
                                _szrl026CBN.ContractAmount = m_szrl019.rl01909.ToRound().ToString();
                                _szrl026CBN.AllocationAmount = string.Empty;
                                _szrl026CBN.TaxFreeMoney = (m_szrl019.rl01909 / (1 + rl01835 / 100)).ToRound().ToString();
                                _szrl026CBN.Tax = ((m_szrl019.rl01909 / (1 + rl01835 / 100)) * rl01835 / 100).ToRound().ToString();
                                _szrl026CBN.ContractNumber = m_szrl019.rl01911;
                                _szrl026CBN.ContractName = m_szrl019.rl01903;
                                _szrl026CBN.ContractDate = m_szrl019.rl01910;
                                _szrl026CBN.DateDelivery = m_szrl019.rl01914;
                                _szrl026CBN.CirculationNumber = item.rl02605 == "0" ? "初回" : item.rl02605;
                                _szrl026CBN.DateIssue = item.rl02606;
                                _szrl026CBN.BudgetState = item.rl02607 == 0 ? "未预算" : "已预算";
                                L_szrl026CBN.Add(_szrl026CBN);
                                NumberId = NumberId + 1;
                                aaount += m_szrl019.rl01909;
                                count_ContractAmount += m_szrl019.rl01909;
                                count_TaxFreeMoney += (m_szrl019.rl01909 / (1 + rl01835 / 100));
                            }
                            else//变更
                            {
                                szrl028 m_szrl028 = this._szrl028Repository.GetModels(x => x.rl02801.Equals(item.rl02603)).FirstOrDefault();
                                int rl01960 = Convert.ToInt32(m_szrl028.rl02803.Split('-')[1]);
                                szrl019 m_szrl019 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(m_szrl028.rl02802) && x.rl01960.Equals(rl01960) && !x.rl01971.Equals(0)).FirstOrDefault();
                                szrl026CBN _szrl026CBN = new szrl026CBN();
                                _szrl026CBN.NumberId = NumberId.ToString();
                                _szrl026CBN.VoucheId = item.rl02601;
                                _szrl026CBN.IsChange = m_szrl028.rl02849.Equals(1) ? "变更" : "取消";
                                _szrl026CBN.ContractSerialNum = m_szrl019.rl01904;
                                _szrl026CBN.ContractAmount = m_szrl028.rl02807.ToRound().ToString();
                                _szrl026CBN.AllocationAmount = string.Empty;
                                _szrl026CBN.TaxFreeMoney = (m_szrl028.rl02807 / (1 + rl01835 / 100)).ToRound().ToString();
                                _szrl026CBN.Tax = ((m_szrl028.rl02807 / (1 + rl01835 / 100)) * rl01835 / 100).ToRound().ToString();
                                _szrl026CBN.ContractNumber = m_szrl019.rl01911;
                                _szrl026CBN.ContractName = m_szrl019.rl01903;
                                _szrl026CBN.ContractDate = m_szrl019.rl01910;
                                _szrl026CBN.DateDelivery = m_szrl019.rl01914;
                                _szrl026CBN.CirculationNumber = item.rl02605 == "0" ? "初回" : item.rl02605;
                                _szrl026CBN.DateIssue = item.rl02606;
                                _szrl026CBN.BudgetState = item.rl02607 == 0 ? "未预算" : "已预算";
                                L_szrl026CBN.Add(_szrl026CBN);
                                NumberId = NumberId + 1;
                                aaount += m_szrl028.rl02807;
                                count_ContractAmount += m_szrl028.rl02807;
                                count_TaxFreeMoney += (m_szrl028.rl02807 / (1 + rl01835 / 100));
                            }

                        }
                        if (list026.Count != 0)
                        {
                            szrl026CBN cbn = new szrl026CBN();
                            cbn.ContractAmount = list026.Select(x => x.rl02605).FirstOrDefault() == "0" ? "初回" : list026.Select(x => x.rl02605).FirstOrDefault();//此处有问题啊
                            cbn.AllocationAmount = aaount.ToRound().ToString();
                            L_szrl026CBN.Add(cbn);
                        }
                    }
                    szrl026CBN cbn2 = new szrl026CBN();
                    cbn2.ContractSerialNum = "合计:";
                    cbn2.ContractAmount = count_ContractAmount.ToRound().ToString();
                    cbn2.AllocationAmount = count_ContractAmount.ToRound().ToString();
                    cbn2.TaxFreeMoney = count_TaxFreeMoney.ToRound().ToString();
                    L_szrl026CBN.Add(cbn2);
                    return OperateResultFactory.GridOperateResult(L_szrl026CBN);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 保存选择的合同
        /// </summary>
        /// <param name="szrl019"></param>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public IOperateResult SaveVoucher(HttpCollection vParams)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    //取参数
                    string formid = vParams.GetValue<string>("formid");
                    string Circulation = vParams.GetValue<string>("Circulation");
                    byte isChange = vParams.GetValue<byte>("isChange");
                    Circulation = Circulation == "初回" ? "0" : Circulation;
                    szrl026 m_szrl026 = this._szrl026Repository.GetModels(x => x.rl02603.Equals(formid) && x.rl02605.Equals(Circulation)).FirstOrDefault();
                    if (m_szrl026 != null)
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "已勾选此合同");
                    }
                    if (isChange.Equals(0))//原合同
                    {
                        var m_szrl019 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(formid)).FirstOrDefault();
                        if (m_szrl019 != null)
                        {
                            int rl02532 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(m_szrl019.rl01906) && x.rl02503.Equals(Circulation)).Select(x => x.rl02532).FirstOrDefault();
                            if (rl02532 == 1)
                            {
                                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "作番已被审核");
                            }
                        }
                        szrl026 szrl026 = new szrl026();
                        szrl026.rl02602 = m_szrl019.rl01906;
                        szrl026.rl02603 = formid;
                        szrl026.rl02604 = 0;//是否变更
                        szrl026.rl02605 = Circulation;//当前传票版本
                        szrl026.rl02606 = DateTime.Now.ToString();
                        szrl026.rl02607 = 0;//是否被实行予算关联 需要修改
                        this._szrl026Repository.Add(szrl026);
                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "保存成功");
                    }
                    else//变更合同
                    {
                        szrl028 m_szrl028 = this._szrl028Repository.GetModels(x => x.rl02801.Equals(formid)).FirstOrDefault();
                        string rl01906 = string.Empty;
                        if (m_szrl028 != null)
                        {
                            rl01906 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(m_szrl028.rl02802)).Select(x => x.rl01906).FirstOrDefault();
                        }
                        szrl026 szrl026 = new szrl026();
                        szrl026.rl02602 = rl01906;
                        szrl026.rl02603 = formid;
                        szrl026.rl02604 = 1;//是否变更
                        szrl026.rl02605 = Circulation;//当前传票版本
                        szrl026.rl02606 = DateTime.Now.ToString();
                        szrl026.rl02607 = 0;//是否被实行予算关联 需要修改
                        this._szrl026Repository.Add(szrl026);
                        scope.SaveChanges();
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "保存成功");
                    }

                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "保存失败!");
            }
        }
        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="VoucherId"></param>
        /// <returns></returns>
        public IOperateResult DeleteVoucher(string VoucherId, string CirculationNumber)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {


                    if (!string.IsNullOrWhiteSpace(VoucherId))
                    {
                        CirculationNumber = CirculationNumber == "初回" ? "0" : CirculationNumber;
                        var m_szrl026 = this._szrl026Repository.GetModels(x => x.rl02601.Equals(VoucherId)).FirstOrDefault();
                        if (m_szrl026.rl02605 != CirculationNumber)
                        {
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "不可删除此版本的明细");
                        }
                        if (m_szrl026 != null)
                        {
                            szrl025 m_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(m_szrl026.rl02602) && x.rl02503.Equals(CirculationNumber)).FirstOrDefault();
                            if (m_szrl025 != null)
                            {
                                if (m_szrl025.rl02532 == 1)//是否被承认 ,承认后不可删除
                                {
                                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "此版本传票已承认,不可删除");
                                }
                            }
                            this._szrl026Repository.Remove(m_szrl026);
                            scope.SaveChanges();
                            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "删除成功");
                        }
                    }
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "删除失败");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// 营业合同
        /// </summary>
        /// <param name="Forsomenum">作番号</param>
        /// <returns>返回集合</returns>
        public List<szrl019> GetBusiness(string Forsomenum)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    //List<szrl019> query_szrl019 = this._szrl019Repository.GetModels(x => x.rl01906.Equals(Forsomenum)).ToList();
                    List<szrl019> query_szrl019 = this._szrl019Repository.GetModels(x => x.rl01906.Equals(Forsomenum) && !x.rl01971.Equals(0)).ToList();//最新的合同
                    return query_szrl019;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 显示作番下所有合同
        /// </summary>
        /// <param name="rl02501">作番id</param>
        /// <param name="isChange">是否变更 0: 显示原合同 ; 1 :显示变更合同</param>
        /// <returns></returns>
        public IOperateResult GetSzrl019Info(IPageContext context)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    string rl02501 = context.GetValue<string>("rl02501");//获取作番
                    decimal rl01835 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(rl02501)).Select(x => x.rl01835).FirstOrDefault();
                    List<szrl019> query_szrl019s = GetBusiness(rl02501);//查询所有合同
                    List<szrl026> query_szrl026s = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501)).ToList();
                    string[] rl02603s = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501)).Select(x => x.rl02603).ToArray();
                    List<szrl028> query_szrl028s = this._szrl028Repository.GetModels().ToList();
                    IEnumerable<szrl019> l_w_szrl019 = from x in query_szrl019s
                                                       let pks = (
                                                       from y in query_szrl026s
                                                       select y.rl02603)
                                                       where !pks.Contains(x.rl01901)
                                                       && !x.rl01971.Equals(0)
                                                       select x;//过滤掉所有初回已添加的合同
                    List<szrl026CBN> query_cbns = new List<szrl026CBN>();
                    foreach (var item in l_w_szrl019)//在这里过滤已经关联的变更合同
                    {
                        var query_szrl028 = query_szrl028s.Where(x => Convert.ToInt32(x.rl02803.Split('-')[1]).Equals(item.rl01960) && x.rl02802.Equals(item.rl01902)).FirstOrDefault();
                        if (query_szrl028 != null)
                        {
                            if (!rl02603s.Contains(query_szrl028.rl02801))//没有被勾选的变更合同
                            {
                                szrl026CBN query_cbn = new szrl026CBN();
                                query_cbn.VoucheId = query_szrl028.rl02801;
                                query_cbn.IsChange = query_szrl028.rl02849.Equals(1) ? "变更" : "取消";
                                query_cbn.ContractSerialNum = item.rl01904;
                                query_cbn.ContractAmount = query_szrl028.rl02807.ToRound().ToString();
                                query_cbn.AllocationAmount = string.Empty;
                                query_cbn.TaxFreeMoney = (query_szrl028.rl02807 / (1 + rl01835 / 100)).ToRound().ToString();
                                query_cbn.Tax = (query_szrl028.rl02807 / (1 + rl01835 / 100) * rl01835 / 100).ToRound().ToString();
                                query_cbn.ContractNumber = item.rl01911;
                                query_cbn.ContractName = item.rl01903;
                                query_cbn.ContractDate = item.rl01910;
                                query_cbn.DateDelivery = item.rl01914;
                                query_cbn.CirculationNumber = item.rl01960 == 0 ? "初回" : item.rl01960.ToString().PadLeft(3, '0');
                                query_cbns.Add(query_cbn);
                            }
                        }
                        else//不存在 这条合同没有变更
                        {
                            szrl026CBN query_cbn = new szrl026CBN();
                            query_cbn.VoucheId = item.rl01902;
                            query_cbn.IsChange = string.Empty;
                            query_cbn.ContractSerialNum = item.rl01904;
                            query_cbn.ContractAmount = item.rl01909.ToRound().ToString();
                            query_cbn.AllocationAmount = string.Empty;
                            query_cbn.TaxFreeMoney = (item.rl01909 / (1 + rl01835 / 100)).ToRound().ToString();
                            query_cbn.Tax = (item.rl01909 / (1 + rl01835 / 100) * rl01835 / 100).ToRound().ToString();
                            query_cbn.ContractNumber = item.rl01911;
                            query_cbn.ContractName = item.rl01903;
                            query_cbn.ContractDate = item.rl01910;
                            query_cbn.DateDelivery = item.rl01914;
                            query_cbn.CirculationNumber = item.rl01960 == 0 ? "初回" : item.rl01960.ToString().PadLeft(3, '0');
                            query_cbns.Add(query_cbn);
                        }
                    }
                    IPagedList pagedList_cbns = query_cbns.ToPagedList(context);
                    return OperateResultFactory.GridOperateResult(pagedList_cbns);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion


        /// <summary>
        /// 显示明细网格导出Excel方法时使用
        /// </summary>
        /// <param name="rl01801">作番id</param>
        /// <returns></returns>
        public IEnumerable<szrl026CBN> SelectgExcel(string rl02501)
        {



            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    /*
                     查询明细是否有数据 没数据直接返回空
                     查询明细最高版本进行for循环遍历
                     对每一个版本进行分组添加到集合中
                     最后计算所有集合中的数据并添加到集合中
                     */
                    //查询作番税率
                    decimal rl01835 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(rl02501)).Select(x => x.rl01835).FirstOrDefault();
                    IEnumerable<szrl026> L_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501)).OrderBy(x => x.rl02605).OrderBy(x => x.rl02606).ToArray();
                    var L_szrl019 = this.GetSzrl019(rl02501);
                    List<szrl026CBN> L_szrl026CBN = new List<szrl026CBN>();
                    int max_rl02605 = L_szrl026.Max(x => Convert.ToInt32(x.rl02605)) + 1;
                    decimal count_ContractAmount = 0.0m;
                    decimal count_TaxFreeMoney = 0.0m;
                    for (int i = 0; i < max_rl02605; i++)
                    {
                        var aaount = 0.0m;
                        List<szrl026> list026 = L_szrl026.Where(x => Convert.ToInt32(x.rl02605).Equals(i)).OrderBy(o => Convert.ToDateTime(o.rl02606)).ToList();
                        foreach (var item in list026)
                        {
                            if (item.rl02604.Equals(0))//没有变更的合同
                            {
                                szrl019 m_szrl019 = L_szrl019.Where(x => x.rl01901.Equals(item.rl02603) && !x.rl01971.Equals(0) && x.rl01960.Equals(0)).FirstOrDefault();
                                szrl026CBN _szrl026CBN = new szrl026CBN();
                                _szrl026CBN.VoucheId = item.rl02601;
                                _szrl026CBN.IsChange = string.Empty;
                                _szrl026CBN.ContractSerialNum = m_szrl019.rl01904;
                                _szrl026CBN.ContractAmount = m_szrl019.rl01909.ToRound().ToString();
                                _szrl026CBN.AllocationAmount = string.Empty;
                                _szrl026CBN.TaxFreeMoney = (m_szrl019.rl01909 / (1 + rl01835 / 100)).ToRound().ToString();
                                _szrl026CBN.Tax = ((m_szrl019.rl01909 / (1 + rl01835 / 100)) * rl01835 / 100).ToRound().ToString();
                                _szrl026CBN.ContractNumber = m_szrl019.rl01911;
                                _szrl026CBN.ContractName = m_szrl019.rl01903;
                                _szrl026CBN.ContractDate = m_szrl019.rl01910;
                                _szrl026CBN.DateDelivery = m_szrl019.rl01914;
                                _szrl026CBN.CirculationNumber = item.rl02605 == "0" ? "初回" : item.rl02605;
                                _szrl026CBN.DateIssue = Convert.ToDateTime(item.rl02606).ToString("yyyy-MM-dd");
                                _szrl026CBN.BudgetState = item.rl02607 == 0 ? "未预算" : "已预算";
                                L_szrl026CBN.Add(_szrl026CBN);
                                aaount += m_szrl019.rl01909;
                                count_ContractAmount += m_szrl019.rl01909;
                                count_TaxFreeMoney += (m_szrl019.rl01909 / (1 + rl01835 / 100));
                            }
                            else//变更
                            {
                                szrl028 m_szrl028 = this._szrl028Repository.GetModels(x => x.rl02801.Equals(item.rl02603)).FirstOrDefault();
                                int rl01960 = Convert.ToInt32(m_szrl028.rl02803.Split('-')[1]);
                                szrl019 m_szrl019 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(m_szrl028.rl02802) && x.rl01960.Equals(rl01960) && !x.rl01971.Equals(0)).FirstOrDefault();
                                if (m_szrl028.rl02849.Equals(2))
                                {
                                    m_szrl019 = this._szrl019Repository.GetModels(x => x.rl01902.Equals(m_szrl028.rl02802) && !x.rl01971.Equals(0)).FirstOrDefault();
                                }
                                szrl026CBN _szrl026CBN = new szrl026CBN();
                                _szrl026CBN.VoucheId = item.rl02601;
                                _szrl026CBN.IsChange = m_szrl028.rl02849.Equals(1) ? "变更" : "取消";
                                _szrl026CBN.ContractSerialNum = m_szrl019.rl01904;
                                _szrl026CBN.ContractAmount = m_szrl028.rl02807.ToRound().ToString();
                                _szrl026CBN.AllocationAmount = string.Empty;
                                _szrl026CBN.TaxFreeMoney = (m_szrl028.rl02807 / (1 + rl01835 / 100)).ToRound().ToString();
                                _szrl026CBN.Tax = ((m_szrl028.rl02807 / (1 + rl01835 / 100)) * rl01835 / 100).ToRound().ToString();
                                _szrl026CBN.ContractNumber = m_szrl019.rl01911;
                                _szrl026CBN.ContractName = m_szrl019.rl01903;
                                _szrl026CBN.ContractDate = m_szrl019.rl01910;
                                _szrl026CBN.DateDelivery = m_szrl019.rl01914;
                                _szrl026CBN.CirculationNumber = item.rl02605 == "0" ? "初回" : item.rl02605;
                                _szrl026CBN.DateIssue = Convert.ToDateTime(item.rl02606).ToString("yyyy-MM-dd");
                                _szrl026CBN.BudgetState = item.rl02607 == 0 ? "未预算" : "已预算";
                                L_szrl026CBN.Add(_szrl026CBN);
                                aaount += m_szrl028.rl02807;
                                count_ContractAmount += m_szrl028.rl02807;
                                count_TaxFreeMoney += (m_szrl028.rl02807 / (1 + rl01835 / 100));
                            }

                        }
                        if (list026.Count != 0)
                        {
                            szrl026CBN cbn = new szrl026CBN();
                            cbn.ContractAmount = list026.Select(x => x.rl02605).FirstOrDefault() == "0" ? "初回" : list026.Select(x => x.rl02605).FirstOrDefault();//此处有问题啊
                            cbn.AllocationAmount = aaount.ToRound().ToString();
                            L_szrl026CBN.Add(cbn);
                        }
                    }
                    szrl026CBN cbn2 = new szrl026CBN();
                    cbn2.ContractSerialNum = "合计:";
                    cbn2.ContractAmount = count_ContractAmount.ToRound().ToString();
                    cbn2.AllocationAmount = count_ContractAmount.ToRound().ToString();
                    cbn2.TaxFreeMoney = count_TaxFreeMoney.ToRound().ToString();
                    L_szrl026CBN.Add(cbn2);
                    return L_szrl026CBN;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            // string rl02501 = context.GetValue<string>("rl02501");
            //try
            //{
            //    using (IDbContextScope scope = this._scopeFactory.CreateScope())
            //    {
            //        //查询作番税率
            //        var rl01835 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(rl02501)).Select(x => x.rl01835).FirstOrDefault();
            //        IEnumerable<szrl026> L_szrl026 = this._szrl026Repository.GetModels(x => x.rl02602.Equals(rl02501));
            //        if (L_szrl026.IsNullOrEmpty())
            //        {
            //            return new List<szrl026CBN>();
            //        }
            //        var L_szrl019 = this.GetSzrl019(rl02501);//this._szrl019Repository.GetModels(x => items.Contains(x.rl01901)).ToList();
            //        List<szrl026CBN> L_szrl026CBN = new List<szrl026CBN>();
            //        //var list = L_szrl026.Where(x => x.rl02605.Equals("初回")).ToList();
            //        var Version = Convert.ToInt32(L_szrl026.Max(x => x.rl02605));
            //        Version = Version + 1;
            //        for (int i = 0; i < Version; i++)
            //        {
            //            var list026 = L_szrl026.Where(x => Convert.ToInt32(x.rl02605).Equals(i)).ToList();
            //            var aaount = 0.0m;
            //            foreach (var item in L_szrl019)
            //            {
            //                var m_szrl026 = list026.Where(x => x.rl02603.Equals(item.rl01902)).FirstOrDefault();
            //                if (m_szrl026 != null)
            //                {
            //                    szrl026CBN _szrl026CBN = new szrl026CBN();
            //                    _szrl026CBN.VoucheId = m_szrl026.rl02601;
            //                    _szrl026CBN.IsChange = m_szrl026.rl02604 == 0 ? string.Empty : "是";
            //                    _szrl026CBN.ContractSerialNum = item.rl01904;
            //                    _szrl026CBN.ContractAmount = item.rl01909.ToRound().ToString();
            //                    _szrl026CBN.AllocationAmount = string.Empty;
            //                    _szrl026CBN.TaxFreeMoney = (item.rl01909 / (1 + rl01835 / 100)).ToRound().ToString();
            //                    _szrl026CBN.Tax = (item.rl01907 * rl01835 / 100).ToRound().ToString();
            //                    _szrl026CBN.ContractNumber = item.rl01911;
            //                    _szrl026CBN.ContractName = item.rl01903;
            //                    _szrl026CBN.ContractDate = item.rl01910;
            //                    _szrl026CBN.DateDelivery = item.rl01914;
            //                    _szrl026CBN.CirculationNumber = m_szrl026.rl02605 == "0" ? "初回" : m_szrl026.rl02605;
            //                    _szrl026CBN.DateIssue = m_szrl026.rl02606;
            //                    _szrl026CBN.BudgetState = m_szrl026.rl02607 == 0 ? "未预算" : "已预算";
            //                    L_szrl026CBN.Add(_szrl026CBN);
            //                    aaount += item.rl01909;
            //                }
            //            }
            //            szrl026CBN cbn = new szrl026CBN();
            //            cbn.ContractAmount = list026.FirstOrDefault().rl02605 == "0" ? "初回" : list026.FirstOrDefault().rl02605;
            //            cbn.AllocationAmount = aaount.ToRound().ToString();
            //            L_szrl026CBN.Add(cbn);
            //        }
            //        szrl026CBN cbn2 = new szrl026CBN();
            //        cbn2.ContractSerialNum = "合计:";
            //        cbn2.ContractAmount = (L_szrl019.Select(x => x.rl01909).Sum()).ToRound().ToString();
            //        cbn2.AllocationAmount = (L_szrl019.Select(x => x.rl01909).Sum()).ToRound().ToString();
            //        cbn2.TaxFreeMoney = (L_szrl019.Sum(x => x.rl01909 / (1 + x.rl01908))).ToRound().ToString();

            //        L_szrl026CBN.Add(cbn2);

            //        return L_szrl026CBN;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }


        /// <summary>
        /// 查询是否审核
        /// </summary>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public IOperateResult SelectIsRecognize(szrl025 szrl025)
        {
            if (string.IsNullOrWhiteSpace(szrl025.rl02501))
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "请选择作番");
            }
            var m_szrl025 = this._szrl025Repository.GetModels(x => x.rl02501.Equals(szrl025.rl02501) && x.rl02503.Equals(szrl025.rl02503)).FirstOrDefault();
            if (m_szrl025.rl02532 == 0)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "该受注传票未审核!");
            }
            else
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "该受注传票已审核!");
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="szrl025"></param>
        /// <returns></returns>
        public IOperateResult Update(szrl025 szrl025)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    var m_szrl025 = this._szrl025Repository.Find(x => x.rl02501.Equals(szrl025.rl02501));
                    if (m_szrl025 != null)
                    {
                        szrl025.rl02504 = szrl025.rl02504 ?? string.Empty;
                        szrl025.rl02512 = szrl025.rl02512 ?? string.Empty;
                        szrl025.rl02528 = m_szrl025.rl02528;
                        szrl025.rl02529 = m_szrl025.rl02529; ;
                        szrl025.rl02530 = m_szrl025.rl02530;
                        szrl025.rl02531 = m_szrl025.rl02531;
                        szrl025.rl02532 = m_szrl025.rl02532;
                        szrl025.rl02533 = UserContext.Pj00402;
                        szrl025.rl02534 = DateTime.Now.ToString("yyyy/MM/dd");


                        //保存
                        this._szrl025Repository.Add(szrl025);
                        scope.SaveChanges();
                    }
                    else
                    {
                        return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "该作番的受注传票已存在!");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }


        public IOperateResult ExportExcel(List<szrl026CBN> cnb, string ct1, string ct2, string ct3, string ct4)
        {
            //szrl025Execl szrl025Execl = new szrl025Execl();
            //szrl025Execl.VoucheToExcel(cnb, ct1, ct2, ct3, ct4);
            return OperateResultFactory.BasicOperateResult(null);
        }

        public IOperateResult ExportExcel2(szrl018 szrl018, szrl025 szrl025, string z1821, string z1922, string z2023)
        {
            //szrl025Execl szrl025Execl = new szrl025Execl();
            //szrl025Execl.VoucheToExcel2(szrl018, szrl025, z1821, z1922, z2023);
            return OperateResultFactory.BasicOperateResult(null);
        }

    }
}
