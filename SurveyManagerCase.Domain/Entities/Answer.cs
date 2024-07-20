namespace SurveyManagement.Domain.Entities
{
    public class Answer : BaseEntity<int>
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public Question Question { get; set; }
    }

}
