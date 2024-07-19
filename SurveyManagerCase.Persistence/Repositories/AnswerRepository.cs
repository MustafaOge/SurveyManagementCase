using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Domain.Entities;
using SurveyManagerCase.Persistence.Context;

namespace SurveyManagement.Persistence.Repositories
{
    public class AnswerRepository : GenericRepository<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
