using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class UserClaimMap : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimMap()
        {
            // Key
            HasKey(x => x.Id);
            
            // Fields
            Property(x => x.UserId).IsRequired().HasMaxLength(128);

            // Table
            ToTable("AspNetUserClaims");

            // Relationship
            HasRequired(x => x.User).WithMany(x => x.UserClaims).HasForeignKey(x => x.UserId);
        }
    }
}
