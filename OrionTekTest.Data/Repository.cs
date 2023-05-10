using Microsoft.EntityFrameworkCore;
using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Entities;


namespace OrionTekTest.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityModel, new()
    {
        private readonly CustomersDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(CustomersDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(i => i.Status == true).ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Status = true;
            entity.CreatedAt = DateTime.UtcNow;
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.Status = false;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
