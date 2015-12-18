using System;
using MvcMusicStore.Data.Repository.ReadOnlyEntityFramework.Common;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;

namespace MvcMusicStore.Data.Repository.ReadOnlyEntityFramework
{
    public class GenreReadOnlyRepository : ReadOnlyRepository<Genre>, IGenreReadOnlyRepository
    {
        public Genre GetWithAlbums(string genreName)
        {
            return null;
        }
    }
}
