namespace SurveyManagement.Application.Features.Commands.Survey.Create
{
    public class CreateSurveyCommandResponse
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

}
