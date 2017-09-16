using SimpleVoting.Logic.Models;
using System.Collections.Generic;

namespace SimpleVoting.Logic.Interfaces
{
    public interface IReportingService
    {
        List<QuestionViewModel> GetNumberOfVoters();
    }
}
