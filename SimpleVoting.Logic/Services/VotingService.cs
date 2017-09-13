using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;

namespace SimpleVoting.Logic.Services
{
    public class VotingService : IVotingService
    {
        private readonly ApplicationDbContext _context;

        public VotingService(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
