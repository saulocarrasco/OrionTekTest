

namespace OrionTekTest.Domain.Dtos
{
    public class OperationResult<TEntity> : BaseOperationResult
    {
        public IEnumerable<TEntity> Result { get; set; }
    }
}
