using System.ComponentModel.DataAnnotations;

namespace TransferCompressor.Server.DTO
{
    public class UserGetDto
    {
        public Guid userId { get; set; }
        // userId wordt automatisch gegenereerd door de database

        public string username { get; set; }

        [Required(ErrorMessage = "email is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig emailformaat.")]
        public string Email { get; set; }
    }
}
