using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Survey.Remove
{
    public class RemoveSurveyCommandHandler : IRequestHandler<RemoveSurveyCommandRequest, RemoveSurveyCommandResponse>
    {
        private readonly ISurveyRepository _surveyRepository;

        public RemoveSurveyCommandHandler(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<RemoveSurveyCommandResponse> Handle(RemoveSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyRepository.GetByIdAsync(request.SurveyId);
            if (survey == null)
            {
                return new RemoveSurveyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Survey not found."
                };
            }

             _surveyRepository.Remove(survey);

            return new RemoveSurveyCommandResponse
            {
                IsSuccess = true
            };
        }
    }

}
