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
    public class ClientDapperRepository : Common.Repository , IClientReadOnlyRepository
    {
        public Client Get(int id)
        {
            using (var cn = MusicStoreConnection)
            {
                var clients = cn.Query<Client>("SELECT * FROM Client WHERE ClientId = @ClientId",
                    new { ClientId = id }).FirstOrDefault();
                return clients;
            }
        }

        public IEnumerable<Client> All()
        {
            using (var cn = MusicStoreConnection)
            {
                var client = cn.Query<Client>("SELECT * FROM Client");
                return client;
            }
        }

        public IEnumerable<Client> Find(Expression<Func<Client, bool>> predicate)
        {
            using (var cn = MusicStoreConnection)
            {
                var clients = cn.GetList<Client>(predicate);
                return clients;
            }
        }
    }
}
