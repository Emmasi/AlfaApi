using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ClientInformationEntity
{
    [Key]
    public string ClientId { get; set; } = new Guid().ToString();
    public virtual ClientEntity Client { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Reference { get; set; }
}
