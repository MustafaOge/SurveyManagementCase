using AutoMapper;
using MediatR;
using SurveyManagement.Application.Features.Commands.answerRepository.Create;
using SurveyManagement.Application.Interfaces.Repositories;

namespace SurveyManagement.Application.Features.Commands.Answer.Create
{
    public class CreateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper) : IRequestHandler<CreateAnswerCommandRequest, CreateAnswerCommandResponse>
    {


        public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommandRequest request, CancellationToken cancellationToken)
        {

    
            var answer = mapper.Map<SurveyManagement.Domain.Entities.Answer>(request);
            await answerRepository.AddAsync(answer);
            return mapper.Map<CreateAnswerCommandResponse>(answer);



        }
    }
}