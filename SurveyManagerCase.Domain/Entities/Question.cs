namespace SurveyManagement.Domain.Entities
{
    public class Question : BaseEntity<int>
    {
        public int SurveyId { get; set; }
        public string Text { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
