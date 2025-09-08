using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;

public class Permission : Entity
{
    public Guid? ParentId { get; set; }
    public Permission Parent { get; set; }
    
    public required string Name { get; set; }
    public required string Description { get; set; }
}