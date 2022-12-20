using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class About
{
    [Key]
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    
    public int EmployeeHistoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int JobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }  
}
