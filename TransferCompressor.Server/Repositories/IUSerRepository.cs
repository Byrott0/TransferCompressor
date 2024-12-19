using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> DeleteAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
