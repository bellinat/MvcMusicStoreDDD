﻿using MvcMusicStore.Data.Repository.Dapper;
using MvcMusicStore.Data.Repository.EntityFramework;
using MvcMusicStore.Data.Repository.EntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;
using MvcMusicStore.Domain.Interfaces.Repository.Common;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;
using Ninject.Modules;

namespace MvcMusicStore.CrossCutting.InversionOfControl.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Bind(typeof (IRepository<>)).To(typeof (Repository<,>));

            Bind<IGenreRepository>().To<GenreRepository>();
            Bind<IRepository<Genre>>().To<GenreRepository>();
            Bind<IGenreReadOnlyRepository>().To<GenreDapperRepository>();
            Bind<IReadOnlyRepository<Genre>>().To<GenreDapperRepository>();

            Bind<IArtistRepository>().To<ArtistRepository>();
            Bind<IRepository<Artist>>().To<ArtistRepository>();
            Bind<IArtistReadOnlyRepository>().To<ArtistDapperRepository>();
            Bind<IReadOnlyRepository<Artist>>().To<ArtistDapperRepository>();

            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<IRepository<Album>>().To<AlbumRepository>();
            Bind<IAlbumReadOnlyRepository>().To<AlbumDapperRepository>();
            Bind<IReadOnlyRepository<Album>>().To<AlbumDapperRepository>();

            Bind<ICartRepository>().To<CartRepository>();
            Bind<IRepository<Cart>>().To<CartRepository>();
            Bind<ICartReadOnlyRepository>().To<CartDapperRepository>();
            Bind<IReadOnlyRepository<Cart>>().To<CartDapperRepository>();

            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IRepository<Order>>().To<OrderRepository>();
            Bind<IOrderReadOnlyRepository>().To<OrderDapperRepository>();
            Bind<IReadOnlyRepository<Order>>().To<OrderDapperRepository>();

            Bind<IOrderDetailRepository>().To<OrderDetailRepository>();
            Bind<IRepository<OrderDetail>>().To<OrderDetailRepository>();
            Bind<IOrderDetailReadOnlyRepository>().To<OrderDetailDapperRepository>();
            Bind<IReadOnlyRepository<OrderDetail>>().To<OrderDetailDapperRepository>();

            Bind<IClientRepository>().To<ClientRepository>();
            Bind<IRepository<Client>>().To<ClientRepository>();
            Bind<IClientReadOnlyRepository>().To<ClientDapperRepository>();
            Bind<IReadOnlyRepository<Client>>().To<ClientDapperRepository>();

            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRepository<User>>().To<UserRepository>();
            Bind<IUserReadOnlyRepository>().To<UserDapperRepository>();
            Bind<IReadOnlyRepository<User>>().To<UserDapperRepository>();
        }
    }
}
