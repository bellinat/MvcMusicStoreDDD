using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Key
            HasKey(x => x.Id);
            
            // Fields
            Property(x => x.Id).IsRequired().HasMaxLength(128);
            Property(x => x.Name).IsRequired().HasMaxLength(256);

            // Table
            ToTable("AspNetRoles");

            // Relationship
        }
    }
}
