namespace Domain.Entities;

public class Job
{
    public int JobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }  

    // References
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
