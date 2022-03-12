using AdvertisementApp.Common.Enums;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector,OrderByType orderByType = OrderByType.DESC);
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> selector,OrderByType orderByType = OrderByType.DESC);
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate,bool asNoTracking = false);
        IQueryable<T> GetQuery();
        Task RemoveAsync(T entity);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity, T unchanged);

    }
}
