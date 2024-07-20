namespace SurveyManagement.Domain.Entities
{
    public class Survey : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
