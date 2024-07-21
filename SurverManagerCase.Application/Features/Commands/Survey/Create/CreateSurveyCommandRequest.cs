using MediatR;

namespace SurveyManagement.Application.Features.Commands.Survey.Create
{
    public class CreateSurveyCommandRequest : IRequest<CreateSurveyCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
