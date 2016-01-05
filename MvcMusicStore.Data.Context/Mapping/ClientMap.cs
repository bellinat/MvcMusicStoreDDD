using System.Data.Entity.ModelConfiguration;
using MvcMusicStore.Domain.Entities;

namespace MvcMusicStore.Data.Context.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            HasKey(t => t.ClientId);

            // Properties
            Property(t => t.Name)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}