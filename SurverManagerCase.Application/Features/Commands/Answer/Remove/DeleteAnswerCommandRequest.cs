using MediatR;

namespace SurveyManagement.Application.Features.Commands.Answer.Remove
{
    public class DeleteAnswerCommandRequest : IRequest<DeleteAnswerCommandResponse>
    {
        public int Id { get; set; }
    }
}
