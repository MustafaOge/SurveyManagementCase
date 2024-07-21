using MediatR;

namespace SurveyManagement.Application.Features.Commands.answerRepository.Create
{
    public class CreateAnswerCommandRequest : IRequest<CreateAnswerCommandResponse>
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
    }
}
