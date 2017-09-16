using System.Collections.Generic;

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
        /// Количество проголосовавших
        /// </summary>
        public int? NumberOfVoters { get; set; }

        /// <summary>
        /// Опции для голосования
        /// </summary>
        public List<AnswerViewModel> Answers { get; set; }
    }
}
