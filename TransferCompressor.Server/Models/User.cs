using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransferCompressor.Server.Models
{
    public class User
    {
        [Key]
        public Guid userId { get; set; }

        public string username { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        public string Password { get; set; }

        public List<Video> UploadedVideos { get; set; } = new List<Video>();
    }
}
