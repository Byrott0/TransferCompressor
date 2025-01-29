using System.ComponentModel.DataAnnotations;
using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.DTO
{
    public class VideoDTO
    {
        [Key]
        public Guid Id { get; set; }
        public User user { get; set; }
        public string fileNaam { get; set; }
        public string OriginalFilePad { get; set; }
        public long OriginalFileSize { get; set; }
        public DateTime uploadDatum { get; set; }
        public string DeelbaarLink { get; set; }
        public ICollection<EmbedVideo> EmbedVideo { get; set; }
    }
}
