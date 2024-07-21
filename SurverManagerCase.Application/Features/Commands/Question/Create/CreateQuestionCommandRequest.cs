using MediatR;

namespace SurveyManagement.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
    {
        public int SurveyId { get; set; }
        public string Text { get; set; }
    }
}
