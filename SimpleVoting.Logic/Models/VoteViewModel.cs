using System.Collections.Generic;

namespace SimpleVoting.Logic.Models
{
    public class VoteViewModel
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserViewModel User { get; set; }

        /// <summary>
        /// Вопросы для голосования
        /// </summary>
        public List<QuestionViewModel> Questions { get; set; }
    }
}
