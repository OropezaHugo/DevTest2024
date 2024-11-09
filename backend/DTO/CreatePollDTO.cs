using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class CreatePollDTO
{
    
    [Required]
    public required string Name { get; set; }
    
    public ICollection<CreateOptionDTO> Options { get; set; } = new List<CreateOptionDTO>();
}