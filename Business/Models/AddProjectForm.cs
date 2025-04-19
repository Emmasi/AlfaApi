using Business.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class AddProjectForm
{
    [Required]
    public string? Image { get; set; }

    [Required]
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    [DateAfter(nameof(StartDate))]
    public DateTime EndDate { get; set; }
    [Required]
    [Range(1, double.MaxValue)]
    public decimal Budget { get; set; }

    [Required]
    public string ClientName { get; set; } = null!;
    [Required]
    public string MemberFirstName { get; set; } = null!;
    [Required]
    public string MemberLastName { get; set; } = null!;
}

