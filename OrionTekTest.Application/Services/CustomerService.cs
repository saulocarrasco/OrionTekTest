using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Dtos;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Application.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Address> _addressRepository;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Address> addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }
        public async Task<SingleOperationResult<Customer>> AddAsync(Customer entity)
        {
            var resultDb = await _customerRepository.AddAsync(entity);

            var newAddresses = entity.Addresses.Where(i => i.Id == 0);
            
            foreach (var address in newAddresses)
            {
                await _addressRepository.AddAsync(address);
            }

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


            var newAddresses = entity.Addresses.Where(i => i.Id == 0);
            var updatedAddresses = entity.Addresses.Where(i => i.Status == false);

            foreach (var address in newAddresses)
            {
                await _addressRepository.AddAsync(address);
            }

            foreach (var address in updatedAddresses)
            {
                await _addressRepository.UpdateAsync(address);
            }

            var operationResult = new SingleOperationResult<Customer>
            {
                Result = resultDb
            };

            return operationResult;
        }
    }
}
