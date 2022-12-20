using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public JobService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetJobDto>>> GetJob()
    {
        var list = _mapper.Map<List<GetJobDto>>(await _context.Jobs.ToListAsync());
        return new Response<List<GetJobDto>>(list);
    }

    public async Task<Response<AddJobDto>> AddJob(AddJobDto job)
    {
        var newJob = _mapper.Map<Job>(job);
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<AddJobDto>(job);
    }

    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job)
    {
        var find = await _context.Jobs.FindAsync(job.JobId);
        find.JobName = job.JobName;
        find.Description = job.Description;
        find.EmployeeId = job.EmployeeId;

        await _context.SaveChangesAsync();
        return new Response<AddJobDto>(job);
    }

    public async Task<Response<string>> DeleteJob(int id)
    {
        var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Job deleted successfully");
    }
}
