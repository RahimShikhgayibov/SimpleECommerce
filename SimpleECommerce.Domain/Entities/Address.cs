namespace SimpleECommerce.Domain.Entities;


public class Address
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }
    
    public Customer Customer { get; set; }
    
    public string AddressLine1 { get; set; }
    
    public string AddressLine2 { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string PostalCode { get; set; }
    
    public string Country { get; set; }
}