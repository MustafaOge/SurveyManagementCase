using MediatR;

namespace SurveyManagement.Application.Features.Commands.Question.Update
{
    public class UpdateQuestionCommandRequest : IRequest<UpdateQuestionCommandResponse>
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
