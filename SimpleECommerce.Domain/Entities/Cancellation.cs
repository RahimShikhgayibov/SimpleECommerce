using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;


public class Cancellation : CreationAndDeletionAuditedEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    
    public string Reason { get; set; }
    
    public CancellationStatus Status { get; set; }
    
    public decimal OrderAmount { get; set; }
    
    public decimal? CancellationCharges { get; set; } = 0.00m;
    
    public Refund Refund { get; set; }
}