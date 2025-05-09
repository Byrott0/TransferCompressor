﻿using System.ComponentModel.DataAnnotations;
namespace TransferCompressor.Server.Models
{
    public class Video
    {

        [Key]
        public Guid Id { get; set; }
        public User user { get; set; }
        public Guid userId { get; set; }
        public string fileNaam { get; set; }
        public string CompressedFilePad { get; set; }   
        public string OriginalFilePad { get; set; }
        public long OriginalFileSize { get; set; }
        public long CompressedFileSize { get; set; }
        public DateTime uploadDatum { get; set; }
        public string DeelbaarLink { get; set; }
        public ICollection<EmbedVideo> EmbedVideo { get; set; }

    }
}
