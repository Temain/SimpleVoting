using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleVoting.Logic.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Идентификтор
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать имя")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string Username { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать возраст")]
        [Range(18, 80, ErrorMessage = "Допускаются только люди возрастом от 18 до 80 лет")]
        public int? Age { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        [Required(ErrorMessage = "Выберите пол")]
        public int? GenderId { get; set; }
        public List<GenderViewModel> Genders { get; set; }
    }
}
