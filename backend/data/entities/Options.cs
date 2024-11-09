using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.data.entities;

public class Options
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public uint Votes { get; set; }
    
    public Guid PollId { get; set; }
    
    [ForeignKey(nameof(PollId))]
    public Polls? Poll { get; set; }
    
}