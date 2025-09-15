using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class Cart : FullAuditedEntity, IActivableEntity, IRemarkableEntity
{
    public int UserId { get; set; }
    
    public User User { get; set; }

    public ICollection<CartItem> CartItems { get; set; }
    
    public bool IsActive { get; set; }
    public bool? IsValid { get; set; }
}