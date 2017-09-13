using ClassSchedule.Domain.Context;
using SimpleVoting.Logic.Interfaces;

namespace SimpleVoting.Logic.Services
{
    public class ReportingService : IReportingService
    {
        private readonly ApplicationDbContext _context;

        public ReportingService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
