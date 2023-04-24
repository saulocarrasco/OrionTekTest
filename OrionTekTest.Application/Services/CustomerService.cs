using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Dtos;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Application.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<SingleOperationResult<Customer>> AddAsync(Customer entity)
        {
            var resultDb = await _customerRepository.AddAsync(entity);

            var operationResult = new SingleOperationResult<Customer>
            {
                Result = resultDb
            };

            return operationResult;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dbResult = await _customerRepository.DeleteAsync(id);

            return dbResult;
        }

        public async Task<OperationResult<Customer>> GetAllAsync()
        {
            var resultDb = await _customerRepository.GetAllAsync();

            var operationResult = new OperationResult<Customer>
            {
                Result = resultDb
            };

            return operationResult;
        }

        public async Task<SingleOperationResult<Customer>> GetByIdAsync(int id)
        {
            var resultDb = await _customerRepository.GetByIdAsync(id);

            var operationResult = new SingleOperationResult<Customer>
            {
                Result = resultDb
            };

            return operationResult;
        }

        public async Task<SingleOperationResult<Customer>> UpdateAsync(Customer entity)
        {
            var resultDb = await _customerRepository.UpdateAsync(entity);

            var operationResult = new SingleOperationResult<Customer>
            {
                Result = resultDb
            };

            return operationResult;
        }
    }
}
