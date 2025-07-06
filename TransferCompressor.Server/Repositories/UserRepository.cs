using TransferCompressor.Server.Models;
using TransferCompressor.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace TransferCompressor.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CompressorContext _context;

        public UserRepository(CompressorContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
           return await _context.Users.FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
        }
        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users != null)
            {
                _context.Users.Remove(users);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
           return await _context.Users
                .FirstOrDefaultAsync(u => u.email == email);
        }
    }
}
