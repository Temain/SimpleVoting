using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleVoting.Logic.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ApplicationDbContext _context;

        public ReportingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<QuestionViewModel> GetNumberOfVoters()
        {
            var questions = _context.Questions
                .Include(x => x.Answers)
                .Where(x => !x.IsDisabled)
                .Select(x => new QuestionViewModel
                {
                    QuestionId = x.QuestionId,
                    QuestionText = x.QuestionText,
                    NumberOfVoters = x.Answers.SelectMany(t => t.Users).Count(),
                    Answers = x.Answers
                        .OrderBy(a => a.Order)
                        .Select(a => new AnswerViewModel
                        {
                            AnswerId = a.AnswerId,
                            AnswerText = a.AnswerText,
                            NumberOfVoters = a.Users.Count()
                        })
                        .ToList()
                })
                .ToList();

            return questions;
        }
    }
}
