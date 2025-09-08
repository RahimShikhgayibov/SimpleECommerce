namespace SimpleECommerce.Domain.Entities.Bases;

public abstract class CreationAndDeletionAuditedEntity : Entity, ICreationAudited, IDeletionAudited
{
    public Guid? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? DeleterUserId { get; set; }
    public DateTime? DeletionTime { get; set; }
}