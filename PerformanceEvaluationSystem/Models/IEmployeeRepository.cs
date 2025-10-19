using PerformanceEvaluationSystem.Dto;

namespace PerformanceEvaluationSystem.Models
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id);
        Task<List<ResponseEmployee>> GetAllAsync();
        Task<ResponseEmployee> AddAsync(EmployeeDtoPayload employee);
        Task<bool> UpdateAsync(Guid id, EmployeeDtoPayload employee);
        Task<ResponseEmployee?> DeleteAsync(Guid id);
    }
}
