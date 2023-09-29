namespace Cinema.Domains.Entities.Base
{
    public class AuditCreationEntity : BaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}