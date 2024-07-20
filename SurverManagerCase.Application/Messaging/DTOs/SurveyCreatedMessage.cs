namespace SurveyManagement.Application.Messaging.DTOs;

public class SurveyCreatedMessage
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
}
