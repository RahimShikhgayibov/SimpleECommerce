namespace SimpleECommerce.Domain.Entities.Bases;

public interface ICreationAudited
{
    Guid? CreatorUserId { get; set; }
    DateTime CreationTime { get; set; }
}