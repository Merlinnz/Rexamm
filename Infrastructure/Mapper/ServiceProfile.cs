using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<AddEmployeeDto, Employee>().ReverseMap();
        CreateMap<GetEmployeeDto, Employee>().ReverseMap();

        CreateMap<GetEmployeeHistoryDto, EmployeeHistory>().ReverseMap(); 
        CreateMap<AddEmployeeHistoryDto, EmployeeHistory>().ReverseMap(); 

        CreateMap<AddManagerDto, Manager>().ReverseMap(); 
        CreateMap<GetManagerDto, Manager>().ReverseMap(); 
        
        CreateMap<AboutEmployee, Employee>().ReverseMap(); 

        CreateMap<AddJobDto, Job>().ReverseMap();
        CreateMap<GetJobDto, Job>().ReverseMap();

    }
}