namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;


[ApiController]
[Route("controller")]


public class EmployeeController
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet("GetEmployees")]
    public async Task<Response<List<GetEmployeeDto>>> GetEmployee()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpPost("InsertEmployee")]
    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
    {
        return await _employeeService.AddEmployee(employee);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto employee)
    {
        return await _employeeService.UpdateEmployee(employee);
    }

    [HttpDelete("DeleteEmployee")]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }

    
    [HttpGet("GetById")]
    public async Task<Response<GetEmployeeDto>> GetById(int id)
    {
        return await _employeeService.GetById(id);
    }
}
