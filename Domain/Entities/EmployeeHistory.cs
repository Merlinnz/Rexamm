using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EmployeeHistory
{
    public int EmployeeHistoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // References
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
