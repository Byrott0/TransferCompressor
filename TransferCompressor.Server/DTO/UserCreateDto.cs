using TransferCompressor.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace TransferCompressor.Server.DTO
{
    public class UserCreateDto
    {
        
        [Required(ErrorMessage = "username is verplicht.")]
        public string username { get; set; }

        [Required(ErrorMessage = "email is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig emailformaat.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minimaal 6 tekens bevatten.")]
        public string password { get; set; }
    }
}