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
using Gmail.DDD.Config;

namespace PM2.Service.Code030
{
    public class szrl116Server : Iszrl116Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl116> _szrl116Repository;
        private IEFRepository<szrl018> _szrl018Repository;//作番表
        private IEFRepository<szrl019> _szrl019Repository;//合同表
        private IEFRepository<sdpj004> _sdpj004Repository;//员工表
        private IEFRepository<szrl045> _szrl045Repository;//开票登记明细
        private IEFRepository<szrl040> _szrl040Repository;//开票通知明细
        private IEFRepository<szrl044> _szrl044Repository;//开票登记
        private IEFRepository<szrl043> _szrl043Repository;//B类发包计划
        private IEFRepository<szrl043d> _szrl043dRepository;//B类发包计划明细
        public szrl116Server(
             IDbContextScopeFactory scopeFactory,
             IEFRepository<szrl116> szrl116Repository,
             IEFRepository<szrl018> szrl018Repository,
             IEFRepository<szrl019> szrl019Repository,
             IEFRepository<sdpj004> sdpj004Repository,
             IEFRepository<szrl045> szrl045Repository,
             IEFRepository<szrl040> szrl040Repository,
             IEFRepository<szrl044> szrl044Repository,
             IEFRepository<szrl043> szrl043Repository,
             IEFRepository<szrl043d> szrl043dRepository
       )
        {
            this._scopeFactory = scopeFactory;
            this._szrl116Repository = szrl116Repository;
            this._szrl018Repository = szrl018Repository;
            this._szrl019Repository = szrl019Repository;
            this._sdpj004Repository = sdpj004Repository;
            this._szrl045Repository = szrl045Repository;
            this._szrl040Repository = szrl040Repository;
            this._szrl044Repository = szrl044Repository;
            this._szrl043Repository = szrl043Repository;
            this._szrl043dRepository = szrl043dRepository;
        }

