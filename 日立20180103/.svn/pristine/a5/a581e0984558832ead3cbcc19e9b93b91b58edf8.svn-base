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
using PM2.Models.Code030.szrl033Model;

namespace PM2.Service.Code030
{
    public class szrl030Server : Iszrl030Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl019> _szrl019Repository;    //szrl019.营业合同验收登记
        private IEFRepository<szrl022> _szrl022Repository;    //szrl022.营业合同验收收款计划
        private IEFRepository<szrl024> _szrl024Repository;    //szrl024.营业合同验收计划明细
        private IEFRepository<szrl030> _szrl030Repository;    //szrl030.验收收款计划更新
        private IEFRepository<szrl032> _szrl032Repository;    //szrl032.验收收款计划更新明细
        private IEFRepository<szrl023> _szrl023Repository;    //szrl023.款项性质
        private IEFRepository<sdpj004> _sdpj004Repository;    //员工表
        public szrl030Server(
              IDbContextScopeFactory scopeFactory,
              IEFRepository<szrl019> szrl019Repository,
              IEFRepository<szrl022> szrl022Repository,
              IEFRepository<szrl024> szrl024Repository,
              IEFRepository<szrl030> szrl030Repository,
              IEFRepository<szrl032> szrl032Repository,
              IEFRepository<sdpj004> sdpj004Repository,
              IEFRepository<szrl023> szrl023Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._szrl019Repository = szrl019Repository;
            this._szrl022Repository = szrl022Repository;
            this._szrl024Repository = szrl024Repository;
            this._szrl030Repository = szrl030Repository;
            this._szrl032Repository = szrl032Repository;
            this._sdpj004Repository = sdpj004Repository;
            this._szrl023Repository = szrl023Repository;
        }
         
