//using TransferCompressor.Server.Data;
//using TransferCompressor.Server.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TransferCompressor.Server.Repositories
//{
//    public class EmbedVideoRepository : IEmbedVideoRepository
//    {
//        private readonly CompressorContext _context;

//        public EmbedVideoRepository(CompressorContext context)
//        {
//            _context = context;
//        }

//        public async Task<EmbedVideo> GetEmbedIdAsync(Guid embedId)
//        {
//            return await _context.EmbedVideos.FindAsync(embedId);
//        }

//        public async Task<IEnumerable<EmbedVideo>> GetAllEmbedAsync()
//        {
//            return await _context.EmbedVideos.ToListAsync();
//        }

//        public async Task<EmbedVideo> AddEmbedAsync(EmbedVideo embedVideo)
//        {
//            await _context.EmbedVideos.AddAsync(embedVideo);
//            await _context.SaveChangesAsync();
//            return embedVideo;
//        }

//        public async Task UpdateEmbedAsync(EmbedVideo embedVideo)
//        {
//            var existingEmbed = await _context.EmbedVideos.FindAsync(embedVideo.embedId);
//            if (existingEmbed != null)
//            {
//                existingEmbed.EmbedUrl = embedVideo.EmbedUrl;
//                existingEmbed.EmbedCode = embedVideo.EmbedCode;
//                existingEmbed.VideoId = embedVideo.VideoId;
//                _context.EmbedVideos.Update(existingEmbed);
//                await _context.SaveChangesAsync();
                
//            }
           
//        }

//        public async Task DeleteEmbedAsync(Guid id)
//        {
//            var embedVideo = await _context.EmbedVideos.FindAsync(id);
//            if (embedVideo != null)
//            {
//                _context.EmbedVideos.Remove(embedVideo);
//                await _context.SaveChangesAsync();
                
//            }
           
//        }

//        public async Task<IEnumerable<EmbedVideo>> GetEmbedByVideoAsync(Guid videoId)
//        {
//            return await _context.EmbedVideos
//                .Where(ev => ev.VideoId == videoId)
//                .ToListAsync();
//        }
//    }
//}