using Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.General
{
    public class RDefault<TEntity> : IRDefault<TEntity> where TEntity : class
    {
        protected SolutionContext _db;
        protected readonly IDbSet<TEntity> _dbSet;

        public RDefault(SolutionContext context)
        {
            this._db = context;
            this._dbSet = context.Set<TEntity>();
        }

        public SolutionContext context;

        public void Add(TEntity entity)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Added;
                    _db.SaveChanges();
                    tc.Commit();
                }
                catch
                {
                    tc.Rollback();
                }
            }


        }

        public void Delete(Func<TEntity, bool> predicate)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Set<TEntity>().Where(predicate).ToList().ForEach(del => _db.Set<TEntity>().Remove(del));
                    _db.SaveChanges();
                    tc.Commit();
                }
                catch
                {
                    tc.Rollback();
                }
            }
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetInclude(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> include = null)
        {
            return _db.Set<TEntity>().Where(where).Include(include).AsQueryable();
        }

        public void Update(TEntity entity)
        {
            using (var tc = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Entry(entity).State = EntityState.Modified;
                    _db.SaveChanges();
                    tc.Commit();
                }
                catch
                {
                    tc.Rollback();
                }
            }
        }

        public virtual TEntity Get(params object[] Keys)
        {

            TEntity entity = _db.Set<TEntity>().Find(Keys);
            return entity;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
