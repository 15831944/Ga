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
using Gmail.DDD.PagedList;

namespace PM2.Service.Code030
{
    public class Szrl888Server : Iszrl888Server
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<szrl888> _szrl888Repository;
        private IUnitOfWork _unitOfWork;
        public Szrl888Server(
            IDbContextScopeFactory scopeFactory,
            IUnitOfWork unitOfWork,
            IEFRepository<szrl888> szrl888Repository
        )
        {
            this._scopeFactory = scopeFactory;
            this._unitOfWork = unitOfWork;
            this._szrl888Repository = szrl888Repository;
        }

        public async Task<IOperateResult> add(szrl888 _szrl888)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    this._szrl888Repository.Add(_szrl888);
                    await scope.SaveChangesAsync();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "");
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, ex.Message);
            }
        }
        /// <summary>
        /// 编辑页面保存方法
        /// </summary>
        /// <param name="_szrl888"></param>
        /// <returns></returns>
        public async Task<IOperateResult> edit(szrl888 _szrl888)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    this._szrl888Repository.Update(_szrl888);
                    await scope.SaveChangesAsync();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, _szrl888.rl88801);
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, ex.Message);
            }
        }

        public async Task<IOperateResult> info(IPageContext context)
        {
            TaskAsync.StartAsync();
            try
            {
                return await Task.Factory.StartNew<IOperateResult>(() =>
                {
                    try
                    {
                        using (IDbContextScope scope = this._scopeFactory.CreateScope())
                        {
                            IPagedList pageList = this._szrl888Repository.GetModels(
                                context,
                                x => true,
                                x => x.Asc(o => o.rl88802)
                            );
                            return OperateResultFactory.GridOperateResult(pageList);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IOperateResult> remove(string vid)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl888 query_szrl888 = new szrl888 { rl88801 = vid };
                    this._szrl888Repository.Remove(query_szrl888);
                    await scope.SaveChangesAsync();
                }
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, "删除成功!");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <param name="vid">主键</param>
        /// <returns></returns>
        public async Task<IOperateResult> editinfo(string vid)
        {
            try
            {
                using (IDbContextScope scope = this._scopeFactory.CreateScope())
                {
                    szrl888 query_szrl888 = await this._szrl888Repository.FindAsync(vid);
                    return OperateResultFactory.BasicOperateResult(query_szrl888);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<IOperateResult> GetModuleWeb()
        {
            try
            {
                IEnumerable<GetModuleWeb_Model> data = null, data1 = null, data2 = null, data3 = null, data4 = null;
                using (IDbContextReadOnlyScope scope = this._scopeFactory.CreateReadOnlyScope())
                {
                    data = await this._unitOfWork.ExecuteSqlQueryAsync<GetModuleWeb, GetModuleWeb_Model>(new GetModuleWeb { loginCode = "1001" });
                    data1 = await this._unitOfWork.ExecuteSqlQueryAsync<GetModuleWeb, GetModuleWeb_Model>(new GetModuleWeb { loginCode = "1001" });
                    data2 = await this._unitOfWork.ExecuteSqlQueryAsync<GetModuleWeb, GetModuleWeb_Model>(new GetModuleWeb { loginCode = "1001" });
                    data3 = await this._unitOfWork.ExecuteSqlQueryAsync<GetModuleWeb, GetModuleWeb_Model>(new GetModuleWeb { loginCode = "1001" });
                    data4 = await this._unitOfWork.ExecuteSqlQueryAsync<GetModuleWeb, GetModuleWeb_Model>(new GetModuleWeb { loginCode = "1001" });
                }
                IEnumerable<IEasyTreeNode> treeNodes = from x in data
                                                       select new EasyTreeNode {
                                                           ID = x.moduleCode,
                                                           Text = x.moduleCaption,
                                                           ParentId = x.eb00303,
                                                           OrderBy = x.eb00315,
                                                           Params = new { nodeType = "sdeb003" }
                                                       };
                return OperateResultFactory.TreeOperateResult(treeNodes, "模块信息");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
