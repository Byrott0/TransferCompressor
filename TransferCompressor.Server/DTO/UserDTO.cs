using TransferCompressor.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace TransferCompressor.Server.DTO
{
    public class UserDTO
    {
        public Guid userId { get; set; }
        // userId wordt automatisch gegenereerd door de database
        public string naam { get; set; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig emailformaat.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [MinLength(6, ErrorMessage = "Wachtwoord moet minimaal 6 tekens bevatten.")]
        public string Password { get; set; }
    }
}