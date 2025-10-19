using AutoMapper;
using PerformanceEvaluationSystem.Dto;
using PerformanceEvaluationSystem.Models;

namespace PerformanceEvaluationSystem.AutoMapper
{
    public class EmployeeAutoMapper : Profile
    {
        public EmployeeAutoMapper()
        {
            CreateMap<EmployeeDtoPayload, Employee>().ReverseMap();
            CreateMap<Employee, ResponseEmployee>().ReverseMap();
        }
    }
}
