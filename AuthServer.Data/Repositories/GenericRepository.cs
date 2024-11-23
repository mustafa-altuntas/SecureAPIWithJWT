using AuthServer.Core.Repositories;
using AuthServer.Data.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(SecureApiDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            var query =  _dbSet.AsQueryable();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var value = await _dbSet.FindAsync(id);
            if (value != null)
            {
                _context.Entry(value).State = EntityState.Detached;
            }

            return value;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _dbSet.Where(predicate);
            return query;
        }
    }
}
