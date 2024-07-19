using MediatR;
using SurveyManagement.Application.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Features.Queries.Question.GetById
{
    public class GetQuestionByIdQuery : IRequest<QuestionDto>
    {
        public int Id { get; set; }

        public GetQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
