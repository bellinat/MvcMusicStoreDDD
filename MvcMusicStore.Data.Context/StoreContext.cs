using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcMusicStore.Data.Context.Config;
using MvcMusicStore.Data.Context.Mapping;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context
{
    public class StoreContext : BaseDbContext
    {
        public StoreContext()
            : base("MusicStoreEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClientMap());
        }
  
        #region DbSet

        public DbSet<Client> Clients { get; set; }

        #endregion
    }
}