using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
