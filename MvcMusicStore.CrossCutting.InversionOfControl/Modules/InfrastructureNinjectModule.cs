using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcMusicStore.CrossCutting.Identity.Configuration;
using MvcMusicStore.CrossCutting.Identity.Context;
using MvcMusicStore.CrossCutting.Identity.Model;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Data.Context.Interfaces;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MvcMusicStore.CrossCutting.InversionOfControl.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IContextManager<MusicStoreContext>)).To((typeof(ContextManager<MusicStoreContext>)));
            Bind(typeof(IUnitOfWork<MusicStoreContext>)).To((typeof(UnitOfWork<MusicStoreContext>)));

            Bind(typeof(IContextManager<StoreContext>)).To((typeof(ContextManager<StoreContext>)));
            Bind(typeof(IUnitOfWork<StoreContext>)).To((typeof(UnitOfWork<StoreContext>)));

            Bind(typeof(IContextManager<IdentityContext>)).To((typeof(ContextManager<IdentityContext>)));
            Bind(typeof(IUnitOfWork<IdentityContext>)).To((typeof(UnitOfWork<IdentityContext>)));

            //Bind<IDbContext>().To<MusicStoreContext>();
            //Bind(typeof (IContextManager<>)).To(typeof (ContextManager<>));
            //Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));

            Bind<ApplicationDbContext>();
            Bind(typeof(IUserStore<ApplicationUser>)).To((typeof(UserStore<ApplicationUser>)));
            Bind(typeof(IRoleStore<IdentityRole>)).To((typeof(RoleStore<IdentityRole>)));
            Bind<ApplicationRoleManager>().ToSelf().InRequestScope();
            Bind<ApplicationUserManager>();
            Bind<ApplicationSignInManager>();
        }
    }
}
