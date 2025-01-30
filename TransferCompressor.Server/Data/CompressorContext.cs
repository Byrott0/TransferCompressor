using Microsoft.EntityFrameworkCore;
using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.Data
{
    public class CompressorContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Video> Videos => Set<Video>();
        public DbSet<EmbedVideo> EmbedVideos => Set<EmbedVideo>();

        public CompressorContext(DbContextOptions<CompressorContext> options)
        : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Video>()
            .HasOne(v => v.user)
            .WithMany(u => u.UploadedVideos)
            .HasForeignKey(v => v.userId)
            .OnDelete(DeleteBehavior.Cascade); // Verwijder video's bij verwijderen van gebruiker


            modelBuilder.Entity<EmbedVideo>()
                .HasKey(e => e.embedId);
  
            modelBuilder.Entity<EmbedVideo>()
                .HasOne(e => e.video)
                .WithMany(v => v.EmbedVideo)
                .HasForeignKey(e => e.VideoId)
                .OnDelete(DeleteBehavior.Cascade); // wanneer video wordt verwijderd
                                                   // wordt ook de embed video verwijderd

            modelBuilder.Entity<User>()
       .Property(u => u.userId)
       .ValueGeneratedOnAdd() // Voeg dit toe
       .HasDefaultValueSql("NEWID()"); // Voor SQL Server

            modelBuilder.Entity<User>()
             .HasIndex(u => u.Email)
             .IsUnique();


        }
    }
}
