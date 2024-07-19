using Microsoft.EntityFrameworkCore;
using SurveyManagement.API.Extensions;
using SurveyManagement.Application;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Mapping;
using SurveyManagerCase.Persistence.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScopedWithExtension();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
