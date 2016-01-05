using System;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcMusicStore.CrossCutting.Identity.Model;

namespace MvcMusicStore.CrossCutting.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("MusicStoreEntities", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
