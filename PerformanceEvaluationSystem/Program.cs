using Microsoft.EntityFrameworkCore;
using AutoMapper; // ✅ keep this
using PerformanceEvaluationSystem.AutoMapper;
using PerformanceEvaluationSystem.Data;
using PerformanceEvaluationSystem.Infrastructure;
using PerformanceEvaluationSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PerformanceEvaluation>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PerformanceEvaluationDatabase"))
);

// Register repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


// Disambiguate AddAutoMapper by specifying the full namespace for the extension method
builder.Services.AddAutoMapper(typeof(EmployeeAutoMapper));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
