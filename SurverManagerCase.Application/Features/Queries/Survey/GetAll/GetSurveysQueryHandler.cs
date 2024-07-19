using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Survey;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Survey.GetAll
{
    public class GetSurveysQueryHandler : IRequestHandler<GetSurveysQuery, List<SurveyDto>>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetSurveysQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<List<SurveyDto>> Handle(GetSurveysQuery request, CancellationToken cancellationToken)
        {
            var surveys = await _surveyRepository.GetAllAsync(x => true);

            return _mapper.Map<List<SurveyDto>>(surveys);
        }
    }
}
