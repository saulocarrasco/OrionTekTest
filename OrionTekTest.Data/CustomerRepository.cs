using Microsoft.EntityFrameworkCore;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Data
{
    public class CustomerRepository : Repository<Customer>
    {
        private readonly CustomersDbContext _dbContext;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(CustomersDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Customer>();
        }

        public async override Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbSet.Include(i => i.Addresses).Where(i => i.Status == true).ToListAsync();
        }
    }
}
