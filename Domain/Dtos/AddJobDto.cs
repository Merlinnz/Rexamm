namespace Domain.Dtos;

public class AddJobDto
{
    public int JobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }  
    public int EmployeeId { get; set; }
}
