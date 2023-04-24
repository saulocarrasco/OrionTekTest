using OrionTekTest.Domain.Dtos;

namespace OrionTekTest.Domain.Contracts
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<OperationResult<TEntity>> GetAllAsync();
        Task<SingleOperationResult<TEntity>> GetByIdAsync(int id);
        Task<SingleOperationResult<TEntity>> AddAsync(TEntity entity);
        Task<SingleOperationResult<TEntity>> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
