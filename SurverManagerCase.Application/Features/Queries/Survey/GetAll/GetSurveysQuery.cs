using MediatR;
using SurveyManagement.Application.DTOs.Survey;

namespace SurveyManagement.Application.Features.Queries.Survey.GetAll
{
    public class GetSurveysQuery : IRequest<List<SurveyDto>>
    {
    }

}
