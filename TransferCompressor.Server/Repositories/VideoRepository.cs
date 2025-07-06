using Microsoft.EntityFrameworkCore;
using TransferCompressor.Server.Data;
using TransferCompressor.Server.Models;
namespace TransferCompressor.Server.Repositories
{
    public class VideoRepository : IVideoRepository
    {

        private readonly CompressorContext _context;

        public VideoRepository(CompressorContext context)
        {
            _context = context;

        }

        public async Task<Video> GetByIdAsync(Guid id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task AddAsync(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Video>> GetVideoByUserAsync(User user)
        {
            return await _context.Videos
           .Where(v => v.user.userId == user.userId)
           .ToListAsync();
        }

    }
}
