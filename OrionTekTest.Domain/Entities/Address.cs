

namespace OrionTekTest.Domain.Entities
{
    public class Address : EntityModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; } 
        public string Country { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
    }
}
