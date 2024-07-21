using FluentValidation.AspNetCore;
using FluentValidation;
using SurveyManagement.Application.Validations.Answer;
using SurveyManagement.Application.Validations.Question;
using SurveyManagement.Application.Validations.Survey;

namespace SurveyManagement.Application.Configuration
{
    public static class ValidationConfigurationExtensions
    {
        public static IServiceCollection AddCustomValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining<CreateSurveyRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateSurveyRequestValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateQuestionRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateQuestionRequestValidator>();

            services.AddValidatorsFromAssemblyContaining<CreateAnswerRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAnswerRequestValidator>();

            return services;
        }
    }
}
