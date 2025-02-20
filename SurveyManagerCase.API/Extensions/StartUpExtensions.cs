﻿using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Application.Messaging.Publisher;
using SurveyManagement.Persistence.Repositories;
using SurveyManagement.Persistence.Seeds;

namespace SurveyManagement.API.Extensions
{
    public static class StartUpExtensions
    {
        public static IServiceCollection AddScopedWithExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<SurveyPublisher>();
            services.AddScoped<ISeedService, SeedService>();

            return services;
        }

    }
}
