

namespace OrionTekTest.Domain.Dtos
{
    public class BaseOperationResult
    {
        public string Title { get; set; }
        public string TraceId { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