        public IEnumerable<szrl116TableEntity> QueryOfferTable(int pageIndex, int pageSize, out int rowCount)
        {
            try
            {
                PageCollection o = new PageCollection(null)
                {
                    PageNumber = pageIndex,
                    PageSize = pageSize
                }; 
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IQueryable<szrl045> szrl045s = this._szrl045Repository.GetModels();
                    IQueryable<szrl040> szrl040s = this._szrl040Repository.GetModels();
                    IQueryable<sdpj004> sdpj004s = this._sdpj004Repository.GetModels();
                    IQueryable<szrl044> szrl044s = this._szrl044Repository.GetModels(j => j.rl04411 == 1);
                    //ps:这个方法到时候还要联合B类发包计划表
                    var query = from a in this._szrl116Repository.GetModels(x => x.rl11618 != 1)
                                let v = (
                                //szrl045s.Where(k => k.rl04503.Equals(a.rl11638)).Sum(k => k.rl04506)
                                (from k in szrl045s
                                 join j in szrl044s
                                 on k.rl04502 equals j.rl04401
                                 where k.rl04503.Equals(a.rl11638)
                                 select k.rl04506).Sum()
                                )
                                join b in _szrl018Repository.GetModels()   //作番表
                                on a.rl11602 equals b.rl01801             //a.rl11602是外键， b.rl01801是作番表主键
                                join c in _szrl019Repository.GetModels(c => c.rl01971 == 1 && c.rl01964 == 1)   //合同表
                                on a.rl11603 equals c.rl01902              //a.rl11603是外键， b.rl01902是合同表合同ID
                                orderby a.rl11637
                                where a.rl11606 != (from k in szrl045s
                                                    join j in szrl044s
                                                    on k.rl04502 equals j.rl04401
                                                    where k.rl04503.Equals(a.rl11638) 
                                                    select k.rl04506).Sum()
                                select new szrl116TableEntity
                                {
                                    rl11601 = a.rl11601,
                                    rl11602 = a.rl11602,
                                    rl11603 = a.rl11603,
                                    rl11604 = a.rl11604,
                                    rl11605 = a.rl11605,
                                    rl11606 = a.rl11606 - (v == null? 0: v),
                                    rl11607 = a.rl11607,
                                    rl11608 = a.rl11608,
                                    rl11609 = a.rl11609,
                                    rl11610 = a.rl11610,
                                    rl11611 = a.rl11611,
                                    rl11612 = a.rl11612,
                                    rl11613 = a.rl11613,
                                    rl11614 = a.rl11614,
                                    rl11615 = a.rl11615,
                                    rl11616 = a.rl11616,
                                    rl11617 = a.rl11617,
                                    rl11618 = a.rl11618,
                                    rl11619 = a.rl11619,
                                    rl11620 = a.rl11620,
                                    rl11621 = a.rl11621,
                                    rl11622 = a.rl11622,
                                    rl11623 = a.rl11623,
                                    rl11624 = a.rl11624,
                                    rl11625 = a.rl11625,
                                    rl11626 = a.rl11626,
                                    rl11627 = a.rl11627,
                                    rl11628 = a.rl11628,
                                    rl11629 = a.rl11629,
                                    rl11630 = a.rl11630,
                                    rl01806 = b.rl01806,
                                    rl01904 = c.rl01904,
                                    rl01903 = c.rl01903,
                                    rl01909 = c.rl01909,
                                    rl11636 = a.rl11636,
                                    rl11638 = (from z in szrl040s
                                               where z.rl04001.Equals(a.rl11638)
                                               select z.rl04002).FirstOrDefault(),
                                    rl11639 = a.rl11639,
                                    rl11631 = a.rl11631,
                                    rl11632 = a.rl11632,
                                    rl11633 = a.rl11633,
                                    rl11634 = a.rl11634,
                                    rl11635 = (
                                    from k in sdpj004s
                                    where k.pj00401.Equals(a.rl11635)
                                    select k.pj00402
                                    ).FirstOrDefault(),
                                };
                    rowCount = query.Count();

                    var xxx = query.ToPagedList<szrl116TableEntity>(o).ToArray();
                    return xxx;
                    //return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null, new {
                    //    Count = rowCount,
                    //    szrl116s = query.ToPagedList<szrl116TableEntity>(o)
                    //});
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IOperateResult ClickOfferSendBag(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11614 = model.rl11614;
                    view_model.rl11607 = model.rl11607;
                    view_model.rl11613 = model.rl11613;
                    view_model.rl11609 = model.rl11609;
                    view_model.rl11616 = model.rl11616;
                    view_model.rl11617 = model.rl11617;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "保存成功!");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "保存失败!");
            }
        }
        public IOperateResult ClickPlanB(szrl116 model, string zuofanid, string hetongid)
        {
            try
            { 
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    //08 = ""，没有就替换，有就不替换
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    if (string.IsNullOrEmpty(view_model.rl11608) && (model.rl11607 == 2 || model.rl11607 ==3))
                    {
                        //取已审核的单据的审核时间最晚的一张单
                        var query = from x in this._szrl043Repository.GetModels(x => x.rl04302 == zuofanid && x.rl04303 == hetongid && x.rl04308 == 1)
                                    join y in this._szrl043dRepository.GetModels()
                                    on x.rl04301 equals y.rl043d02
                                    orderby x.rl04307 descending
                                    select new
                                    {
                                        rl043d03 = y.rl043d03,  //年月
                                        rl043d04 = y.rl043d04,  //工事名称
                                        rl043d05 = y.rl043d05,  //发包金额
                                        rl043d06 = y.rl043d06,  //发包单位
                                        rl043d07 = y.rl043d07   //担当者
                                    };
                        var result_lst = query.ToList().FirstOrDefault();
                        if (result_lst != null)
                        {
                            DateTime a = Convert.ToDateTime(result_lst.rl043d03);
                            string year = a.Year.ToString();
                            string month = a.Month.ToString();
                            if (month.Length == 1)
                            {
                                view_model.rl11631 = year + "-0" + month;
                            }
                            else
                            {
                                view_model.rl11631 = year + "-" + month;
                            } 
                            view_model.rl11632 = result_lst.rl043d04;
                            view_model.rl11633 = Convert.ToDecimal(result_lst.rl043d05);
                            view_model.rl11634 = result_lst.rl043d06;
                            view_model.rl11635 = result_lst.rl043d07;
                        }
                    }
                    view_model.rl11607 = model.rl11607;
                    view_model.rl11615 = model.rl11615;
                    view_model.rl11616 = model.rl11616;
                    view_model.rl11617 = model.rl11617;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult QueryWarmLists(IPageContext context)
        {
            try
            {
                IPagedList pagedList = null;
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    string CurrentUser = UserContext.Pj00402;
                    IQueryable<szrl045> szrl045s = this._szrl045Repository.GetModels();
                    IQueryable<szrl044> szrl044s = this._szrl044Repository.GetModels(j => j.rl04411 == 1);
                    //CurrentUser = "张书豪";    //记得去掉 只是方便
                    //IEnumerable<szrl116> lists = ;
                    var query = from a in this._szrl116Repository.GetModels(x => x.rl11613 == 1 && x.rl11618 == 0 && x.rl11611 == 0)
                                let v = (
                                (from k in szrl045s
                                 join j in szrl044s
                                 on k.rl04502 equals j.rl04401
                                 where k.rl04503.Equals(a.rl11638)
                                 select k.rl04506).Sum()
                                )
                                join b in _szrl018Repository.GetModels()    //作番表
                                on a.rl11602 equals b.rl01801
                                join c in _sdpj004Repository.GetModels(y => y.pj00402 == CurrentUser)   //员工表
                                on b.rl01811 equals c.pj00401
                                join d in _szrl019Repository.GetModels(c=> c.rl01971 == 1 && c.rl01964 == 1)   //合同表
                                on a.rl11603 equals d.rl01902
                                orderby a.rl11637
                                select new szrl116WarmList
                                {
                                    ZhuJian = a.rl11601,
                                    ZuoFanHao = b.rl01806,
                                    HeTongHao = d.rl01904,
                                    HeTongMingCheng = d.rl01903,
                                    HeTongJinE = d.rl01909,
                                    BenCiKaiPiaoJinE = a.rl11606 - (v == null ? 0 : v)
                                };
                    pagedList = query.ToPagedList<szrl116WarmList>(context);
                    return OperateResultFactory.GridOperateResult(pagedList);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IOperateResult HaveDone(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11610 = model.rl11610;
                    view_model.rl11636 = model.rl11636;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult NextTime(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11610 = model.rl11610;
                    view_model.rl11636 = model.rl11636;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult ReturnBtn(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11610 = model.rl11610;
                    view_model.rl11636 = model.rl11636;
                    view_model.rl11612 = model.rl11612;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult AcceptBtn(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11611 = model.rl11611;
                    view_model.rl11636 = model.rl11636;
                    view_model.rl11616 = model.rl11616;
                    view_model.rl11617 = model.rl11617;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult KPRQ(szrl116 model)
        { 
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11639 = model.rl11639;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
        public IOperateResult GCBCL(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11607 = model.rl11607;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }

        public IOperateResult GCBCLGB(szrl116 model)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl116 view_model = new szrl116();
                    view_model = this._szrl116Repository.Find(x => x.rl11601 == model.rl11601);
                    view_model.rl11607 = model.rl11607;
                    this._szrl116Repository.Update(view_model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "");
            }
        }
    }
}