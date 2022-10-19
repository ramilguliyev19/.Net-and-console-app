using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.EFRepository.EFEntityRepository
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EFEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

            TEntity data = expression is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(expression).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

            List<TEntity> data = expression is null
                ? await query.ToListAsync()
                : await query.Where(expression).ToListAsync();
            return data;
        }

        public async Task AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> data = _context.Entry(entity);
            data.State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            EntityEntry<TEntity> data = _context.Entry(entity);
            data.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            EntityEntry<TEntity> data = _context.Entry(entity);
            data.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
