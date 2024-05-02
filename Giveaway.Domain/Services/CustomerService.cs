using Giveaway.Domain.Entities;
using Giveaway.Domain.Exceptions;
using Giveaway.Domain.Ports;

namespace Giveaway.Domain.Services
{
    [DomainService]
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> repository;

        public CustomerService(
            IGenericRepository<Customer> repository
        )
        {
            this.repository = repository;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            Customer customer = await repository.GetByAlternateKeyAsync(
                customer => customer.Id == id
            ) ?? throw new ValidatorException(MessagesExceptions.CustomerNotExists);

            return customer;
        }
    }
}
