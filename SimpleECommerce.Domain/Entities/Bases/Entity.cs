namespace SimpleECommerce.Domain.Entities.Bases;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
}