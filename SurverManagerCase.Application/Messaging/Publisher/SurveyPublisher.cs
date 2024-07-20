using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Application.Messaging.DTOs;
using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Messaging.Publisher
{
    public class SurveyPublisher
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly ILogger<SurveyPublisher> _logger;
        private readonly ISurveyRepository _surveyRepository; // Survey verilerini almak için

        public SurveyPublisher(ISendEndpointProvider sendEndpointProvider, ILogger<SurveyPublisher> logger, ISurveyRepository surveyRepository)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _logger = logger;
            _surveyRepository = surveyRepository;
        }

        public async Task SendSurveyCreatedMessage( string title, string description, DateTime created)
        {
            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            try
            {
                var message = new SurveyCreatedMessage
                {
                    Title = title,
                    Description = description,
                    Created = created
                };

                var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:survey-created"));

                //await endpoint.Send(message);
                await endpoint.Send(message, pipe =>
                {
                    pipe.Durable = true;
                    pipe.SetAwaitAck(true);
                    pipe.CorrelationId = Guid.NewGuid();
                }, tokenSource.Token);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending survey created message: {Id}");
            }
        }

        public async Task SendSurveyUpdatedMessage(int id, string title, string description, DateTime updated)
        {
            try
            {
                var message = new SurveyUpdatedMessage
                {
                    SurveyId = id,
                    Title = title,
                    Description = description,
                    Updated = updated
                };

                var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:survey-updated"));
                await endpoint.Send(message);
                _logger.LogInformation("Survey updated message sent: {Id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending survey updated message: {Id}", id);
            }
        }
    }

}
