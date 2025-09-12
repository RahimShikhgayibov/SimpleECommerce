using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;


public class Address : AuditedEntity,IActivableEntity
{
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    
    public string AddressLine1 { get; set; }
    
    public string AddressLine2 { get; set; }
    
    public string City { get; set; }
    public string Street { get; set; }
    
    public string State { get; set; }
    
    public string PostalCode { get; set; }
    
    public string Country { get; set; }

    public bool IsActive { get; set; }
}