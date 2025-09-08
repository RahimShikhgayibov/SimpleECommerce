namespace SimpleECommerce.Domain.Entities.Bases;

public interface IDeletionAudited
{
    bool IsDeleted { get; set; }
    Guid? DeleterUserId { get; set; }
    DateTime? DeletionTime { get; set; }
}