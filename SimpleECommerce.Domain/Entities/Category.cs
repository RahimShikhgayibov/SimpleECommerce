using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class Category : FullAuditedEntity,IActivableEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Product> Products { get; set; }
}