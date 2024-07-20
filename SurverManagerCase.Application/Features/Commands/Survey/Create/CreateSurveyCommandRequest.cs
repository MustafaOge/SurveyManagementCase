using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Features.Commands.Survey.Create
{
    public class CreateSurveyCommandRequest : IRequest<CreateSurveyCommandResponse>
    {

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
