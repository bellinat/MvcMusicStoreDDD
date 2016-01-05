using System.Data.Entity;
using MvcMusicStore.Data.Context.Config;
using MvcMusicStore.Data.Context.Mapping;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context
{
    public class IdentityContext : BaseDbContext
    {
        public IdentityContext()
            : base("EmailServiceEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
        }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        #endregion
    }
}
