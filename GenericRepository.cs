using lab4.DTO.Extensions;
using lab4.DTO.Interfaces;
using lab4.DTO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lab4.DTO
{
    public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity> where TEntity : class
    {
        #region Fields

        private readonly DbSet<TEntity> _dbSet;
        private readonly EmployeeContext _context;

        #endregion Fields

        #region Constructors

        public GenericRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context is required");
            _dbSet = context.Set<TEntity>();
        }

        #endregion Constructors

        #region Methods

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, string properties = "")
        {
            IQueryable<TEntity> query = filter == null ? _dbSet : _dbSet.Where(filter);

            properties.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(prop => query = query.Include(prop.Trim()));

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);

        public async Task InsertAsync(params TEntity[] entities) => await _dbSet.AddRangeAsync(entities);

        public async Task<EntityEntry<TEntity>> InsertAsync(TEntity entity)
        {
            return await _dbSet.AddAsync(entity);
        }

        public void Delete(params TKey[] ids)
        {
            Delete(ids.Select(id => _dbSet.Find(id)).ToArray());
        }

        public void Delete(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                _dbSet.AddOrUpdate(entity);
            }
        }

        public bool Exists(Expression<Func<TEntity, bool>> condition, string properties = "")
        {
            IQueryable<TEntity> query = condition == null ? _dbSet : _dbSet.Where(condition);

            properties.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(prop => query = query.Include(prop.Trim()));

            return query.Any();
        }

        #endregion Methods
    }
}