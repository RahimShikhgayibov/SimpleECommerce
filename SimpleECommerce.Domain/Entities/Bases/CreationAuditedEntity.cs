namespace SimpleECommerce.Domain.Entities.Bases;

public abstract class CreationAuditedEntity :Entity, ICreationAudited
{
    public Guid? CreatorUserId { get; set; }
    public DateTime CreationTime { get; set; }
}