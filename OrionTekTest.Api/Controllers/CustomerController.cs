using Microsoft.AspNetCore.Mvc;
using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IService<Customer> _customerService;
        public CustomerController(IService<Customer> customerService)
        {
            _customerService = customerService;            
        }
    }
}
