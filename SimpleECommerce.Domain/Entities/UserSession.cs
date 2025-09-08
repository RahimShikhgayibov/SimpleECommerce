using SimpleECommerce.Domain.Entities.Bases;
using SimpleECommerce.Domain.Enums;

namespace SimpleECommerce.Domain.Entities;

public class UserSession : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public UserSessionType SessionType { get; set; }
    public DateTime ActionDate { get; set; }
    public string Details { get; set; }
}