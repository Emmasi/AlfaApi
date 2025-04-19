using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class MemberEntity
{
    [Key]
    public string Id { get; set; } = new Guid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public virtual ICollection<ProjectEntity> Projects { get; set; } = [];
}
