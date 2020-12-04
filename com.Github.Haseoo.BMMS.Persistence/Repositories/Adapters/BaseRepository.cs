﻿using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using NHibernate.Linq;
using System;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Adapters
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly SessionWrapper _sessionWrapper;

        protected BaseRepository(SessionWrapper sessionWrapper)
        {
            _sessionWrapper = sessionWrapper;
        }

        public IQueryable<T> GetAll()
        {
            return _sessionWrapper.Session.Query<T>();
        }

        public T GetById(Guid id)
        {
            return _sessionWrapper.Session.Get<T>(id);
        }

        public T Add(in T entity)
        {
            var id = _sessionWrapper.Session.Save(entity);
            return _sessionWrapper.Session.Get<T>(id);
        }

        public T Update(in T entity)
        {
            _sessionWrapper.Session.Update(entity);
            return entity;
        }

        public void Remove(in Entity entity)
        {
            _sessionWrapper.Session.Delete(entity);
        }
    }
}