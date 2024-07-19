using MediatR;
using SurveyManagement.Application.DTOs.Answer;

namespace SurveyManagement.Application.Features.Queries.Answer.GetById
{
    public class GetAnswerByIdQuery : IRequest<AnswerDto>
    {
        public int Id { get; set; }

        public GetAnswerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
