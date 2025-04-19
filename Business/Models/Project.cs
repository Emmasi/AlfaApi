using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Project
{
    [Required]
    public string Id { get; set; } = null!;
    public string? Image { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    //[Required]
    //[Range(0, 1000000, ErrorMessage = "Budget får inte vara negativ.")]
    public decimal Budget { get; set; }

    public Client Client { get; set; } = null!;
    public Member Member { get; set; } = null!;
    public Status Status { get; set; }
}
public enum Status
{
    Completed = 0,
    Started = 1,
    Ongoing = 2,
}
