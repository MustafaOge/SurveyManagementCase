namespace SurveyManagement.Application.Features.Commands.answerRepository.Create
{
    public class CreateAnswerCommandResponse
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByUser { get; set; }
    }
}
