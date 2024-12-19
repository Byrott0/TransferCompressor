using TransferCompressor.Server.Models;
using TransferCompressor.Server.Data;

namespace TransferCompressor.Server.Repositories
{
    public class UserRepository : IUserRepository
    {

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
        }
        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
