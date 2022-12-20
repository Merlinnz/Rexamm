using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeHistoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public EmployeeHistoryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetEmployeeHistoryDto>>> GetEmployeeHistory()
    {
        var list = _mapper.Map<List<GetEmployeeHistoryDto>>(await _context.EmployeeHistories.ToListAsync());
        return new Response<List<GetEmployeeHistoryDto>>(list);
    }

    public async Task<Response<AddEmployeeHistoryDto>> AddEmployeeHistory(AddEmployeeHistoryDto history)
    {
        var newEmployeeHistory = _mapper.Map<EmployeeHistory>(history);
        _context.EmployeeHistories.Add(newEmployeeHistory);
        await _context.SaveChangesAsync();
        return new Response<AddEmployeeHistoryDto>(history);
    }

    public async Task<Response<AddEmployeeHistoryDto>> UpdateEmployeeHistory(AddEmployeeHistoryDto history)
    {
        var find = await _context.EmployeeHistories.FindAsync(history.EmployeeHistoryId);
        find.StartDate = history.StartDate;
        find.EndDate = history.EndDate;
        find.EmployeeId = history.EmployeeId;

        await _context.SaveChangesAsync();
        return new Response<AddEmployeeHistoryDto>(history);
    }

    public async Task<Response<string>> DeleteEmplyeeHistory(int id)
    {
        var find = await _context.EmployeeHistories.FindAsync(id);
        _context.EmployeeHistories.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("EmployeeHistory has been deleted");
    }
}
