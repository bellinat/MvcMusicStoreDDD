using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcMusicStore.Application;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.CrossCutting.Identity.Configuration;
using MvcMusicStore.CrossCutting.Identity.Context;
using MvcMusicStore.CrossCutting.Identity.Model;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Context.Interfaces;
using MvcMusicStore.Data.Repository.Dapper;
using MvcMusicStore.Data.Repository.EntityFramework;
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

namespace MvcMusicStore.CrossCutting.IoCSimpleInjector
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
            container.RegisterPerWebRequest<IClientService, ClientService>();
            container.RegisterPerWebRequest<IUserService, UserService>();

            #endregion

            #region Infrastructure Module

            container.Register(typeof(IContextManager<MusicStoreContext>), (typeof(ContextManager<MusicStoreContext>)));
            container.Register(typeof(IUnitOfWork<MusicStoreContext>), (typeof(UnitOfWork<MusicStoreContext>)));

            container.Register(typeof(IContextManager<StoreContext>), (typeof(ContextManager<StoreContext>)));
            container.Register(typeof(IUnitOfWork<StoreContext>), (typeof(UnitOfWork<StoreContext>)));

            container.Register(typeof(IContextManager<IdentityContext>), (typeof(ContextManager<IdentityContext>)));
            container.Register(typeof(IUnitOfWork<IdentityContext>), (typeof(UnitOfWork<IdentityContext>)));

            container.RegisterPerWebRequest<ApplicationDbContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            #endregion

            #region Repository Module

            container.RegisterPerWebRequest<IGenreRepository, GenreRepository>();
            container.RegisterPerWebRequest<IRepository<Genre>, GenreRepository>();
            container.RegisterPerWebRequest<IGenreReadOnlyRepository, GenreDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Genre>, GenreDapperRepository>();

            container.RegisterPerWebRequest<IArtistRepository, ArtistRepository>();
            container.RegisterPerWebRequest<IRepository<Artist>, ArtistRepository>();
            container.RegisterPerWebRequest<IArtistReadOnlyRepository, ArtistDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Artist>, ArtistDapperRepository>();

            container.RegisterPerWebRequest<IAlbumRepository, AlbumRepository>();
            container.RegisterPerWebRequest<IRepository<Album>, AlbumRepository>();
            container.RegisterPerWebRequest<IAlbumReadOnlyRepository, AlbumDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Album>, AlbumDapperRepository>();

            container.RegisterPerWebRequest<ICartRepository, CartRepository>();
            container.RegisterPerWebRequest<IRepository<Cart>, CartRepository>();
            container.RegisterPerWebRequest<ICartReadOnlyRepository, CartDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Cart>, CartDapperRepository>();

            container.RegisterPerWebRequest<IOrderRepository, OrderRepository>();
            container.RegisterPerWebRequest<IRepository<Order>, OrderRepository>();
            container.RegisterPerWebRequest<IOrderReadOnlyRepository, OrderDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Order>, OrderDapperRepository>();

            container.RegisterPerWebRequest<IOrderDetailRepository, OrderDetailRepository>();
            container.RegisterPerWebRequest<IRepository<OrderDetail>, OrderDetailRepository>();
            container.RegisterPerWebRequest<IOrderDetailReadOnlyRepository, OrderDetailDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<OrderDetail>, OrderDetailDapperRepository>();

            container.RegisterPerWebRequest<IClientRepository, ClientRepository>();
            container.RegisterPerWebRequest<IRepository<Client>, ClientRepository>();
            container.RegisterPerWebRequest<IClientReadOnlyRepository, ClientDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<Client>, ClientDapperRepository>();

            container.RegisterPerWebRequest<IUserRepository, UserRepository>();
            container.RegisterPerWebRequest<IRepository<User>, UserRepository>();
            container.RegisterPerWebRequest<IUserReadOnlyRepository, UserDapperRepository>();
            container.RegisterPerWebRequest<IReadOnlyRepository<User>, UserDapperRepository>();

            #endregion

            #region Application Module

            container.RegisterPerWebRequest<IGenreAppService, GenreAppService>();
            container.RegisterPerWebRequest<IArtistAppService, ArtistAppService>();
            container.RegisterPerWebRequest<IAlbumAppService, AlbumAppService>();
            container.RegisterPerWebRequest<ICartAppService, CartAppService>();
            container.RegisterPerWebRequest<IOrderAppService, OrderAppService>();
            container.RegisterPerWebRequest<IOrderDetailAppService, OrderDetailAppService>();
            container.RegisterPerWebRequest<IClientAppService, ClientAppService>();
            container.RegisterPerWebRequest<IUserAppService, UserAppService>();

            #endregion
        }
    }
}
