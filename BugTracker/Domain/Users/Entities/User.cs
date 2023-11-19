using BugTracker.Domain.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Users.Entities;

public class User : AuditableEntity
{
    public Guid Id { get; set; }
    [Required, StringLength(50)]
    public required string FirstName { get; set; }
    [Required,StringLength(50)]
    public required string LastName { get; set; }
    [StringLength(100)]
    public required string Email { get; set; }
}
