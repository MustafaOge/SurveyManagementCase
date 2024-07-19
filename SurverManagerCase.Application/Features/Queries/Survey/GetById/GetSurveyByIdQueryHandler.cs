using AutoMapper;
using MediatR;
using SurveyManagement.Application.DTOs.Survey;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Queries.Survey.GetById
{
    public class GetSurveyByIdQueryHandler(ISurveyRepository surveyRepository, IMapper mapper) : IRequestHandler<GetSurveyByIdQuery, SurveyDto>
    {
        public async Task<SurveyDto> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
        {
            var survey = await surveyRepository.GetByIdAsync(request.Id);

            if (survey == null)
            {
                return null; // Veya uygun bir hata yönetimi yapabilirsiniz
            }

            return mapper.Map<SurveyDto>(survey);
        }
    }

}
