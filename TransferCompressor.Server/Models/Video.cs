using System.ComponentModel.DataAnnotations;
namespace TransferCompressor.Server.Models
{
    public class Video
    {

        [Key]
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public User user { get; set; }
        public long OriginalFileSize { get; set; }
        public DateTime uploadDatum { get; set; }
    }
}
