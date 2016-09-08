using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.General
{
    public interface IRDefault<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(Func<TEntity, bool> predicate);
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        IQueryable<TEntity> GetInclude(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null);
        TEntity Get(params object[] Keys);
        void Update(TEntity entity);
    }
}
