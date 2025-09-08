using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class Feedback : FullAuditedEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Rating { get; set; }
    
    public string? Comment { get; set; }
    
    //public DateTime CreatedAt { get; set; } zaten var
    
    public DateTime UpdatedAt { get; set; } //ehtiyac varmi?
}