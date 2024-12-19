using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Repositories
{
    public interface IVideoRepository
    {
        Task<Video> GetByIdAsync(Guid id);
        Task<IEnumerable<Video>> GetAllAsync();
        Task AddAsync(Video video);
        Task UpdateAsync(Video video);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Video>> GetVideoByUserAsync(Guid userId);
       
    }
}
