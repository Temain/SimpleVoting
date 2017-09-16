namespace SimpleVoting.Logic.Models
{
    /// <summary>
    /// Опция (вариант ответа) для голосования
    /// </summary>
    public class AnswerViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Текст опции
        /// </summary>
        public string AnswerText { get; set; }

        /// <summary>
        /// Количество проголосовавших
        /// </summary>
        public int? NumberOfVoters { get; set; }
    }
}
