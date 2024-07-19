using MediatR;

namespace SurveyManagement.Application.Features.Commands.Survey.Update
{
    public class UpdateSurveyCommandRequest : IRequest<UpdateSurveyCommandResponse>
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
