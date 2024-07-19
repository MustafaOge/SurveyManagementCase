using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Domain.Entities;
using SurveyManagerCase.Persistence.Context;

namespace SurveyManagement.Persistence.Repositories
{
    public class SurveyRepository : GenericRepository<Survey, int>, ISurveyRepository
    {
        public SurveyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
