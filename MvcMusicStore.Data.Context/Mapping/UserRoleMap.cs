using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            // Key
            HasKey(x => new {x.UserId, x.RoleId});

            // Fields
            Property(x => x.UserId).IsRequired().HasMaxLength(128);
            Property(x => x.RoleId).IsRequired().HasMaxLength(128);

            // Table
            ToTable("AspNetUserRoles");

           // Relationship
        }
    }
}
