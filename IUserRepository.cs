using Forage.Entities;

namespace Forage.Contracts
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User  user);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(Guid id);
        public Task<bool> DeleteUser(Guid id);
        public Task UpdateUser(User user);
        public Task<User> GetUserByEmail(string email);
    }
}
