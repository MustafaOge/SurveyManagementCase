using MediatR;
using SurveyManagement.Application.DTOs.Survey;

namespace SurveyManagement.Application.Features.Queries.Survey.GetById
{
    public class GetSurveyByIdQuery : IRequest<SurveyDto>
    {
        public int Id { get; }

        public GetSurveyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
