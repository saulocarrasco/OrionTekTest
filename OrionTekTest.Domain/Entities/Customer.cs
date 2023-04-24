namespace OrionTekTest.Domain.Entities
{
    public class Customer : EntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
