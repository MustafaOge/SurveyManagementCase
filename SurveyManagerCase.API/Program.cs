using MassTransit;
using Microsoft.EntityFrameworkCore;
using SurveyManagement.API.Extensions;
using SurveyManagement.Application;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Mapping;
using SurveyManagement.Application.Messaging.Consumer;
using SurveyManagement.Application.Messaging.Publisher;
using SurveyManagerCase.Persistence.Context;
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
