using Dive_Center.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Dive_Center.Tests
{
    public class DiverTests
    {
        [Fact]
        public void Diver_EmptyName_ShouldBeInvalid()
        {
            // 1. Подготовка: создаем дайвера с пустой строкой в поле Name
            var diver = new Diver
            {
                Name = "", // Имя пустое, а в модели оно [Required]
                Email = "test@mail.com",
                CertificationLevel = "Open Water Diver (OWD)"
            };

            var context = new ValidationContext(diver);
            var results = new List<ValidationResult>();

            // 2. Действие: запускаем проверку валидации объекта
            bool isValid = Validator.TryValidateObject(diver, context, results, true);

            // 3. Проверка: ожидаем false, так как обязательное поле Name не заполнено
            Assert.False(isValid);
        }
    }
}