using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleVoting.Domain.Models
{
    /// <summary>
    /// Опция (вариант ответа) для голосования
    /// </summary>
    [Table("Answer", Schema = "dbo")]
    public class Answer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Текст опции
        /// </summary>
        [Required]
        [StringLength(200)]
        public string AnswerText { get; set; }

        /// <summary>
        /// Порядок
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Вопрос, к которому относится опция
        /// </summary>
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        /// <summary>
        /// Пользователи, выбраышие эту опцию
        /// </summary>
        public List<User> Users { get; set; }
    }
}
