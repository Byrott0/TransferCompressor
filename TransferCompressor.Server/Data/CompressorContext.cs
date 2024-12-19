using Microsoft.EntityFrameworkCore;
using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Data
{
    public class CompressorContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<EmbedVideo> EmbedVideos { get; set; }

        public CompressorContext(DbContextOptions<CompressorContext> options)
        : base(options)
        { }
    }
}
