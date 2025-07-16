using Microsoft.EntityFrameworkCore;
using University.Repositories;
using University.Repositories.Interfaces;
using UniversityAPI.Data;
using UniversityAPI.Repositories.Interfaces;
using UniversityAPI.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with PostgreSQL connection string
builder.Services.AddDbContext<DataContextEF>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Add controllers support
builder.Services.AddControllers();

// Add Swagger / OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map controller endpoints
app.MapControllers();

app.Run();