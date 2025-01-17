﻿using Microsoft.EntityFrameworkCore;
using Product_Management_System.Application.Contract;
using Product_Management_System.Context;
using Product_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management_System.Infrastructure
{
    public class Repository<TEntity, Tid> : IRepository<TEntity, Tid> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _Context;
        private readonly DbSet<TEntity> _Dbset;
        public Repository(ApplicationDbContext Context)
        {
            _Context = Context;
            _Dbset = _Context.Set<TEntity>();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.IsDeleted = false;
            var result = (await _Dbset.AddAsync(entity)).Entity;
            return result;
        }
        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Task.FromResult(_Dbset.Remove(entity).Entity);
        }
        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_Dbset.Select(s => s));
        }
        public async Task<TEntity> GetByIdAsync(Tid id)
        {
            TEntity item = await _Dbset.FindAsync(id);


            return item;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _Context.SaveChangesAsync();
        }
        public Task<TEntity> UpdateAsync(TEntity entity)
        {

            return Task.FromResult(_Dbset.Update(entity).Entity);

        }
    }
}
