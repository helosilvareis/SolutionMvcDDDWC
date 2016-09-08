using Context;
using Model.General;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.General
{
    public class BDefault<TEntity> where TEntity : BaseModel
    {
        protected RDefault<TEntity> repository;

        public BDefault(RDefault<TEntity> repository)
        {
            this.repository = repository;
        }

        public SolutionContext context { get { return repository.context; } }

        public void Add(TEntity entity)
        {
            repository.Add(entity);
        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            repository.Get(predicate);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return repository.Get(predicate);
        }

        public IQueryable<TEntity> GetInclude(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            return repository.GetInclude(where, include);
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public virtual TEntity Get(params object[] Keys)
        {
            return repository.Get(Keys);
        }       

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
