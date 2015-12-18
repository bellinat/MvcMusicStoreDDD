using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Context.Interfaces;
using MvcMusicStore.Domain.Interfaces.Repository.Common;

namespace MvcMusicStore.Data.Repository.ReadOnlyEntityFramework.Common
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        public ReadOnlyRepository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<MusicStoreReadOnlyContext>>() 
                as ContextManager<MusicStoreReadOnlyContext>;

            _dbContext = contextManager.GetContext();
            _dbSet = _dbContext.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}
