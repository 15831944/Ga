using Gmail.DDD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PM2.Service.Code030.CM
{
    public interface ICmDataService<TEntity>
    {
        IOperateResult Insert(TEntity entity);

        //int Insert(IEnumerable<TEntity> entities);

        IOperateResult Update(TEntity entity);


        IOperateResult Delete(Expression<Func<TEntity, bool>> exp);

        //int Delete(IEnumerable<object> keys);

        IOperateResult Delete(TEntity entity);

        //int Delete(IEnumerable<TEntity> entities);


        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> condition);

        IEnumerable<TEntity> FindAll();

        //void Commit();

    }
}
