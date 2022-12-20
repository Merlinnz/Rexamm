using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EmployeeHistoryController
{
    private readonly EmployeeHistoryService _employeeHistoryService;
    public EmployeeHistoryController(EmployeeHistoryService employeeHistoryService)
    {
        _employeeHistoryService = employeeHistoryService;
    }

    [HttpGet("GetEmployeeHistory")]
    public async Task<Response<List<GetEmployeeHistoryDto>>> GetEmployeeHistory()
    {
        return await _employeeHistoryService.GetEmployeeHistory();
    }

    [HttpPost("InsertEmployeeHistory")]
    public async Task<Response<AddEmployeeHistoryDto>> AddEmployeeHistory(AddEmployeeHistoryDto history)
    {
        return await _employeeHistoryService.AddEmployeeHistory(history);
    }

    [HttpPut("UpdateEmployeeHistory")]
    public async Task<Response<AddEmployeeHistoryDto>> UpdateEmployeeHistory(AddEmployeeHistoryDto history)
    {
        return await _employeeHistoryService.UpdateEmployeeHistory(history);
    }

    [HttpDelete("DeleteEmployeeHistory")]
    public async Task<Response<string>> DeleteEmplyeeHistory(int id)
    {
        return await _employeeHistoryService.DeleteEmplyeeHistory(id);
    }
}
