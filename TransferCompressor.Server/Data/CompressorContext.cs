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
        : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<EmbedVideo>()
                .HasKey(e => e.embedId);

            modelBuilder.Entity<EmbedVideo>()
                .HasOne(e => e.video)
                .WithMany(v => v.EmbedVideo)
                .HasForeignKey(e => e.VideoId)
                .OnDelete(DeleteBehavior.Cascade); // wanneer embed video wordt verwijderd
           // wordt ook de video verwijderd

            modelBuilder.Entity<User>()
                .HasKey(u => u.userId);

        }
    }
}
