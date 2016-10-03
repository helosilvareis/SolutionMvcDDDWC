﻿using Context;
using Repository.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.General
{
    public class RDefault<TEntity> where TEntity : class, IRDefault<TEntity>
    {
        protected SolutionContext _db;

        public RDefault(SolutionContext db)
        {
            _db = db;
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
