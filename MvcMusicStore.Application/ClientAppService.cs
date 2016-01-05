using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.Data.Context;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Service;
using MvcMusicStore.Domain.Services.Helpers;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Application
{
    public class ClientAppService : AppService<StoreContext>, IClientAppService
    {
        private readonly IClientService _service;

        public ClientAppService(IClientService clientService)
        {
            _service = clientService;
        }

        public ValidationResult Create(Client client)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(client));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Client client)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(client));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(IEnumerable<Client> clients)
        {
            BeginTransaction();
            clients.ForEach(client => ValidationResult.Add(_service.Update(client)));
            if(ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Client client)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(client));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(IEnumerable<Client> clients)
        {
            BeginTransaction();
            clients.ForEach(client => ValidationResult.Add(_service.Delete(client)));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Client Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Client> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Client> Find(Expression<Func<Client, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}