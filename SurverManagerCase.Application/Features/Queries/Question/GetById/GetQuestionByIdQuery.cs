using MediatR;
using SurveyManagement.Application.DTOs.Question;

namespace SurveyManagement.Application.Features.Queries.Question.GetById
{
    public class GetQuestionByIdQuery : IRequest<QuestionDto>
    {
        public int Id { get; set; }

        public GetQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
