using System;
using System.Data.Entity;
using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;
using System.Linq;
using SimpleVoting.Domain.Models;

namespace SimpleVoting.Logic.Services
{
    public class VotingService : IVotingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDictionaryService _dictionaryService;

        public VotingService(ApplicationDbContext context, IDictionaryService dictionaryService)
        {
            _context = context;
            _dictionaryService = dictionaryService;
        }

        /// <summary>
        /// Получение необходимых данных для госования
        /// </summary>
        public VoteViewModel GetVote()
        {
            var questions = _context.Questions
                .Include(x => x.Answers)
                .Where(x => !x.IsDisabled)
                .Select(x => new QuestionViewModel
                {
                    QuestionId = x.QuestionId,
                    QuestionText = x.QuestionText,
                    Answers = x.Answers
                        .OrderBy(a => a.Order)
                        .Select(a => new AnswerViewModel
                        {
                            AnswerId = a.AnswerId,
                            AnswerText = a.AnswerText
                        })
                        .ToList()
                })
                .ToList();

            var genders = _dictionaryService.GetGenders();

            // Тут другие необходимые справочники...

            var vote = new VoteViewModel
            {
                User = new UserViewModel { Genders = genders },
                Questions = questions
            };

            return vote;
        }

        /// <summary>
        /// Сохранение результатов голосования
        /// </summary>
        public void SaveVote(VoteViewModel viewModel)
        {
            if (viewModel.User == null)
            {
                // Если нет информации о пользователе
                // throw
            }

            if (viewModel.Questions == null || !viewModel.Questions.Any())
            {
                // Если ответов на вопросы нет
                // throw
            }
            else
            {
                // Если есть ответы на вопросы, но не на все
                var activeQuestions = _context.Questions.Count(x => !x.IsDisabled);
                var questionsAnswers = viewModel.Questions.Count(x => x.SelectedAnswerId != 0);
                if (activeQuestions != questionsAnswers)
                {
                    // throw 
                }
            }

            var selectedAnswers = viewModel.Questions.Select(x => x.SelectedAnswerId);
            var answers = _context.Answers.Where(x => selectedAnswers.Contains(x.AnswerId)).ToList();

            // Если ответ не соответствует вопросу
            // ...

            var user = new User
            {
                Username = viewModel.User.Username,
                GenderId = viewModel.User.GenderId,
                Age = viewModel.User.Age,
                Answers = answers
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
