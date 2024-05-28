using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nowadays.EFCoreDbContext;
using Nowadays.Mapper;
using Nowadays.Models;
using Nowadays.Models.ValueObject;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfiles());
});
IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IReportService, ReportService>();


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
