using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class OrderItem : CreationAuditedEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public decimal Discount { get; set; }
    
    public decimal TotalPrice { get; set; }
}