        public IOperateResult QueryBasicData(HttpCollection vParams)
        {
            try
            {
                string HeTongId = vParams.GetValue<string>("hetongid");
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    bool _IsReadFrom3032 = false;
                    IQueryable<sdpj004> sdpj004s = this._sdpj004Repository.GetModels();
                    List<szrl030> isHasVal = this._szrl030Repository.GetModels(x => x.rl03002 == HeTongId && x.rl03009 == 0).ToList();
                    IQueryable<object> query;
                    if (isHasVal.Count() > 0)
                    {
                        query = from a in this._szrl019Repository.GetModels(x => x.rl01902 == HeTongId && x.rl01964 == 1 && x.rl01971 == 1)
                                join b in this._szrl030Repository.GetModels()
                                on a.rl01902 equals b.rl03002
                                //join c in this._sdpj004Repository.GetModels()
                                //on b.rl03005 equals c.pj00401
                                select new szrl030BasicData
                                {
                                    hetongxuliehao = a.rl01904,
                                    hetongmingcheng = a.rl01903,
                                    hetongjine = b.rl03003,
                                    zhifutiaojian = a.rl01919,
                                    fukuanzhouqi = b.rl03004,
                                    kaipiaoyujizhouqi = b.rl03012,
                                    zhidanren = (
                                        from k in sdpj004s
                                        where k.pj00401.Equals(b.rl03005)
                                        select k.pj00402
                                    ).FirstOrDefault(),
                                    zhidanriqi = b.rl03006,
                                    shenheren = (
                                        from k in sdpj004s
                                        where k.pj00401.Equals(b.rl03007)
                                        select k.pj00402
                                    ).FirstOrDefault(),
                                    shenheriqi = b.rl03008
                                };
                        _IsReadFrom3032 = true;
                    }
                    else
                    {
                        query = from a in this._szrl019Repository.GetModels(x => x.rl01902 == HeTongId && x.rl01964 == 1 && x.rl01971 == 1)
                                join b in this._szrl022Repository.GetModels(y => y.rl02208 == 1)
                                on a.rl01902 equals b.rl02202
                                //join c in this._sdpj004Repository.GetModels()
                                //on b.rl02209 equals c.pj00401
                                select new szrl030BasicData
                                {
                                    hetongxuliehao = a.rl01904,
                                    hetongmingcheng = a.rl01903,
                                    hetongjine = a.rl01909,
                                    zhifutiaojian = a.rl01919,
                                    fukuanzhouqi = b.rl02203,
                                    kaipiaoyujizhouqi = b.rl02204,
                                    zhidanren = (
                                        from k in sdpj004s
                                        where k.pj00401.Equals(b.rl02209)
                                        select k.pj00402
                                    ).FirstOrDefault(),
                                    zhidanriqi = b.rl02210,
                                    shenheren = (
                                        from k in sdpj004s
                                        where k.pj00401.Equals(b.rl02211)
                                        select k.pj00402
                                    ).FirstOrDefault(),
                                    shenheriqi = b.rl02212
                                }; 
                    }
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "", new
                    {
                        query = query.ToList(),
                        IsReadFrom3032 = _IsReadFrom3032
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IOperateResult QueryGridData(HttpCollection vParams)
        {
            try
            {
                string HeTongId = vParams.GetValue<string>("hetongid");
                //HeTongId = "c38a965e-bce2-42cc-b5a9-1d718f726456";
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    IQueryable<szrl023> szrl023s = this._szrl023Repository.GetModels();
                    List<szrl030> isHasVal = this._szrl030Repository.GetModels(x => x.rl03002 == HeTongId && x.rl03009 == 0).ToList();
                    IQueryable<object> query;
                    if (isHasVal.Count() > 0)
                    {
                        query = from a in this._szrl030Repository.GetModels(x => x.rl03002 == HeTongId && x.rl03009 == 0)
                                join b in this._szrl032Repository.GetModels()
                                on a.rl03001 equals b.rl03202
                                select new
                                {
                                    YuanKXXZ = (
                                    from k in szrl023s
                                    where k.rl02301.Equals(b.rl03203)
                                    select k.rl02302
                                    ).FirstOrDefault(),

                                    YuanBL = b.rl03204,
                                    YuanJE = b.rl03205,
                                    YuanYSRQ = b.rl03206,
                                    YuanSKRQ = b.rl03207,
                                    XinKXXZ = (
                                        from k in szrl023s
                                        where k.rl02301.Equals(b.rl03213)
                                        select k.rl02302
                                    ).FirstOrDefault(),

                                    XinBL = b.rl03208,
                                    XinJE = b.rl03209,
                                    XinYSRQ = b.rl03210,
                                    XinSKRQ = b.rl03211,
                                    ZhuangTai = b.rl03212
                                };
                    }
                    else
                    {
                        query = from a in this._szrl022Repository.GetModels(x => x.rl02202 == HeTongId && x.rl02208 == 1)
                                join b in this._szrl024Repository.GetModels()
                                on a.rl02201 equals b.rl02402
                                //join c in this._szrl023Repository.GetModels()
                                //on b.rl02403 equals c.rl02301
                                select new {
                                    YuanKXXZ = (
                                    from k in szrl023s
                                    where k.rl02301.Equals(b.rl02403)
                                    select k.rl02302
                                    ).FirstOrDefault(),
                                    YuanBL = b.rl02404,
                                    YuanJE = b.rl02405,
                                    YuanYSRQ = b.rl02406,
                                    YuanSKRQ = b.rl02407,
                                    XinKXXZ = (
                                        from k in szrl023s
                                        where k.rl02301.Equals(b.rl02403)
                                        select k.rl02302
                                    ).FirstOrDefault(),
                                    XinBL = b.rl02404,
                                    XinJE = b.rl02405,
                                    XinYSRQ = b.rl02406,
                                    XinSKRQ = b.rl02407,
                                    ZhuangTai = b.rl02408
                                };
                    }
                    return OperateResultFactory.GridOperateResult(query.ToList());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IOperateResult QueryKXXZ(HttpCollection vParams)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    var query = from a in this._szrl023Repository.GetModels()
                                select new szrl023KXXZ
                                {
                                    rl02301 = a.rl02301,
                                    rl02302 = a.rl02302,
                                    rl02303 = a.rl02303,
                                    rl02304 = a.rl02304
                                };
                    return OperateResultFactory.GridOperateResult(query.ToList());
                }
            }
            catch (Exception ex)
            {
                throw;
            } 
        }

        public IOperateResult Insert3032(IRequestGetter vParams)
        {
            try
            {
                List<szrl030GridData> YJH_Grid_data = vParams.GetValue<List<szrl030GridData>>("YJH_Grid_data", GetterType.JToken);
                List<szrl030GridData> SKJH_Grid_data = vParams.GetValue<List<szrl030GridData>>("SKJH_Grid_data", GetterType.JToken);
                //string hetongxuliehao = vParams.GetValue<string>("hetongxuliehao");
                //string hetongmingcheng = vParams.GetValue<string>("hetongmingcheng");
                string hetongjine = vParams.GetValue<string>("hetongjine");
                //string zhifutiaojian = vParams.GetValue<string>("zhifutiaojian");
                string fukuanzhouqi = vParams.GetValue<string>("fukuanzhouqi");
                string kaipiaoyujizhouqi = vParams.GetValue<string>("kaipiaoyujizhouqi");
                //string zhidanren = vParams.GetValue<string>("zhidanren");
                //string zhidanriqi = vParams.GetValue<string>("zhidanriqi");
                //string shenheren = vParams.GetValue<string>("shenheren");
                //string shenheriqi = vParams.GetValue<string>("shenheriqi");
                string hetongid = vParams.GetValue<string>("hetongid");
                List<szrl032> _032lst = new List<szrl032>();
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    var _030guid = Guid.NewGuid().ToString();
                    szrl030 _030model = new szrl030()
                    {
                        rl03001 = _030guid,
                        rl03002 = hetongid,
                        rl03003 = Convert.ToDecimal(hetongjine),
                        rl03004 = Convert.ToDecimal(fukuanzhouqi),
                        rl03005 = UserContext.Pj00401,
                        rl03006 = DateTime.Now.ToString("yyyy-MM-dd"),
                        rl03007 = "",
                        rl03008 = "",
                        rl03009 = 0,
                        rl03010 = UserContext.Pj00401,
                        rl03011 = DateTime.Now.ToString("yyyy-MM-dd"),
                        rl03012 = Convert.ToDecimal(kaipiaoyujizhouqi)
                    }; 
                    for (var i = 0; i < YJH_Grid_data.Count; i++)
                    {
                        byte rl03212 = 0;
                        if (!string.IsNullOrEmpty(SKJH_Grid_data[i].ZhuangTai))
                        {
                            switch (SKJH_Grid_data[i].ZhuangTai)
                            {
                                case "未验收": rl03212 = 0; break;
                                case "已验收": rl03212 = 1; break;
                                case "0": rl03212 = 0; break;
                                case "1": rl03212 = 1; break;
                            }
                        }
                        szrl032 _032model = new szrl032()
                        {
                            rl03201 = Guid.NewGuid().ToString(),
                            rl03202 = _030guid,
                            rl03203 = string.IsNullOrEmpty(YJH_Grid_data[i].YuanKXXZ) ? "" : YJH_Grid_data[i].YuanKXXZ,
                            rl03204 = string.IsNullOrEmpty(YJH_Grid_data[i].YuanBL.ToString()) ? 0 : YJH_Grid_data[i].YuanBL,
                            rl03205 = string.IsNullOrEmpty(YJH_Grid_data[i].YuanJE.ToString()) ? 0 : YJH_Grid_data[i].YuanJE,
                            rl03206 = string.IsNullOrEmpty(YJH_Grid_data[i].YuanYSRQ) ? "" : YJH_Grid_data[i].YuanYSRQ,
                            rl03207 = string.IsNullOrEmpty(YJH_Grid_data[i].YuanSKRQ) ? "" : YJH_Grid_data[i].YuanSKRQ,
                            rl03208 = string.IsNullOrEmpty(SKJH_Grid_data[i].XinBL.ToString()) ? 0 : SKJH_Grid_data[i].XinBL,
                            rl03209 = string.IsNullOrEmpty(SKJH_Grid_data[i].XinJE.ToString()) ? 0 : SKJH_Grid_data[i].XinJE,
                            rl03210 = string.IsNullOrEmpty(SKJH_Grid_data[i].XinYSRQ) ? "" : SKJH_Grid_data[i].XinYSRQ,
                            rl03211 = string.IsNullOrEmpty(SKJH_Grid_data[i].XinSKRQ) ? "" : SKJH_Grid_data[i].XinSKRQ,
                            rl03212 = rl03212,
                            rl03213 = string.IsNullOrEmpty(SKJH_Grid_data[i].XinKXXZ) ? "" : SKJH_Grid_data[i].XinKXXZ
                        };
                        if (!string.IsNullOrEmpty(_032model.rl03203))
                        {
                            _032model.rl03203 = this._szrl023Repository.Find(a => a.rl02302 == _032model.rl03203).rl02301;
                        }
                        else
                        {
                            _032model.rl03203 = "";
                        }
                        if (!string.IsNullOrEmpty(_032model.rl03213))
                        {
                            _032model.rl03213 = this._szrl023Repository.Find(b => b.rl02302 == _032model.rl03213).rl02301;
                        }
                        else
                        {
                            _032model.rl03213 = "";
                        }
                        this._szrl032Repository.Add(_032model);
                    }
                    this._szrl030Repository.Add(_030model);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IOperateResult Insert2224(HttpCollection vParams)
        {
            try
            {
                string hetongid = vParams.GetValue<string>("hetongid");
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    //找到22表中的实体，把是否为正式版本改为0
                    szrl022 _022upmodel = this._szrl022Repository.Find(a => a.rl02202 == hetongid && a.rl02208 == 1);
                    //根据营业合同id找实体
                    szrl030 _030model = this._szrl030Repository.Find(x => x.rl03002 == hetongid && x.rl03009 == 0);
                    //根据验收计划变更ID找到详情列表
                    List<szrl032> _032lst = this._szrl032Repository.GetModels(y => y.rl03202 == _030model.rl03001).ToList();
                    //根据营业合同id在22表找到当前版本号 
                    //int _022model_bbh = this._szrl022Repository.GetModels(z => z.rl02202 == hetongid && z.rl02208 == 1).ToList().Select(z=>z.rl02205).Max();
                    int _022model_bbh = (from c in this._szrl022Repository.GetModels().ToList()
                                         where c.rl02202 == hetongid && c.rl02208 == 1
                                         orderby c.rl02205 descending
                                         select c.rl02205).FirstOrDefault();
                    //022表的主键Guid
                    string _022Guid = Guid.NewGuid().ToString();
                    szrl022 _022model = new szrl022()
                    {
                        rl02201 = _022Guid,
                        rl02202 = hetongid,
                        rl02203 = _030model.rl03004,
                        rl02204 = _030model.rl03012, 
                        rl02205 = _022model_bbh + 1,
                        rl02206 = "",
                        rl02207 = "",
                        rl02208 = 1,
                        rl02209 = _030model.rl03005,
                        rl02210 = _030model.rl03006,
                        rl02211 = UserContext.Pj00401,
                        rl02212 = DateTime.Now.ToString("yyyy-MM-dd"),
                        rl02213 = 1,
                        rl02214 = UserContext.Pj00401,
                        rl02215 = DateTime.Now.ToString("yyyy-MM-dd"),
                        rl02216 = _030model.rl03003
                    };
                    List<szrl024> _024lst = new List<szrl024>();
                    foreach (var item in _032lst)
                    {
                        this._szrl024Repository.Add(new szrl024()
                        {
                            rl02401 = Guid.NewGuid().ToString(),
                            rl02402 = _022Guid,
                            rl02403 = item.rl03213,
                            rl02404 = item.rl03208,
                            rl02405 = item.rl03209,
                            rl02406 = item.rl03210,
                            rl02407 = item.rl03211,
                            rl02408 = item.rl03212
                        });
                    };
                    this._szrl022Repository.Add(_022model);
                    //不仅要往22、24表里面插数据，还要修改30表中的审核状态改为1 
                    _030model.rl03009 = 1;
                    this._szrl030Repository.Update(_030model);
                    //并且修改22表中的旧数据是否为正式版本改为0
                    _022upmodel.rl02208 = 0;
                    this._szrl022Repository.Update(_022upmodel);

                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
