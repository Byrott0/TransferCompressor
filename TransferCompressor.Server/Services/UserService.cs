using TransferCompressor.Server.Models;
using TransferCompressor.Server.Repositories;
using TransferCompressor.Server.Data;

namespace TransferCompressor.Server.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;
        public UserService(IUserRepository userRepository, IVideoRepository videoRepository)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
        }

        // haal alle gebruikers op

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // haal alle videos van een gebruiker op
        public async Task<IEnumerable<Video>> GetVideosByUserAsync(User userId)
        {
            return await _videoRepository.GetVideoByUserAsync(userId);
        }

        // voeg een gebruiker toe
        public async Task AddUserAsync(string email, string password, Guid userId)
        {
            var user = new User
            {
                Email = email,
                Password = password,
                userId = userId
            };
            await _userRepository.AddAsync(user);
        }

        // haal gegevens van een gebruiker op
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }


        // werk gegevens van een gebruiker bij
        public async Task UpdateUserAsync(Guid userId, string email, string password)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                user.Email = email;
                user.Password = password;
                await _userRepository.UpdateAsync(user);
            }
        }

        // verwijder een gebruiker
        public async Task DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                await _userRepository.DeleteAsync(userId);
            }
        }
    }
}
