using AutoMapper;
using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Survey.Create
{
    public class CreateSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository) : IRequestHandler<CreateSurveyCommandRequest, CreateSurveyCommandResponse>
    {
        public async Task<CreateSurveyCommandResponse> Handle(CreateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = mapper.Map<SurveyManagement.Domain.Entities.Survey>(request);
            survey.Created = DateTime.UtcNow;
            survey.Updated = null; // or set to default value
            survey.CreatedByUser = 1; // or the current user ID

            await surveyRepository.AddAsync(survey);

            return mapper.Map<CreateSurveyCommandResponse>(survey);
        }
    }

}
