using AutoMapper;
using MediatR;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Survey.Update
{
    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommandRequest, UpdateSurveyCommandResponse>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public UpdateSurveyCommandHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSurveyCommandResponse> Handle(UpdateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyRepository.GetByIdAsync(request.SurveyId);
            if (survey == null)
            {
                return new UpdateSurveyCommandResponse
                {
                    IsSuccess = false,
                    ErrorMessage = "Survey not found."
                };
            }

            // Map the request properties to the existing survey entity
            _mapper.Map(request, survey);
            survey.Updated = DateTime.UtcNow;

             _surveyRepository.Update(survey);

            return new UpdateSurveyCommandResponse
            {
                IsSuccess = true
            };
        }
    }

}
