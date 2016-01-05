using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Repository.EntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;
using MvcMusicStore.Data.Context.Interfaces;

namespace MvcMusicStore.Data.Repository.EntityFramework
{
    public class CartRepository : Repository<Cart, MusicStoreContext>, ICartRepository
    {
    }
}
