using AutoMapper;
using backend.data;
using backend.data.entities;
using backend.DTO;
using backend.services.interfaces;


namespace backend.services;

public class PollService: IPollService
{
    private BackendDbContext _backendDbContext;
    private IMapper _mapper;

    public PollService(BackendDbContext backendDbContext, IMapper mapper)
    {
        _backendDbContext = backendDbContext;
        _mapper = mapper;
    }

    public List<PollDTO> GetPolls()
    {
        List<Polls> list = new List<Polls>();
        foreach (Polls poll in _backendDbContext.Polls)
        {
            var pollOptions = _backendDbContext.Options.Where(o => o.Id == poll.Id).ToList();
            list.Add(new Polls()
            {
                Id = poll.Id,
                Name = poll.Name,
                Options = pollOptions,
            });
        }
        
        return list.Select(poll => _mapper.Map<PollDTO>(poll)).ToList();
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
            _backendDbContext.Options.Add(options);
        }
        _backendDbContext.Polls.Add(polls);
        _backendDbContext.SaveChanges();
        return _mapper.Map<PollDTO>(polls);
    }

    public VotePollResponseDTO? VoteForOption(VotePollOptionDTO vote, Guid pollId)
    {
        Polls? polls = _backendDbContext.Polls.FirstOrDefault(polls1 => polls1.Id == pollId);
        if (polls == null)
        {
            return null;
        }
        Votes? pollvote = _backendDbContext.Votes.FirstOrDefault(votes => votes.Email == vote.Email);
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
        _backendDbContext.Votes.Add(pollvote);
        _backendDbContext.SaveChanges();
        return new VotePollResponseDTO()
        {
            OptionId = vote.OptionId,
            Email = vote.Email,
            Id = Guid.NewGuid(),
            PollId = pollId
        };
    }
}