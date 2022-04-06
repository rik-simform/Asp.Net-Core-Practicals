using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Contract
{
   public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entity);
        Task<bool> Exist(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
