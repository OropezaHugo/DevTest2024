using System.ComponentModel.DataAnnotations;

namespace backend.data.entities;

public class VotePollResponseDTO
{
    
    public Guid PollId { get; set; }
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    public Guid OptionId { get; set; }
}