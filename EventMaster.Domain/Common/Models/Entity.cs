namespace EventMaster.Domain.Common.Models;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }

    DateTime UpdatedAt { get; set; }
}