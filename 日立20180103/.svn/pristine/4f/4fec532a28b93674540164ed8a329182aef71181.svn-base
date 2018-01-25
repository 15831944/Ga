using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gmail.DDD.Service;
using Gmail.DDD.DBContextScope;
using Gmail.DDD.Repositorys;
using Gmail.DDD.Entity;
using System.Linq.Expressions;

namespace PM2.Service.Code030.CM
{
    public class CmDataService<TEntity> : ICmDataService<TEntity> where TEntity : Enttity
    {
        private IDbContextScopeFactory _scopeFactory;
        private IEFRepository<TEntity> _entityRepository;

        public CmDataService(IDbContextScopeFactory scopeFactory, IEFRepository<TEntity> entity0Repository)
        {
            _scopeFactory = scopeFactory;
            _entityRepository = entity0Repository;
        }

        //public void Commit()
        //{

        //}

        public IOperateResult Delete(TEntity entity)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    if (entity != null)
                    {
                        _entityRepository.Remove(entity);
                        scope.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "删除出错！");
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }

        public int Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<object> keys)
        {
            throw new NotImplementedException();
        }

        public IOperateResult Delete(Expression<Func<TEntity, bool>> exp)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var item = _entityRepository.GetModels(exp).FirstOrDefault();
                    if (item != null)
                    {
                        _entityRepository.Remove(item);
                        scope.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "删除出错！");
            }
            return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                return _entityRepository.GetModels(condition).ToArray();
            }
        }


        public IEnumerable<TEntity> FindAll()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                return _entityRepository.GetModels().ToArray();
            }
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }



        public IOperateResult Insert(TEntity entity)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    _entityRepository.Add(entity);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                }
            }
            catch (Exception)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "添加出错！");
            }
        }


        public IOperateResult Update(TEntity entity)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    _entityRepository.Update(entity);
                    scope.SaveChanges();
                    return OperateResultFactory.AjaxOperateResult(OperateResultType.Success, null);
                }
            }
            catch (Exception ex)
            {
                return OperateResultFactory.AjaxOperateResult(OperateResultType.Error, "更新出错！");
            }
        }
    }
}
