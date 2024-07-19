using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Domain.Entities;
using SurveyManagerCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Persistence.Repositories
{
    public class QuestionRepository : GenericRepository<Question, int>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
