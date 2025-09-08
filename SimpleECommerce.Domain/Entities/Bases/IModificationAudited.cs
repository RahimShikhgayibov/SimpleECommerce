namespace SimpleECommerce.Domain.Entities.Bases;

public interface IModificationAudited
{
    Guid? LastModifierUserId { get; set; }
    DateTime? LastModificationTime { get; set; }
}