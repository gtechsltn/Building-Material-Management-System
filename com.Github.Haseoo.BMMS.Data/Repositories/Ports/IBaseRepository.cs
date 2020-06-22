﻿using System;
using System.Collections;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data.Entities;

namespace com.Github.Haseoo.BMMS.Data.Repositories.Ports
{
    public interface IBaseRepository <T> where T:Entity
    {
        IList<T> GetAll();
        T GetById( Guid id);
        void Add(in T entity);
        void Remove(in Guid id);
    }
}