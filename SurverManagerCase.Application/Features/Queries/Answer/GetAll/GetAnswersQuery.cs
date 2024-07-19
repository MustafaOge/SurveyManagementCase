using MediatR;
using SurveyManagement.Application.DTOs.Answer;
using SurveyManagement.Application.DTOs.Question;

namespace SurveyManagement.Application.Features.Queries.Answer.GetAll
{
    public class GetAnswersQuery : IRequest<IEnumerable<AnswerDto>>
    {
        public int SurveyId { get; set; }
    }
}
