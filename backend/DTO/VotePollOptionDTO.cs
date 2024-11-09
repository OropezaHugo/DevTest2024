using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class VotePollOptionDTO
{
    
    [Key]
    public required Guid OptionId { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}