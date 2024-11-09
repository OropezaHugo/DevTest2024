using System.ComponentModel.DataAnnotations;

namespace backend.data.entities;

public class Polls
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public ICollection<Options> Options { get; set; } = new List<Options>();
}