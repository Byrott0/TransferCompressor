﻿using TransferCompressor.Server.Models;
using TransferCompressor.Server.Repositories;
using TransferCompressor.Server.Data;

namespace TransferCompressor.Server.Services
{
    public class VideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IEmbedVideoRepository _embedVideoRepository;
        public VideoService(IVideoRepository videoRepository, IEmbedVideoRepository embedVideoRepository)
        {
            _videoRepository = videoRepository;
            _embedVideoRepository = embedVideoRepository;
        }

        // haal alle videos op
        public async Task<IEnumerable<Video>> GetAllVideosAsync()
        {
            return await _videoRepository.GetAllAsync();
        }

        // voeg een video toe en maak het embed
        public async Task AddVideoAsync(string filenaam, string originalFilePath, long fileSize)
        {
            string compressedFilePath = originalFilePath.Replace("original", "compressed");
            long compressedFileSize = fileSize / 3;

            var video = new Video
            {
                CompressedFilePad = compressedFilePath,
                OriginalFilePad = originalFilePath,
                OriginalFileSize = fileSize.ToString(),
                CompressedFileSize = compressedFileSize.ToString(),
                uploadDatum = DateTime.UtcNow,
                DeelbaarLink = GenereerDeelbareLink()

            };

            await _videoRepository.AddAsync(video);

            var embed = new EmbedVideo
            {
                VideoId = video.Id,
                EmbedCode = $"<iframe src='{video.DeelbaarLink}' frameborder='0' allowfullscreen></iframe>"
            };
            await _embedVideoRepository.AddEmbedAsync(embed);
        }

        // haal gegevens van een video op

        public async Task<Video> GetVideoByIdAsync(Guid id)
        {
            return await _videoRepository.GetByIdAsync(id);
        }

        // haal embed code op van een video

        public async Task<EmbedVideo> GetEmbedByIdAsync(Guid id)
        {
            return await _embedVideoRepository.GetEmbedIdAsync(id);
        }

        // verwijder een video en de bijbehorende embed code

        public async Task DeleteVideoAsync(Guid id)
        {
            var embed = await _embedVideoRepository.GetEmbedIdAsync(id);
            if(embed != null)
            {
                await _embedVideoRepository.DeleteEmbedAsync(embed.embedId);
            }
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