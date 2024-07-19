using MediatR;
using SurveyManagement.Application.DTOs.Question;

namespace SurveyManagement.Application.Features.Queries.Question.GetAll
{
    public class GetQuestionsQuery : IRequest<IEnumerable<QuestionDto>>
    {
        public int SurveyId { get; set; }
    }
}
