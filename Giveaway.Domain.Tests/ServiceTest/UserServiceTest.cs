using Giveaway.Domain.Entities;
using Giveaway.Domain.Exceptions;
using Giveaway.Domain.Ports;
using Giveaway.Domain.Services;
using Giveaway.Domain.Tests.DataBuilder;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Linq.Expressions;

namespace Giveaway.Domain.Tests.ServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        private IGenericRepository<User> UserRepository { get; set; } = default!;
        private UserService UserService { get; set; } = default!;
        private UserBuilder UserBuilder { get; set; } = default!;

        [TestInitialize]
        public void Initialize()
        {
            UserRepository = Substitute.For<IGenericRepository<User>>();

            UserService = new(
                UserRepository
            );

            UserBuilder = new();
        }

        [TestMethod]
        public async Task GetUserByIdAsync_Error_NotExists()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            UserRepository
                .GetByAlternateKeyAsync(user => user.Id == id)
                .ReturnsNullForAnyArgs();

            // Act
            ValidatorException ex = await Assert.ThrowsExceptionAsync<ValidatorException>(async () =>
            {
                await UserService.GetUserByIdAsync(id);
            });

            // Assert
            Assert.AreEqual(MessagesExceptions.UserNotExists, ex.Message);
            await UserRepository.ReceivedWithAnyArgs(1)
                .GetByAlternateKeyAsync(
                    Arg.Any<Expression<Func<User, bool>>>()
                );
        }

        [TestMethod]
        public async Task GetUserByIdAsync_Ok()
        {
            // Arrange
            User user = UserBuilder
                .WithId(new("2b9bdcf2-f8c9-428f-842f-6dcc9e402e70"))
                .WithName("Nombre para prueba unitaria")
                .WithIdentification("55555")
                .WithEmail("carlos@gmail.com")
                .Build();

            UserRepository
                .GetByAlternateKeyAsync(userRepo => userRepo.Id == user.Id)
                .ReturnsForAnyArgs(user);

            // Act
            User result = await UserService
                .GetUserByIdAsync(user.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);
            await UserRepository.ReceivedWithAnyArgs(1)
                .GetByAlternateKeyAsync(
                    Arg.Any<Expression<Func<User, bool>>>()
                );
        }
    }
}
