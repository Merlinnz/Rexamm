namespace Domain.Dtos;

public class GetEmployeeHistoryDto
{
    public int EmployeeHistoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EmployeeId { get; set; }
}
