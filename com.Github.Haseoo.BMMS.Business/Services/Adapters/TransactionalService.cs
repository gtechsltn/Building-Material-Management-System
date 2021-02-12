﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data;
using NHibernate;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class ServiceTransactionProxy <T, R> : ITransactionalService<T, R>
    {

        private readonly ITransactionalService<T, R> _service;

        public ServiceTransactionProxy(ITransactionalService<T, R> service)
        {
            _service = service;
        }

        public R Add(T operation)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                var returnValue = _service.Add(operation);
                transaction.Commit();
                return returnValue;
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }

        public void Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = SessionManager.Instance.GetSession().BeginTransaction();
                _service.Delete(id);
                transaction.Commit();
            }
            catch
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                throw;
            }
        }
    }
}
