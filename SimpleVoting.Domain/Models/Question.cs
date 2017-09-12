using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleVoting.Domain.Models
{
    /// <summary>
    /// Вопрос для голосования
    /// </summary>
    [Table("Question", Schema = "dbo")]
    public class Question
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        [Required]
        [StringLength(2000)]
        public string QuestionText { get; set; }

        /// <summary>
        /// Опции для голосования
        /// </summary>
        public List<Answer> Answers { get; set; }
    }
}
