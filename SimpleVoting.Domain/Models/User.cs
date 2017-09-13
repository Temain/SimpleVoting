using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleVoting.Domain.Models
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Table("User", Schema = "dbo")]
    public class User
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
        [Range(18, 80)]
        public int Age { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        /// <summary>
        /// Опции (ответы на вопросы), выбранные пользователем
        /// </summary>
        public List<Answer> Answers { get; set; }
    }
}
