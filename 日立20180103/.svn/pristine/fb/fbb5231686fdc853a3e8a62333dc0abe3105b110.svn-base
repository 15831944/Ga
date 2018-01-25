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

namespace PM2.Service.Code030
{
    public class sdbo004Server : Isdbo004Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<sdbo004> _sdbo004Repository;
        private IEFRepository<sdbo005> _sdbo005Repository;
        private IEFRepository<szrl018> _szrl018Repository;
        public sdbo004Server(
            IDbContextScopeFactory scopeFactory,
            IEFRepository<sdbo004> sdbo004Repository,
            IEFRepository<sdbo005> sdbo005Repository,
            IEFRepository<szrl018> szrl018Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._sdbo004Repository = sdbo004Repository;
            this._sdbo005Repository = sdbo005Repository;
            this._szrl018Repository = szrl018Repository;
        }
        /// <summary>
        /// 添加或者编辑
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        public IOperateResult Add(Staffing_sdbo004 sf)
        {
            return null;
            //try
            //{
            //    using (IDbContextScope scope = this._scopeFactory.CreateScope())
            //    {
            //        string zuofanid = sf.bo00150;
            //        if (string.IsNullOrWhiteSpace(zuofanid))
            //        {

            //        }
            //        sdbo004 query_sdbo004 = this._sdbo004Repository.GetModels(x => x.bo00402.Equals(zuofanid)).FirstOrDefault();
            //        if (query_sdbo004==null)
            //        {
            //            this._sdbo004Repository.Add(query_sdbo004);
                        
            //            for (int i = 0; i < 2; i++)
            //            {
            //                sdbo005 query_sdbo005 = new sdbo005();
            //                query_sdbo005.bo00502 = (byte)(i);
            //                for (int ii = 0; ii < 4; ii++)
            //                {
            //                    query_sdbo005.bo00503 = (byte)ii;
            //                    if (i==0)
            //                    {
            //                        for (int iii = 0; iii < 4; iii++)
            //                        {
            //                            query_sdbo005.bo00504 = (byte)iii;
            //                            if (true)
            //                            {

            //                            }
            //                            query_sdbo005.bo00505 = string.Empty;
            //                            query_sdbo005.bo00506 = zuofanid;
            //                        }
            //                    }
            //                    if (i==1)
            //                    {
            //                        for (int iii = 0; i < 6; i++)
            //                        {
            //                            query_sdbo005.bo00504 = (byte)iii;
            //                            query_sdbo005.bo00505 = zuofanid;
            //                        }
            //                    }
            //                }
            //            }


            //        }
            //        else
            //        {
            //            this._sdbo004Repository.Update(query_sdbo004);
            //            IEnumerable<sdbo005> query_sdbo005s = this._sdbo005Repository.GetModels(x => x.bo00506.Equals(zuofanid));
            //            foreach (var item in query_sdbo005s)
            //            {

            //            }
            //        }
            //        return null;
                   
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="vParams"></param>
        /// <returns></returns>
        public IOperateResult GetIndexInfo(IRequestGetter context)
        {
            string zuofanid = context.GetValue<string>("zuofanid");
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    sdbo004 query_sdbo004 = this._sdbo004Repository.Find(x => x.bo00402.Equals(zuofanid));
                    IEnumerable<sdbo005> query_sdbo005 = this._sdbo005Repository.GetModels(x => x.bo00506.Equals(zuofanid));
                    Staffing_sdbo004 sf = CombinatorialEntity(query_sdbo004, query_sdbo005, zuofanid);
                    return OperateResultFactory.FromLoadOperateResult(sf);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 重新赋值
        /// </summary>
        /// <param name="query_sdbo004"></param>
        /// <param name="query_sdbo005"></param>
        /// <param name="zuofanid"></param>
        /// <returns></returns>
        private Staffing_sdbo004 CombinatorialEntity(sdbo004 query_sdbo004, IEnumerable<sdbo005> query_sdbo005, string zuofanid)
        {
            Staffing_sdbo004 sf = new Staffing_sdbo004();
            sf.bo00101 = query_sdbo004.bo00401;
            sf.bo00102 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(zuofanid)).Select(x => x.rl01806).FirstOrDefault();//作番编号
            sf.bo00103 = this._szrl018Repository.GetModels(x => x.rl01801.Equals(zuofanid)).Select(x => x.rl01807).FirstOrDefault();//作番名称
            #region 现场审批
            //sf.bo00104 = query_sdbo004.bo00405;//本部长
            //                                   //sf.bo00104= query_sdbo004.
            //sf.bo00105 = query_sdbo004.bo00406;//所长
            //                                   //工事长
            //sf.bo00106 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00107 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00108 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00109 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            ////科长
            //sf.bo00110 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00111 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00112 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00113 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            ////建筑担当
            //sf.bo00114 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00115 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00116 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(4)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00117 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(5)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00118 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(0) && x.bo00504.Equals(6)).Select(x => x.bo00505).FirstOrDefault();
            ////机械担当
            //sf.bo00119 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00120 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00121 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(4)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00122 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(5)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00123 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(1) && x.bo00504.Equals(6)).Select(x => x.bo00505).FirstOrDefault();
            ////电气担当
            //sf.bo00124 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00125 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00126 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(4)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00127 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(5)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00128 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(2) && x.bo00504.Equals(6)).Select(x => x.bo00505).FirstOrDefault();
            ////成套担当
            //sf.bo00129 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00130 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00131 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(4)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00132 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(5)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00133 = query_sdbo005.Where(x => x.bo00502.Equals(1) && x.bo00503.Equals(3) && x.bo00504.Equals(6)).Select(x => x.bo00505).FirstOrDefault();
            //#endregion
            //#region 非现场审批
            ////采购部
            //sf.bo00134 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(0) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00135 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(0) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00136 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(0) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00137 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(0) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            ////工程管理室
            //sf.bo00138 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(1) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00139 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(1) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00140 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(1) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00141 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(1) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            ////财务部
            //sf.bo00142 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(2) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00143 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(2) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00144 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(2) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00145 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(2) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            ////营业部
            //sf.bo00146 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(3) && x.bo00504.Equals(0)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00147 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(3) && x.bo00504.Equals(1)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00148 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(3) && x.bo00504.Equals(2)).Select(x => x.bo00505).FirstOrDefault();
            //sf.bo00149 = query_sdbo005.Where(x => x.bo00502.Equals(0) && x.bo00503.Equals(3) && x.bo00504.Equals(3)).Select(x => x.bo00505).FirstOrDefault();
            #endregion
            //作番id
            sf.bo00150 = zuofanid;
            return sf;
        }
    }
}
