using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Repositories
{
    public interface IEmbedVideoRepository
    {
        Task<EmbedVideo> GetEmbedIdAsync(Guid embedId);
        Task<IEnumerable<EmbedVideo>> GetAllEmbedAsync();
        Task<EmbedVideo> AddEmbedAsync(EmbedVideo embedVideo);
        Task UpdateEmbedAsync(EmbedVideo embedVideo);
        Task DeleteEmbedAsync(Guid id);
        Task<IEnumerable<EmbedVideo>> GetEmbedByVideoAsync(Guid videoId);

    }
}
