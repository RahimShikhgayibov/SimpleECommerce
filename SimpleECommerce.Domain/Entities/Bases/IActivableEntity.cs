namespace SimpleECommerce.Domain.Entities.Bases;

public interface IActivableEntity
{
    public bool IsActive { get; set; }
}