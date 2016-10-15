using Context;
using Repository.General.Interfaces;
using System;

namespace Repository.General
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private SolutionContext _dbContext;

        //public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(SolutionContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IRepositoryBase<TEntity> Repository<TEntity>() where TEntity : class
        //{
        //    if (repositories.Keys.Contains(typeof(TEntity)) == true)
        //    {
        //        return repositories[typeof(TEntity)] as IRepositoryBase<TEntity>;
        //    }
        //    IRepositoryBase<TEntity> repo = new RepositoryBase<TEntity>(_dbContext);
        //    repositories.Add(typeof(TEntity), repo);
        //    return repo;
        //}

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Save()
        {
            // Save changes with the default options
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
