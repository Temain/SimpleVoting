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
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public int GenderId { get; set; }
        public List<GenderViewModel> Genders { get; set; }
    }
}
