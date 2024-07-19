using AutoMapper;
using MediatR;
using SurveyManagement.Application.Features.Commands.Survey.Create;
using SurveyManagement.Application.Interfaces.Repositories;
using SurveyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManagement.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper) : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
    {


        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {

    
            var question = mapper.Map<SurveyManagement.Domain.Entities.Question>(request);
            await questionRepository.AddAsync(question);
            return mapper.Map<CreateQuestionCommandResponse>(question);



        }
    }
}