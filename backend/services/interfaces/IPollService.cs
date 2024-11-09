using backend.data.entities;
using backend.DTO;

namespace backend.services.interfaces;

public interface IPollService
{
    public List<PollDTO> GetPolls();
    public PollDTO PostPoll(CreatePollDTO poll);
    public VotePollResponseDTO? VoteForOption(VotePollOptionDTO vote, Guid pollId);
}