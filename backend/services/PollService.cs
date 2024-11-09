using AutoMapper;
using backend.data;
using backend.data.entities;
using backend.DTO;
using backend.services.interfaces;


namespace backend.services;

public class PollService: IPollService
{
    private BackendSingletonDb _backendSingletonDb;
    private IMapper _mapper;

    public PollService(BackendSingletonDb backendSingletonDb, IMapper mapper)
    {
        _backendSingletonDb = backendSingletonDb;
        _mapper = mapper;
    }

    public List<PollDTO> GetPolls()
    {
        var polls = _backendSingletonDb.Polls;
        return polls.Select(polls1 => _mapper.Map<PollDTO>(polls1)).ToList();
    }

    public PollDTO PostPoll(CreatePollDTO poll)
    {
        Guid pollId = Guid.NewGuid();
        var polls = new Polls()
        {
            Id = pollId,
            Name = poll.Name,
            Options = new List<Options>()
        };
        foreach (CreateOptionDTO createOptionDto in poll.Options)
        {
            Guid optionId = Guid.NewGuid();
            var options = _mapper.Map<Options>((createOptionDto, optionId));
            polls.Options.Add(options);
        }
        _backendSingletonDb.Polls.Add(polls);
        return _mapper.Map<PollDTO>(polls);
    }

    public VotePollResponseDTO? VoteForOption(VotePollOptionDTO vote, Guid pollId)
    {
        Polls? polls = _backendSingletonDb.Polls.Find(polls1 => polls1.Id == pollId);
        

        if (polls == null)
        {
            return null;
        }
        Votes? pollvote = _backendSingletonDb.Votes.Find(votes => votes.Email == vote.Email);
        if (pollvote != null)
        {
            return null;
        }
        foreach (Options pollOption in polls.Options)
        {
            if (pollOption.Id == vote.OptionId)
            {
                pollOption.Votes += 1;
                
            }
        }
        _backendSingletonDb.Votes.Add(pollvote);
        return new VotePollResponseDTO()
        {
            OptionId = vote.OptionId,
            Email = vote.Email,
            Id = Guid.NewGuid(),
            PollId = pollId
        };
    }
}