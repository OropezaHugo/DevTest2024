using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class CreateOptionDTO
{
    
    [Required]
    public required string Name { get; set; }
}