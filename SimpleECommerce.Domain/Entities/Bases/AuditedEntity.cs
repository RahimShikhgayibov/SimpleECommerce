namespace SimpleECommerce.Domain.Entities.Bases;

public abstract class AuditedEntity : CreationAuditedEntity , IAudited
{
    public Guid? LastModifierUserId { get; set; }
    public DateTime? LastModificationTime { get; set; }
}