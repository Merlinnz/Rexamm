using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class JobController
{
    private readonly JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("GetJob")]
    public async Task<Response<List<GetJobDto>>> GetJob()
    {
        return await _jobService.GetJob();
    }

    [HttpPost("InsertJob")]
    public async Task<Response<AddJobDto>> AddJob(AddJobDto job)
    {
        return await _jobService.AddJob(job);
    }

    [HttpPut("UpdateJob")]
    public async Task<Response<AddJobDto>> UpdateJob(AddJobDto job)
    {
        return await _jobService.UpdateJob(job);
    }

    [HttpDelete("DeleteJob")]
    public async Task<Response<string>> DeleteJob(int id)
    {
        return await _jobService.DeleteJob(id);
    }
}
