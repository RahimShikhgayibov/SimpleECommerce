namespace SimpleECommerce.Domain.Entities.Bases;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}