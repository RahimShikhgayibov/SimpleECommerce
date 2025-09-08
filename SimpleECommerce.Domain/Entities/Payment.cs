using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;

public class Payment : CreationAuditedEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public string PaymentMethod { get; set; } // e.g., "DebitCard", "CreditCard", "PayPal", "COD"
    
    public string? TransactionId { get; set; } // From payment gateway
    
    public decimal Amount { get; set; }
    
    public DateTime PaymentDate { get; set; } // lazimdirmi?
    
    public PaymentStatus Status { get; set; } // "Completed", "Pending", "Failed", "Refunded"

    public Refund Refund { get; set; } // Navigational property to Refund
}