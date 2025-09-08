using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;

public class Role : AuditedEntity, IActivableEntity
{
    public required string Name { get; set; }
    public bool IsDefault { get; set; }
    public string Description { get; set; }
    public bool IsEditable { get; set; }
    public bool IsActive { get; set; }
    
    public IList<RolePermission> RolePermissions { get; set; }
}