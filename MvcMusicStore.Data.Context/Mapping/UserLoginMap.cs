using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            // Key
            HasKey(x => new { x.UserId, x.LoginProvider, x.ProviderKey });

            // Fields
            Property(x => x.LoginProvider).IsRequired().HasMaxLength(128);
            Property(x => x.ProviderKey).IsRequired().HasMaxLength(128);
            Property(x => x.UserId).IsRequired().HasMaxLength(128);

            // Table
            ToTable("AspNetUserLogins");

            // Relationship
        }
    }
}
