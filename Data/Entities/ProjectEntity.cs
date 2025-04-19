using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = new Guid().ToString();
    public string ProjectName { get; set; } = null!;
    public string? Image { get; set; }
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }
    [Column(TypeName = "money")]
    public decimal Budget { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public Status Status { get; set; }

    [ForeignKey(nameof(Client))]
    public string ClientId { get; set; } = new Guid().ToString();
    public virtual ClientEntity Client { get; set; } = null!;

    [ForeignKey(nameof(Member))]
    public string MemberId { get; set; } = new Guid().ToString();
    public virtual MemberEntity Member { get; set; } = null!;
}

public enum Status
{
    Completed = 0,
    Started = 1,
    Ongoing=2,
}