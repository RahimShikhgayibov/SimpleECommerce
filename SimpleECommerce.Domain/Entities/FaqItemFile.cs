using SimpleECommerce.Domain.Entities.Bases;

namespace SimpleECommerce.Domain.Entities;

public class FaqItemFile : CreationAndDeletionAuditedEntity
{
    public Guid FaqItemId { get; set; }
    public FaqItem FaqItem { get; set; }
    
    public required string FileOriginalName { get; set; }
    public required string FileName { get; set; }
    public required string FileContentType { get; set; }
    public string Description { get; set; }
}