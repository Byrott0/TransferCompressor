using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TransferCompressor.Server.Models;

namespace TransferCompressor.Server.DTO
{
    public class VideoDTO
    {
        [Key]
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("userId")]
        public Guid userId { get; set; }

        [JsonPropertyName("fileNaam")]
        public string fileNaam { get; set; }

        [JsonPropertyName("originalFilePad")]
        public string OriginalFilePad { get; set; }

        [JsonPropertyName("originalFileSize")]
        public long OriginalFileSize { get; set; }

        [JsonPropertyName("uploadDatum")]
        public DateTime UploadDatum { get; set; }

        [JsonPropertyName("deelbaarLink")]
        public string DeelbaarLink { get; set; }

        //[JsonPropertyName("embedVideo")]
        //public ICollection<EmbedVideo> EmbedVideo { get; set; }
    }
}