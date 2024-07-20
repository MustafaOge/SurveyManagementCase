using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SurveyManagement.Application.Features.Commands.Survey.Update;
using SurveyManagement.Application.Messaging.DTOs;

namespace SurveyManagement.Application.Messaging.Consumer
{
    public class SurveyUpdatedMessageConsumer(ILogger<SurveyUpdatedMessageConsumer> logger, IMediator mediator, IMapper mapper) : IConsumer<SurveyUpdatedMessage>
    {
        public async Task Consume(ConsumeContext<SurveyUpdatedMessage> context)
        {
            try
            {
                logger.LogInformation("Received survey updated message: {SurveyId}", context.Message.SurveyId);

                // Anket bilgilerini işleyin veya başka bir servise iletin
                Console.WriteLine($"Survey Updated: {context.Message.SurveyId}, {context.Message.Title}");
                UpdateSurveyCommandRequest updateSurveyCommandRequest =  mapper.Map<UpdateSurveyCommandRequest>(context.Message);

                await mediator.Send(updateSurveyCommandRequest);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing survey updated message: {SurveyId}", context.Message.SurveyId);
            }
        }
    }
}
