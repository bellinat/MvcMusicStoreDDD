using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Context.Interfaces;
using MvcMusicStore.Data.Repository.EntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;

namespace MvcMusicStore.Data.Repository.EntityFramework
{
    public class ClientRepository : Repository<Client, StoreContext>, IClientRepository
    {
    }
}
