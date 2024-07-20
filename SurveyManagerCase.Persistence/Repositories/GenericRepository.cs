using Microsoft.EntityFrameworkCore;
using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Domain.Entities;
using SurveyManagerCase.Persistence.Context;
using System.Linq.Expressions;

namespace SurveyManagement.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class, IEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();

        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> items)
        {
            await _dbSet.AddRangeAsync(items);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public void RemoveRange(IEnumerable<TEntity> items)
        {
            _dbSet.RemoveRange(items);
        }
    }
}
