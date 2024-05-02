using Giveaway.Domain.Entities;
using Giveaway.Domain.Exceptions;
using Giveaway.Domain.Ports;

namespace Giveaway.Domain.Services
{
    [DomainService]
    public class UserService
    {
        private readonly IGenericRepository<User> repository;

        public UserService(
            IGenericRepository<User> repository
        )
        {
            this.repository = repository;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            User user = await repository.GetByAlternateKeyAsync(
                user => user.Id == id
            ) ?? throw new ValidatorException(MessagesExceptions.UserNotExists);

            return user;
        }
    }
}
