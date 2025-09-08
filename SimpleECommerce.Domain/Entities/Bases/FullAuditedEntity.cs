namespace SimpleECommerce.Domain.Entities.Bases;

public abstract class FullAuditedEntity : AuditedEntity, IDeletionAudited
{
    public bool IsDeleted { get; set; }
    public Guid? DeleterUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
}