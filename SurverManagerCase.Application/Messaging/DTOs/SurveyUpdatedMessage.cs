namespace SurveyManagement.Application.Messaging.DTOs
{
    public class SurveyUpdatedMessage
    {
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Updated { get; set; }
    }
}
