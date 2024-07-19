﻿using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Interfaces.Repositories
{
    public interface IQuestionRepository : IGenericRepository<Question, int>
    {
    }
}
