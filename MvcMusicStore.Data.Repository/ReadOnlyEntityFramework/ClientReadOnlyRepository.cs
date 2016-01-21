using MvcMusicStore.Data.Repository.ReadOnlyEntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;

namespace MvcMusicStore.Data.Repository.ReadOnlyEntityFramework
{
    public class ClientReadOnlyRepository : ReadOnlyRepository<Client>, IClientReadOnlyRepository
    {
    }
}
