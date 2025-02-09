using TransferCompressor.Server.Models;
using TransferCompressor.Server.Repositories;
using TransferCompressor.Server.Data;

namespace TransferCompressor.Server.Services
{
    public class VideoService
    {
        private readonly IVideoRepository _videoRepository;
        //private readonly IEmbedVideoRepository _embedVideoRepository;
        private readonly IUserRepository _userRepository;
        public VideoService(IVideoRepository videoRepository, /*IEmbedVideoRepository embedVideoRepository,*/ IUserRepository userRepository)
        {
            _videoRepository = videoRepository;
            //_embedVideoRepository = embedVideoRepository;
            _userRepository = userRepository;
        }

      
        // haal alle videos op
        public async Task<IEnumerable<Video>> GetAllVideosAsync()
        {
            return await _videoRepository.GetAllAsync();
        }

        // voeg een video toe en maak het embed
        public async Task AddVideoAsync(string filenaam, string originalFilePath, long fileSize, Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            string compressedFilePath = originalFilePath.Replace("original", "compressed");
            long compressedFileSize = fileSize / 3;

            var video = new Video
            {
                user = user,
                userId = user.userId,
                CompressedFilePad = compressedFilePath,
                OriginalFilePad = originalFilePath,
                OriginalFileSize = fileSize, // geen conversie meer nodig
                CompressedFileSize = compressedFileSize,
                uploadDatum = DateTime.UtcNow,
                DeelbaarLink = GenereerDeelbareLink()
            };

            await _videoRepository.AddAsync(video);

            //var embed = new EmbedVideo
            //{
            //    VideoId = video.Id
            //};
            //await _embedVideoRepository.AddEmbedAsync(embed);
        }

        // haal gegevens van een video op

        public async Task<Video> GetVideoByIdAsync(Guid id)
        {
            return await _videoRepository.GetByIdAsync(id);
        }

        // haal embed code op van een video

        //public async Task<EmbedVideo> GetEmbedByIdAsync(Guid id)
        //{
        //    return await _embedVideoRepository.GetEmbedIdAsync(id);
        //}

        // verwijder een video en de bijbehorende embed code

        public async Task DeleteVideoAsync(Guid id)
        {
            //var embed = await _embedVideoRepository.GetEmbedIdAsync(id);
            //if(embed != null)
            //{
            //    await _embedVideoRepository.DeleteEmbedAsync(embed.embedId);
            //}
            //video wordt nu verwijderd
            await _videoRepository.DeleteAsync(id);

        }

        // Genereer een unieke deelbare link.
        private string GenereerDeelbareLink()
        {
            return $"https://example.com/video/{Guid.NewGuid()}";
        }
    }
}