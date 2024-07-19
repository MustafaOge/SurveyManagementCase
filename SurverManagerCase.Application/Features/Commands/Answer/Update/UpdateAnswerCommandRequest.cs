using MediatR;

namespace SurveyManagement.Application.Features.Commands.Answer.Update
{
    public class UpdateAnswerCommandRequest : IRequest<UpdateAnswerCommandResponse>
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
