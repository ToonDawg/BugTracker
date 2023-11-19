using System.ComponentModel.DataAnnotations;

namespace BugTracker.Domain.Common.Entities;
public abstract class AuditableEntity
{
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public Guid CreatedBy { get; set; }
    [Required]
    public DateTime ModifiedDate { get; set; }
    [Required]
    public Guid ModifiedBy { get; set;}
    [Required]
    public bool IsDeleted { get; set; } = false;
}

