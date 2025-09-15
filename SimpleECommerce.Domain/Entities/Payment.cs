using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;

public class Payment : CreationAuditedEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public string PaymentMethod { get; set; } 
    
    public string? TransactionId { get; set; } 
    
    public decimal Amount { get; set; }
    
    public PaymentStatus Status { get; set; } 

    public Refund Refund { get; set; } 
}