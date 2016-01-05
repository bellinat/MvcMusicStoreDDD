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
    public class UserAppService : AppService<IdentityContext>, IUserAppService
    {
        private readonly IUserService _service;

        public UserAppService(IUserService userService)
        {
            _service = userService;
        }

        public ValidationResult Create(User user)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(user));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(User user)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(user));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(IEnumerable<User> users)
        {
            BeginTransaction();
            users.ForEach(user => ValidationResult.Add(_service.Update(user)));
            if(ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(User user)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(user));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(IEnumerable<User> users)
        {
            BeginTransaction();
            users.ForEach(user => ValidationResult.Add(_service.Delete(user)));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public User Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<User> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}