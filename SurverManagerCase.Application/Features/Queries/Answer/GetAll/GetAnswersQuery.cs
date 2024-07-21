using MediatR;
using SurveyManagement.Application.DTOs.Answer;

namespace SurveyManagement.Application.Features.Queries.Answer.GetAll
{
    public class GetAnswersQuery : IRequest<IEnumerable<AnswerDto>>
    {
        public int SurveyId { get; set; }
    }
}
