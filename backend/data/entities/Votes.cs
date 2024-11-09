using System.ComponentModel.DataAnnotations;

namespace backend.data.entities;

public class Votes
{
    [Key]
    public Guid Id { get; set; }
    [EmailAddress]
    [Required]
    public required string Email { get; set; }
}