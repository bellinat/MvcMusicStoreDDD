using MvcMusicStore.Application;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Context.Interfaces;
using MvcMusicStore.Data.Repository.Dapper;
using MvcMusicStore.Data.Repository.EntityFramework;
using MvcMusicStore.Data.Repository.EntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;
using MvcMusicStore.Domain.Interfaces.Repository.Common;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Interfaces.Service.Common;
using MvcMusicStore.Domain.Services;
using MvcMusicStore.Domain.Services.Common;

namespace MvcMusicStore.CrossCutting.IoC
{
    public class IoC
    {
        public static void RegisterServices(Container container)
        {
            #region Service Module

            container.Register(typeof(IService<>), typeof(Service<>), new WebRequestLifestyle());

            container.RegisterPerWebRequest<IGenreService, GenreService>();
            container.RegisterPerWebRequest<IArtistService, ArtistService>();
            container.RegisterPerWebRequest<IAlbumService, AlbumService>();
            container.RegisterPerWebRequest<ICartService, CartService>();
            container.RegisterPerWebRequest<IOrderService, OrderService>();
            container.RegisterPerWebRequest<IOrderDetailService, OrderDetailService>();

            #endregion

            #region Infrastructure Module
            container.RegisterPerWebRequest<IDbContext, MusicStoreContext>();
            container.Register(typeof(IContextManager<>), typeof(ContextManager<>), new WebRequestLifestyle());
            container.Register(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), new WebRequestLifestyle());

            #endregion

            #region Repository Module

            container.Register(typeof(IRepository<>), typeof(Repository<>), new WebRequestLifestyle());

            container.RegisterPerWebRequest<IGenreRepository, GenreRepository>();
            container.RegisterPerWebRequest<IGenreReadOnlyRepository, GenreDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Genre>, GenreDapperRepository>();

            container.RegisterPerWebRequest<IArtistRepository, ArtistRepository>();
            container.RegisterPerWebRequest<IArtistReadOnlyRepository, ArtistDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Artist>, ArtistDapperRepository>();

            container.RegisterPerWebRequest<IAlbumRepository, AlbumRepository>();
            container.RegisterPerWebRequest<IAlbumReadOnlyRepository, AlbumDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Album>, AlbumDapperRepository>();

            container.RegisterPerWebRequest<ICartRepository, CartRepository>();
            container.RegisterPerWebRequest<ICartReadOnlyRepository, CartDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Cart>, CartDapperRepository>();

            container.RegisterPerWebRequest<IOrderRepository, OrderRepository>();
            container.RegisterPerWebRequest<IOrderReadOnlyRepository, OrderDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Order>, OrderDapperRepository>();

            container.RegisterPerWebRequest<IOrderDetailRepository, OrderDetailRepository>();
            container.RegisterPerWebRequest<IOrderDetailReadOnlyRepository, OrderDetailDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<OrderDetail>, OrderDetailDapperRepository>();

            #endregion

            #region Application Module

            container.RegisterPerWebRequest<IGenreAppService, GenreAppService>();
            container.RegisterPerWebRequest<IArtistAppService, ArtistAppService>();
            container.RegisterPerWebRequest<IAlbumAppService, AlbumAppService>();
            container.RegisterPerWebRequest<ICartAppService, CartAppService>();
            container.RegisterPerWebRequest<IOrderAppService, OrderAppService>();
            container.RegisterPerWebRequest<IOrderDetailAppService, OrderDetailAppService>();

            #endregion
        }
    }
}
