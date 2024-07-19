using MediatR;

namespace SurveyManagement.Application.Features.Commands.Survey.Remove
{
    public class RemoveSurveyCommandRequest : IRequest<RemoveSurveyCommandResponse>
    {
        public int SurveyId { get; set; }
    }
}
