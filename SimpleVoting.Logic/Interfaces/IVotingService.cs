using SimpleVoting.Logic.Models;
using System.Collections.Generic;

namespace SimpleVoting.Logic.Interfaces
{
    public interface IVotingService
    {
        VoteViewModel GetVote();
        bool ValidateVote(VoteViewModel viewModel, out List<string> errorMessages);
        void SaveVote(VoteViewModel viewModel);
    }
}
