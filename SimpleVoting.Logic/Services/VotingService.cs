using System;
using System.Data.Entity;
using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;
using System.Linq;

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

        public VoteViewModel GetVote()
        {
            var questions = _context.Questions
                .Include(x => x.Answers)
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

        public void SaveVote()
        {
            throw new NotImplementedException();
        }
    }
}
