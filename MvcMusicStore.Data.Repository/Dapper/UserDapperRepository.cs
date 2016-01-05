using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using DapperExtensions;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository.ReadOnly;

namespace MvcMusicStore.Data.Repository.Dapper
{
    public class UserDapperRepository : Common.Repository, IUserReadOnlyRepository
    {
        public User Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var user = cn.Query<User>("SELECT * FROM AspNetUsers WHERE ArtistId = @Id",
                    new { Id = id }).FirstOrDefault();
                return user;
            }
        }

        public IEnumerable<User> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var user = cn.Query<User>("SELECT * FROM AspNetUsers");
                return user;
            }
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var user = cn.GetList<User>(predicate);
                return user;
            }
        }
    }
}
