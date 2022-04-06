﻿using Practical_17.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practical_17.Model;
using Microsoft.EntityFrameworkCore;

namespace Practical_17.Repositories
{
    public class GenericRepositories<T> : IGenericRepository<T> where T : class
    {
        private readonly AppContext context;

        public GenericRepositories(AppContext Context)
        {
            context = Context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await context.AddRangeAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
