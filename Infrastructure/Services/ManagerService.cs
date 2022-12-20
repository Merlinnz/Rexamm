using System.Linq;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ManagerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ManagerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetManagerDto>>> GetManager()
    {
        var list = _mapper.Map<List<GetManagerDto>>(await _context.Managers.ToListAsync());
        return new Response<List<GetManagerDto>>(list);
    }

    public async Task<Response<AddManagerDto>> AddManager(AddManagerDto manager)
    {
        var newManager = _mapper.Map<Manager>(manager);
        _context.Managers.Add(newManager);
        await _context.SaveChangesAsync();
        return new Response<AddManagerDto>(manager);
    }

    public async Task<Response<AddManagerDto>> UpdateManager(AddManagerDto manager)
    {
        var find = await _context.Managers.FindAsync(manager.ManagerId);
        find.FirstName = manager.FirstName;
        find.LastName = manager.LastName;
        find.Email = manager.Email;
        find.Phone = manager.Phone;
        find.Address = manager.Address;

        await _context.SaveChangesAsync();
        return new Response<AddManagerDto>(manager);
    }
    
    public async Task<Response<string>> DeleteManager(int id)
    {
        var find = await _context.Managers.FindAsync(id);
        _context.Managers.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Manager has been deleted");
    }
    public async Task<Response<AboutEmployee>> GetById(int id)
    {
        var find = _mapper.Map<AboutEmployee>(await _context.AboutEs.FindAsync(id));
        return new Response<AboutEmployee>(find);

        // var item = _context.Employees.FirstOrDefault(i => i.EmployeeId == id);
        // return new Response<AboutEmployee>(item);
    }

    public async Task<Response<List<AboutEmployee>>> GetAboutEmployee()
    {
        var list = await (from e in _context.Employees
        join eh in _context.EmployeeHistories on e.EmployeeId equals eh.EmployeeId
        join j in _context.Jobs on e.EmployeeId equals j.EmployeeId
        select new AboutEmployee()
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Phone = e.Phone,
            Address = e.Address,
            EmployeeHistoryId = eh.EmployeeHistoryId,
            StartDate = eh.StartDate,
            EndDate = eh.EndDate,
            JobId = j.JobId,
            JobName = j.JobName,
            Description = j.Description
        }).ToListAsync();
        return new Response<List<AboutEmployee>>(list);
    }

    public async Task<Response<List<AboutEmployee>>> GetAboutEmployeeName(string name)
    {
        var find = await (from a in _context.Employees
        where a.FirstName.Contains(name)
        select new AboutEmployee()
        {
            EmployeeId = a.EmployeeId,
            FirstName = a.FirstName,
            LastName = a.LastName,
            JobId = a.Job.JobId,
            JobName = a.Job.JobName,
            Description = a.Job.Description,
            Phone = a.Phone,
            Address = a.Address

        }).ToListAsync();

        return new Response<List<AboutEmployee>>(find);
    }

     public async Task<Response<List<AboutEmployee>>> GetAboutEmployeePhone(string phone)
    {
        var find = await (from a in _context.Employees
        where a.Phone.Equals(phone)
        select new AboutEmployee()
        {
            EmployeeId = a.EmployeeId,
            FirstName = a.FirstName,
            LastName = a.LastName,
            JobId = a.Job.JobId,
            JobName = a.Job.JobName,
            Description = a.Job.Description,
            Phone = a.Phone,
            Address = a.Address

        }).ToListAsync();

        return new Response<List<AboutEmployee>>(find);
    }

    // public async Task<Response<List<AboutEmployee>>> GetAverage()
}

