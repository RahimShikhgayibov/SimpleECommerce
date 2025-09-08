using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;

public class User : AuditedEntity , IActivableEntity
{
    //public Guid? SubjectId { get; set; }
    //public Subject Subject { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    
    public string ImageName { get; set; }
    public string ImageContentType { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string PatronymicName { get; set; }
    public required string PinCode { get; set; }
    public required string Position { get; set; }
    public required string EmailAddress { get; set; }
    public string Fax { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required IList<string> PhoneNumbers { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
    public required string SaltHash { get; set; }
    public string RefreshToken { get; set; }
    public bool IsMailConfirmed { get; set; }
    public bool IsDataConfirmed { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Order> Orders { get; set; }
    
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
