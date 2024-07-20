using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Messaging.DTOs;

namespace SurveyManagement.Application.Messaging.Consumer
{
    public class SurveyCreatedMessageConsumer(ILogger<SurveyCreatedMessageConsumer> logger, IMediator mediator,IMapper mapper ) : IConsumer<SurveyCreatedMessage>
    {
        public async Task Consume(ConsumeContext<SurveyCreatedMessage> context)
        {
            try
            {
                logger.LogInformation("Received survey created message: {SurveyId}", context.Message.Id);

                // Anket bilgilerini işleyin veya başka bir servise iletin
                Console.WriteLine($"Survey Created: {context.Message.Id}, {context.Message.Title}, {context.Message.Description}");
                CreateSurveyCommandRequest createSurveyCommandRequest = mapper.Map<CreateSurveyCommandRequest>(context.Message);

                await mediator.Send(createSurveyCommandRequest);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing survey created message: {SurveyId}", context.Message.Id);
            }
        }
    }
}
