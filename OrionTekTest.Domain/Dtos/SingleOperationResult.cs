

namespace OrionTekTest.Domain.Dtos
{
    public class SingleOperationResult<TEntity> : BaseOperationResult
    {
        public TEntity Result { get; set; }
    }
}
