using Cinema.Domains.Entities.Base;

namespace Cinema.Domains.Entities;

public class Contact : AuditEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}