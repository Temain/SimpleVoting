using SimpleVoting.Logic.Models;

namespace SimpleVoting.Logic.Interfaces
{
    public interface IVotingService
    {
        VoteViewModel GetVote();
        void SaveVote();
    }
}
