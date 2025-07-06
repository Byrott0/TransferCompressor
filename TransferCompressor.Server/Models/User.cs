using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransferCompressor.Server.Models
{
    public class User
    {
        [Key]
        public Guid userId { get; set; }

        public string name { get; set; }
        public string username { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        public string password { get; set; }
        public List<Video> UploadedVideos { get; set; } = new List<Video>();
    }
}
