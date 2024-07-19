namespace SurveyManagement.Domain.Entities
{
    public interface IEntity{}
    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public int CreatedByUser { get; set; }

        public int? UpdatedByUser { get; set; }
    }
}
