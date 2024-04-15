using System.ComponentModel.DataAnnotations;

namespace asp_lrs.Models
{
    public class ConsultationRequest
    {
        [Required(ErrorMessage = "Поле Ім'я та Прізвище є обов'язковим.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле Email є обов'язковим.")]
        [EmailAddress(ErrorMessage = "Некоректний формат Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Бажана дата консультації є обов'язковим.")]
        [FutureDate(ErrorMessage = "Дата консультації повинна бути у майбутньому.")]
        [NotOnWeekend(ErrorMessage = "Консультація не може проходити у вихідні.")]
        [NotOnSpecificDay(DayOfWeek.Monday)]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Поле Продукт є обов'язковим.")]
        public string Product { get; set; }
    }
}
