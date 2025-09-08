using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;


public class Cancellation : CreationAuditedEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    
    public string Reason { get; set; }
    
    public CancellationStatus Status { get; set; }
    
    //public DateTime RequestedAt { get; set; } creation time is same
    
    //  public DateTime? ProcessedAt { get; set; } is necessary?
    
    // public int? ProcessedBy { get; set; } creator user id 
    
    public decimal OrderAmount { get; set; }
    
    public decimal? CancellationCharges { get; set; } = 0.00m;
    
    //public string? Remarks { get; set; }
    //IsValid ?
    
    public Refund Refund { get; set; }
}