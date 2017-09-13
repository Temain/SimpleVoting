using System.Collections.Generic;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;
using ClassSchedule.Domain.Context;
using System.Linq;

namespace SimpleVoting.Logic.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly ApplicationDbContext _context;

        public DictionaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GenderViewModel> GetGenders()
        {
            var genders = _context.Genders
                .Select(x => new GenderViewModel
                {
                    GenderId = x.GenderId,
                    GenderName = x.GenderName
                })
                .ToList();

            return genders;
        }
    }
}
