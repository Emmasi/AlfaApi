using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ClientEntity
{
    [Key]
    public string Id { get; set; } = new Guid().ToString();
    public string ClientName { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public bool IsActive { get; set; }

    public virtual ClientInformationEntity ContactInformation { get; set; } = null!;
    public virtual ClientAddressEntity Address { get; set; } = null!;

    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];

}
