using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;
using Domain.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class ManagerController
{
    private readonly ManagerService _managerService;
    public ManagerController(ManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet("GetManager")]
    public async Task<Response<List<GetManagerDto>>> GetManager()
    {
        return await _managerService.GetManager();
    }

    [HttpPost("InsertManager")]
    public async Task<Response<AddManagerDto>> AddManager(AddManagerDto manager)
    {
        return await _managerService.AddManager(manager);
    }

    [HttpPut("UpdateManager")]
    public async Task<Response<AddManagerDto>> UpdateManager(AddManagerDto manager)
    {
        return await _managerService.UpdateManager(manager);
    }

    [HttpDelete("DeleteManager")]
    public async Task<Response<string>> DeleteManager(int id)
    {
        return  await _managerService.DeleteManager(id);
    }

    [HttpGet("GetByIdEmployeeM")]
    public async Task<Response<AboutEmployee>> GetById(int id)
    {
        return await _managerService.GetById(id);
    }


    [HttpGet("AboutEmployee")]
    public async Task<Response<List<AboutEmployee>>> AboutEmployee()
    {
        return await _managerService.GetAboutEmployee();
    }

    [HttpGet("GetName")]
    public async Task<Response<List<AboutEmployee>>> GetByName(string name)
    {
        return await _managerService.GetAboutEmployeeName(name);
    }

    [HttpGet("GetPhoneNumber")]
    public async Task<Response<List<AboutEmployee>>> GetByPhone(string phone)
    {
        return await _managerService.GetAboutEmployeePhone(phone);
    }
}
