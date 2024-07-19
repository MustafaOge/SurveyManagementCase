using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Features.Commands.answerRepository.Create
{
    public class CreateAnswerCommandRequest : IRequest<CreateAnswerCommandResponse>
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
    }
}
