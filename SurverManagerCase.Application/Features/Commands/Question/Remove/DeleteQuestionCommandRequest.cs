using MediatR;

namespace SurveyManagement.Application.Features.Commands.Question.Remove
{
    public class DeleteAnswerCommandRequest : IRequest<DeleteAnswerCommandResponse>
    {
        public int Id { get; set; }
    }
}
