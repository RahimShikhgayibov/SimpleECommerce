using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;


public class Order : FullAuditedEntity
{
    public string OrderNumber { get; set; }
    
    public DateTime OrderDate { get; set; } //lazimdirmi?
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int BillingAddressId { get; set; }
    public Address BillingAddress { get; set; }
    
    public int ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; }
    
    public decimal TotalBaseAmount { get; set; }
    
    public decimal TotalDiscountAmount { get; set; }
    
    public decimal ShippingCost { get; set; }
    
    public decimal TotalAmount { get; set; }

    public OrderStatus OrderStatus { get; set; }

    
    public ICollection<OrderItem> OrderItems { get; set; }
    
    public Payment Payment { get; set; } 
    public Cancellation Cancellation { get; set; } 
}