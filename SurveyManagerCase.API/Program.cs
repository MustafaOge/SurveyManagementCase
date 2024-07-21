using Microsoft.EntityFrameworkCore;
using SurveyManagement.API.Extensions;
using SurveyManagement.Application.Configuration;
using SurveyManagement.Application.Mapping;
using SurveyManagement.Persistence.Seeds;
using SurveyManagerCase.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AppDbContext>(options =>
//               options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddDbContext<AppDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScopedWithExtension();
builder.Services.AddCustomServices(builder.Configuration);
builder.Services.AddCustomValidators();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Swagger UI için eriþim yolu
});


app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await SeedDatabase(app.Services);

app.Run();


static async Task SeedDatabase(IServiceProvider services)
{
    using (var scope = services.CreateScope())
    {
        var seedService = scope.ServiceProvider.GetRequiredService<ISeedService>();
        await seedService.SeedAsync(); // Sahte verileri ekle
    }
}