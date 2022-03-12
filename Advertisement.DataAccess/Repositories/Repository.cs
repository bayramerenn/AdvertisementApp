using AdvertisementApp.Common.Enums;
using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AdvertisementContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(AdvertisementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<TEntity> FindAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return OrderByType.DESC == orderByType ?
                     await _dbSet.AsNoTracking().OrderByDescending(selector).ToListAsync() :
                     await _dbSet.AsNoTracking().OrderBy(selector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return OrderByType.DESC == orderByType ?
                     await _dbSet.Where(predicate).AsNoTracking().OrderByDescending(selector).ToListAsync() :
                     await _dbSet.Where(predicate).AsNoTracking().OrderBy(selector).ToListAsync();
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
        {
            return !asNoTracking ?
                        await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync() :
                        await _dbSet.Where(predicate).FirstOrDefaultAsync();

        }

        public IQueryable<TEntity> GetQuery()
        {
           return _dbSet.AsQueryable();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(()=> _dbSet.Remove(entity));
        }

        public async Task UpdateAsync(TEntity entity, TEntity unchanged)
        {
            await Task.Run(() => _context.Entry(unchanged).CurrentValues.SetValues(entity));
        }
    }
}
