using System.ComponentModel.DataAnnotations;

namespace Dive_Center.Models
{
    public class Diver : EFModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CertificationLevel { get; set; }
    }
}