using TransferCompressor.Server.Models;
using TransferCompressor.Server.Repositories;
using TransferCompressor.Server.Data;

namespace TransferCompressor.Server.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IEmailService _emailService;
        public UserService(IUserRepository userRepository, IVideoRepository videoRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _videoRepository = videoRepository;
            _emailService = emailService;
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
        public async Task AddUserAsync(string email, string password)
        {
            var user = new User
            {
                Email = email,
                Password = password
                // userId wordt automatisch gegenereerd door de database
            };
            await _userRepository.AddAsync(user);
            // sla op
            await _userRepository.SaveChanges();

            // stuur een welkomstmail
            await _emailService.SendEmailAsync
           (email, "Nieuw account aangemaakt:", "Welkom bij TransferCompressor! Uw account is aangemaakt.");
        }

        // haal gegevens van een gebruiker op
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        // haal gegevens van een gebruiker op via email
        public async Task<User> GetUserByEmailAsync(string email, Guid userId)
        {
            return await _userRepository.GetUserByEmailAsync(email);
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
            // sla op
            _userRepository.SaveChanges();
            // stuur een mail dat gegevens zijn bijgewerkt
            await _emailService.SendEmailAsync
                (email, "Gegevens bijgewerkt:", "Uw gegevens zijn bijgewerkt.");
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
