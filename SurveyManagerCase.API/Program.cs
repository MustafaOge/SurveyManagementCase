using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SurveyManagement.API.Extensions;
using SurveyManagement.Application;
using SurveyManagement.Application.Configuration;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Mapping;
using SurveyManagement.Application.Messaging.Consumer;
using SurveyManagement.Application.Messaging.Publisher;
using SurveyManagement.Application.Validations.Survey;
using SurveyManagerCase.Persistence.Context;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScopedWithExtension();
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.AddCustomValidators();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
