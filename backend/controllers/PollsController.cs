using backend.DTO;
using backend.services.interfaces;
using Microsoft.AspNetCore.Mvc;
namespace backend.controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PollsController: ControllerBase
{
    private readonly IPollService _pollService;

    public PollsController(IPollService pollService)
    {
        _pollService = pollService;
    }

    [HttpGet]
    public IActionResult GetPolls()
    {
        return Ok(_pollService.GetPolls());
    }

    [HttpPost]
    public IActionResult PostPoll([FromBody] CreatePollDTO poll)
    {
        return Ok(_pollService.PostPoll(poll));
    }

    [HttpPost("{id}/votes")]
    public IActionResult VoteOption([FromBody] VotePollOptionDTO vote, Guid id)
    {
        var result = _pollService.VoteForOption(vote, id);
        if (result == null)
        {
            throw new HttpRequestException("Unable to submit the vote.", new Exception());
        }
        return Ok(result);
    }
    
}