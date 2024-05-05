using Giveaway.Domain.Entities;

namespace Giveaway.Domain.Tests.DataBuilder
{
    public class UserBuilder
    {
        private Guid Id;
        private string Name;
        private string Identification;
        private string Email;

        public UserBuilder()
        {
            Id = Guid.NewGuid();
            Name = "Test";
            Identification = "123456";
            Email = "test@test.com";
        }

        public User Build()
        {
            return new()
            {
                Id = Id,
                Name = Name,
                Identification = Identification,
                Email = Email
            };
        }

        public UserBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithIdentification(string identification)
        {
            Identification = identification;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }
    }
}
