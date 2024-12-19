namespace TransferCompressor.Server.Models
{
    public class Video
    {

        public Guid Id { get; set; }
        public User userId { get; set; }
        public string fileNaam { get; set; }
        public string CompressedFilePad { get; set; }   
        public string OriginalFilePad { get; set; }
        public string OriginalFileSize { get; set; }
        public string CompressedFileSize { get; set; }
        public DateTime uploadDatum { get; set; }
        public string DeelbaarLink { get; set; }

    }
}
