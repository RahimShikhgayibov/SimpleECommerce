using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class CartItem : CreationAndDeletionAuditedEntity
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public decimal Discount { get; set; }
    
    public decimal TotalPrice { get; set; }
}