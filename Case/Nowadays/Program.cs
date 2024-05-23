using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nowadays.EFCoreDbContext;
using Nowadays.Mapper;
using Nowadays.Models;
using Nowadays.Models.ValueObject;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Abstract.Base;
using Nowadays.Repositories.Concrete;
using Nowadays.Repositories.Concrete.Base;
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

builder.Services.AddDbContext<NowadaysDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SQL"))
            );

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBaseRepository<Company>, BaseRepository<Company>>();
builder.Services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
builder.Services.AddScoped<IBaseRepository<Issue>, BaseRepository<Issue>>();
builder.Services.AddScoped<IBaseRepository<Project>, BaseRepository<Project>>();
builder.Services.AddScoped<IBaseRepository<ProjectEmployee>, BaseRepository<ProjectEmployee>>();
builder.Services.AddScoped<IBaseRepository<Report>, BaseRepository<Report>>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();


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
