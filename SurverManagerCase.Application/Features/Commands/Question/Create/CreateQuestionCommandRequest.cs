using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
    {
        public int SurveyId { get; set; }
        public string Text { get; set; }
    }
}
