using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;

public class FaqItem : FullAuditedEntity,IActivableEntity
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public bool IsActive { get; set; }
    
    public IList<FaqItemFile> FaqItemFiles { get; set; }
}