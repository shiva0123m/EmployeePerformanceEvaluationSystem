using Microsoft.EntityFrameworkCore;
using PerformanceEvaluationSystem.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PerformanceEvaluation>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("PerformanceEvaluationDatabase")
    )); 
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
