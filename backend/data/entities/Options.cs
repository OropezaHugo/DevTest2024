using System.ComponentModel.DataAnnotations;

namespace backend.data.entities;

public class Options
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public uint Votes { get; set; }
    
}