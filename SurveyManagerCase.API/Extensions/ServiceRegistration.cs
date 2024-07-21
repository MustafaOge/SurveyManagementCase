using MassTransit;
using SurveyManagement.Application.Messaging.Consumer;
using SurveyManagerCase.Persistence.Context;

namespace SurveyManagement.API.Extensions
{
    public static class ServiceRegistration
    {

        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MediatR
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // MassTransit
            services.AddMassTransit(x =>
            {
                // Consumer Servisleri ekleme
                x.AddConsumer<SurveyCreatedMessageConsumer>();
                x.AddConsumer<SurveyUpdatedMessageConsumer>();

                x.AddEntityFrameworkOutbox<AppDbContext>(o =>
                {
                    o.UsePostgres();

                    o.UseBusOutbox();
                });

                x.UsingRabbitMq((context, cfg) =>
                {
                    // RabbitMQ sunucusuna bağlantı
                    cfg.Host(configuration.GetConnectionString("RabbitMQ")!);

                    // Mesaj tekrar denemeleri ve gecikmeli yeniden deneme yapılandırmaları
                    cfg.UseMessageRetry(r => r.Immediate(5));
                    cfg.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(30), TimeSpan.FromMinutes(45)));
                    cfg.UseInMemoryOutbox();

                    // Kuyrukları tanımlama
                    cfg.ReceiveEndpoint("survey-created", e =>
                    {
                        e.ConfigureConsumer<SurveyCreatedMessageConsumer>(context);
                    });

                    cfg.ReceiveEndpoint("survey-updated", e =>
                    {
                        e.ConfigureConsumer<SurveyUpdatedMessageConsumer>(context);
                    });
                });
            });

            // MassTransit Host Ayarları
            services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(30);
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });

            // Cors Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
