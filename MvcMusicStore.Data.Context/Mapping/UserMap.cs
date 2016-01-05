using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Key
            HasKey(x => x.Id);

            // Fields
            Property(x => x.Id).IsRequired().HasMaxLength(128);
            Property(x => x.Email).IsRequired().HasMaxLength(256);
            Property(x => x.UserName).IsRequired().HasMaxLength(128);

            // Table
            ToTable("AspNetUsers");

            // Relationship
        }
    }
}
