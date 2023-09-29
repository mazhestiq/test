namespace Cinema.Domains.Entities.Base
{
    public class AuditEntity : AuditCreationEntity
    {
        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}