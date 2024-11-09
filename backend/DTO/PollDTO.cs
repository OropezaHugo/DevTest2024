using System.ComponentModel.DataAnnotations;
using backend.data.entities;

namespace backend.DTO;

public class PollDTO
{
    
    [Key]
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    
    
    public ICollection<Options> Options { get; set; } = new List<Options>();
}