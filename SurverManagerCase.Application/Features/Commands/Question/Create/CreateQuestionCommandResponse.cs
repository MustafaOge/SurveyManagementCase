namespace SurveyManagement.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandResponse
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByUser { get; set; }
    }
}
