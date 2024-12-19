namespace TransferCompressor.Server.Models
{
    public class User
    {
        public Guid userId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Video> UploadedVideos { get; set; }


    }
}
