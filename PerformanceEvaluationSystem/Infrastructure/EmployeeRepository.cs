using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PerformanceEvaluationSystem.AutoMapper;
using PerformanceEvaluationSystem.Data;
using PerformanceEvaluationSystem.Dto;
using PerformanceEvaluationSystem.Models;

namespace PerformanceEvaluationSystem.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PerformanceEvaluation dbcontext;
        private readonly IMapper mapper;

        public EmployeeRepository(PerformanceEvaluation context, IMapper mapper)
        {
            this.mapper = mapper;
            dbcontext = context;
        }

        public async Task<ResponseEmployee> AddAsync(EmployeeDtoPayload employee)
        {
            var payload = mapper.Map<Employee>(employee);
            await dbcontext.Employees.AddAsync(payload);
            await dbcontext.SaveChangesAsync();

            var response = mapper.Map<ResponseEmployee>(payload);
            return response;
        }

        public async Task<ResponseEmployee?> DeleteAsync(Guid id)
        {
            var existingEmployee = await dbcontext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (existingEmployee == null)
                return null;

            dbcontext.Employees.Remove(existingEmployee);
            await dbcontext.SaveChangesAsync();

            var response = mapper.Map<ResponseEmployee>(existingEmployee);
            return response;
        }

        public async Task<List<ResponseEmployee>> GetAllAsync()
        {
            var employees = await dbcontext.Employees.ToListAsync();
            var response = mapper.Map<List<ResponseEmployee>>(employees);
            return response;
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            var employee = await dbcontext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee;
        }

        public async Task<bool> UpdateAsync(Guid id, EmployeeDtoPayload employee)
        {
            var existingEmployee = await dbcontext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (existingEmployee == null)
                return false;

            // Map updated fields into the existing entity instead of adding a new one
            mapper.Map(employee, existingEmployee);

            dbcontext.Employees.Update(existingEmployee);
            await dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
