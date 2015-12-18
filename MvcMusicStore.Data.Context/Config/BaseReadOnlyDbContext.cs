using System.Data.Entity;
using MvcMusicStore.Data.Context.Interfaces;

namespace MvcMusicStore.Data.Context.Config
{
    public class BaseReadOnlyDbContext : DbContext, IDbContext
    {
        public BaseReadOnlyDbContext(string connectionStringName, int? currentUserId = null)
            : base(connectionStringName)
        {
            CurrentUserId = currentUserId;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int? CurrentUserId { get; private set; }
    }
}