using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetEmployeeDto>>> GetEmployees()
    {   
        var list = _mapper.Map<List<GetEmployeeDto>>(await _context.Employees.ToListAsync());
        return new Response<List<GetEmployeeDto>>(list);
    }

    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto employee)
    {
        var newEmployee = _mapper.Map<Employee>(employee);
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return new Response<AddEmployeeDto>(employee);
    }

    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto employee)
    {
        var find = await _context.Employees.FindAsync(employee.EmployeeId);
        find.FirstName = employee.FirstName;
        find.LastName = employee.LastName;
        find.Phone = employee.Phone;
        find.Address = employee.Address;
        
        await _context.SaveChangesAsync();
        return new Response<AddEmployeeDto>(employee);
    }

    public async Task<Response<string>> DeleteEmployee(int id)
    {
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Employee Has Been Deleted");
    }
    
    public async Task<Response<GetEmployeeDto>> GetById(int id)
    {
        var find = _mapper.Map<GetEmployeeDto>(await _context.Employees.FindAsync(id));
        return new Response<GetEmployeeDto>(find);
    }

}
