﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EFRepository
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
