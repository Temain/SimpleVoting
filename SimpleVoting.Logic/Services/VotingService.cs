using System;
using System.Data.Entity;
using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;
using System.Linq;
using SimpleVoting.Domain.Models;
using System.Collections.Generic;

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
        /// Проверка голоса на валидность
        /// </summary>
        public bool ValidateVote(VoteViewModel viewModel, out List<string> errorMessages)
        {
            errorMessages = new List<string>();

            // Если нет информации о пользователе
            if (viewModel.User == null)
            {
                errorMessages.Add("Информация о пользователе не заполнена");
            }

            // Если нет вопросов
            if (viewModel.Questions == null || !viewModel.Questions.Any())
            {
                errorMessages.Add("В голосовании должен быть хотя бы один вопрос");
            }
            else
            {               
                int activeQuestions = _context.Questions.Count(x => !x.IsDisabled);
                int questionsAnswers = viewModel.Questions.Count(x => x.SelectedAnswerId != 0);

                // Если ответов на вопросы нет
                if (activeQuestions != questionsAnswers)
                {
                    errorMessages.Add("Не на все вопросы получен ответ");
                }
            }

            var selectedAnswers = viewModel.Questions.Select(x => x.SelectedAnswerId);
            var answers = _context.Answers.Where(x => selectedAnswers.Contains(x.AnswerId)).ToList();

            // Если ответ не соответствует вопросу
            // ...

            return true;
        }

        /// <summary>
        /// Сохранение результатов голосования
        /// </summary>
        public void SaveVote(VoteViewModel viewModel)
        {
            var selectedAnswers = viewModel.Questions.Select(x => x.SelectedAnswerId);
            var answers = _context.Answers.Where(x => selectedAnswers.Contains(x.AnswerId)).ToList();

            var user = new User
            {
                Username = viewModel.User.Username,
                GenderId = viewModel.User.GenderId ?? 0,
                Age = viewModel.User.Age ?? 0,
                Answers = answers
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
