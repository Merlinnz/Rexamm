namespace Domain.Entities;

public class Employee
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    // References
    public EmployeeHistory EmployeeHistory { get; set; }
    public Job Job { get; set; }
}
