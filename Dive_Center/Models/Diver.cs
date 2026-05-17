using System.ComponentModel.DataAnnotations;

namespace Dive_Center.Models
{
    public class Diver : EFModel
    {
        [Required(ErrorMessage = "Поле 'Email' обязательно")]
        [EmailAddress(ErrorMessage = "Неверный формат Email")]
        public string?Email{ get; set; }

        [Required(ErrorMessage = "Укажите дату рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Укажите уровень сертификации")]
        public string?CertificationLevel { get; set; }
    }
}