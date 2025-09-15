using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;

public class Refund : CreationAuditedEntity
{
    public int CancellationId { get; set; }
    public Cancellation Cancellation { get; set; }
    
    public int PaymentId { get; set; }
    public Payment Payment { get; set; }
    
    
    public decimal Amount { get; set; }
    
    public RefundStatus Status { get; set; }
    
    public RefundMethod RefundMethod { get; set; }
    
    public string? RefundReason { get; set; }

    public string? TransactionId { get; set; }
}