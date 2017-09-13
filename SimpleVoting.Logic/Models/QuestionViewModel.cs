using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVoting.Logic.Models
{
    /// <summary>
    /// Вопрос для голосования
    /// </summary>
    public class QuestionViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Выбранный вариант ответа
        /// </summary>
        public int SelectedAnswerId { get; set; }

        /// <summary>
        /// Опции для голосования
        /// </summary>
        public List<AnswerViewModel> Answers { get; set; }
    }
}
